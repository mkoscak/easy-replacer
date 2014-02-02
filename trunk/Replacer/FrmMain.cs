using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Novacode;

namespace Replacer
{
    public partial class FrmMain : Form
    {
        const string SUBS_PATH = @".\substitutions\";
        const string TEMPLATES_PATH = @".\templates\";
        const string OUTPUT_PATH = @".\output\";
        const string RESOURCES_PATH = @".\resources\";
        const string TXT_SEARCH_PATTERN = @"*.xml";
        const string DOCX_SEARCH_PATTERN = @"*.docx";
        const string SUBS_SEARCH_PATTERN = @"*.subs";
        const string ITEM_CHOOSE = @"..";

        string TemplateDirectory;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSubstitutions();
                LoadTemplateSets();
                LoadResources();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error while initialization: " + ex, "Init", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadResources()
        {
            var icoPath = RESOURCES_PATH + "appicon.ico";
            if (File.Exists(icoPath))
                this.Icon = new Icon(icoPath);

            var logoPath = RESOURCES_PATH + "logo.png";
            if (!File.Exists(logoPath))
                logoPath = RESOURCES_PATH + "logo.jpg";
            if (!File.Exists(logoPath))
                logoPath = RESOURCES_PATH + "logo.jpeg";

            if (File.Exists(logoPath))
                picLogo.Image = System.Drawing.Image.FromFile(logoPath);
        }

        private void LoadSubstitutions()
        {
            var ds = new List<string>();
            ds.Add(string.Empty);
            ds.Add(ITEM_CHOOSE);

            if (Directory.Exists(TEMPLATES_PATH))
            {
                var dirs = Directory.GetDirectories(TEMPLATES_PATH);
                ds.AddRange(dirs.Select(s => s.Replace(TEMPLATES_PATH, "")));
            }

            cbTemplate.DataSource = ds;
        }

        private void LoadTemplateSets()
        {
            var ds = new List<string>();
            ds.Add(string.Empty);
            ds.Add(ITEM_CHOOSE);

            if (Directory.Exists(SUBS_PATH))
            {
                var files = Directory.GetFiles(SUBS_PATH, SUBS_SEARCH_PATTERN);
                ds.AddRange(files.Select(s => s.Replace(SUBS_PATH, "")));
            }

            cbSubstitutions.DataSource = ds;
        }

        private void ReadSubs(string path)
        {
            if (path == null || path == string.Empty)
            {
                lblTemplateName.Text = "<no subs file>";
                txtSubs.Text = string.Empty;
                return;
            }

            var def = File.ReadAllLines(path);
            txtSubs.Lines = def;

            lblTemplateName.Text = path;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (TemplateDirectory == null || !Directory.Exists(TemplateDirectory))
            {
                MessageBox.Show(this, "Template set is not selected!", "Process", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                ProcessAllTemplates(TemplateDirectory);

                MessageBox.Show(this, "Process successfully completed!", "Process", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error during processing: " + ex, "Process", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                SetStatus("Process completed!");
            }
        }

        private void ProcessAllTemplates(string path)
        {
            string[] files;
            var outdir = CreateOutDir();

            files = Directory.GetFiles(path, TXT_SEARCH_PATTERN);
            foreach (var file in files)
            {
                ProcessFile(file, outdir);
            }

            files = Directory.GetFiles(path, DOCX_SEARCH_PATTERN);
            foreach (var file in files)
            {
                ProcessFile(file, outdir);
            }
        }

        private void ProcessFile(string file, string outdir)
        {
            SetStatus("Processing file '" + file + "'");

            Dictionary<string, string> replaces = DecodeReplaces();

            if (file.Contains(TXT_SEARCH_PATTERN.Replace("*","")))
                ProcessXML(file, outdir, replaces);

            if (file.Contains(DOCX_SEARCH_PATTERN.Replace("*", "")))
                ProcessDOCX(file, outdir, replaces);
        }

        /// <summary>
        /// zo vstupneho textu vyrobi dictionary s parmi nazov/hodnota, oddelovacom je =
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> DecodeReplaces()
        {
            Dictionary<string, string> ret =  new Dictionary<string,string>();
            
            var lines = txtSubs.Lines;
            foreach (var line in lines)
            {
                var tline = line.Trim();
                // komentar
                if (tline.StartsWith("//"))
                    continue;

                // prazdny riadok
                if (tline.Length == 0)
                    continue;

                // riadok moze obsahovat prave jedno =
                if (tline.Split('=').Length != 2)
                    continue;

                var split = tline.Split('=');
                ret.Add(split[0], split[1]);
            }

            return ret;
        }

        private void ProcessDOCX(string file, string outdir, Dictionary<string, string> replaces)
        {
            using (var doc = DocX.Load(file))
            {
                ReplaceAllTexts(doc, replaces);
                SaveDoc(doc, outdir, file.Substring(file.LastIndexOf('\\')));
            }
        }

        private void ReplaceAllTexts(DocX doc, Dictionary<string, string> replaces)
        {
            foreach (var replace in replaces)
            {
                doc.ReplaceText(replace.Key, replace.Value, false, System.Text.RegularExpressions.RegexOptions.None, null, null, MatchFormattingOptions.ExactMatch);
            }
        }

        private void SaveDoc(DocX doc, string dir, string fileName)
        {
            doc.SaveAs(dir + fileName);
        }

        private void ProcessXML(string file, string outdir, Dictionary<string, string> replaces)
        {
            var content = File.ReadAllText(file);
            foreach (var replace in replaces)
                content = content.Replace(replace.Key, replace.Value);

            // ulozenie
            File.WriteAllText(outdir + file.Substring(file.LastIndexOf('\\')), content);
        }

        private void SetStatus(string text)
        {
            statusBar.Items[0].Text = text;
        }

        private static string CreateOutDir()
        {
            if (!Directory.Exists(OUTPUT_PATH))
                Directory.CreateDirectory(OUTPUT_PATH);

            var dir = OUTPUT_PATH + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return dir;
        }

        private void cbSubstitutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var seltext = cbSubstitutions.SelectedItem.ToString();

            if (seltext == string.Empty)
            {
                ReadSubs(string.Empty);
            }
            else if (seltext == ITEM_CHOOSE)
            {
                string fname = ChooseFile(Application.StartupPath, "Replace files (*.subs)|*.subs|All files|*.*");
                if (fname != null)
                    ReadSubs(fname);
            }
            else
                ReadSubs(SUBS_PATH + seltext);
        }

        private void cbTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            var seltext = cbTemplate.SelectedItem.ToString();

            if (seltext == string.Empty)
            {
                TemplateDirectory = null;
            }
            else if (seltext == ITEM_CHOOSE)
            {
                TemplateDirectory = ChooseDirectory(Application.StartupPath, "Select a template set directory");
            }
            else
                TemplateDirectory = TEMPLATES_PATH + seltext;

            SetStatus("Template set chosen: " + TemplateDirectory);
        }

        private string ChooseDirectory(string initDir, string text)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = initDir;
            fbd.ShowNewFolderButton = false;
            fbd.Description = text;

            if (fbd.ShowDialog() == DialogResult.OK)
                return fbd.SelectedPath;

            return null;
        }

        private string ChooseFile(string initDir, string filter)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = filter;
            ofd.InitialDirectory = initDir;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
                return ofd.FileName;

            return null;
        }
    }
}
