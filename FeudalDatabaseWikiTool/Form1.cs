//#define SkillXmlBroken
using FeudalDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeudalDatabaseWikiTool
{
    public partial class Form1 : Form
    {
        Dictionary<int, FeudalSkill> _skill_types;
        Dictionary<int, FeudalObject> _objects_types;
        Dictionary<int, FeudalObjectDescription> _object_type_descriptions;
        Dictionary<int, FeudalRecipe> _recipes;
        Dictionary<int, FeudalRecipeRequirement> _recipe_requirements;

        public Form1()
        {
            InitializeComponent();

#if DEBUG
            this.Text += " (DEBUG)";
#endif

            textBox1.Enabled = false;
            textBox1.Text = string.Empty;
            comboBox1.Enabled = false;
            comboBox1.SelectedIndex = -1;

            // Read the previously used folder.
            string selectedFolder = GetPreviousFolderPath();

            // If there is no previously used folder, check if the default MMO AppData folder exist.
            if (selectedFolder == string.Empty)
            {
                string[] defaultFolders = new string[] {
                    System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Life is Feudal MMO", "game", "eu")
                  , System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86), "Steam", "steamapps", "common", "Life is Feudal MMO", "game", "eu")
                };
                foreach (string defaultFolder in defaultFolders)
                {
                    if (System.IO.Directory.Exists(defaultFolder))
                    {
                        selectedFolder = defaultFolder;
                        break;
                    }
                }
            }

            tbxBrowsePath.Text = selectedFolder;

            SetPreviousFolderPath(selectedFolder);
        }

        private void ReadGameDataFolder(string folderPath)
        {
            textBox1.Enabled = false;
            textBox1.Text = string.Empty;
            comboBox1.Enabled = false;
            comboBox1.SelectedIndex = -1;

            if (!System.IO.Directory.Exists(folderPath))
            {
                MessageBox.Show(this, $"The game data folder could not be found:{Environment.NewLine}{Environment.NewLine}{folderPath}"
                    , "Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             
            // Read the game data files.
#if !DEBUG
            try
#endif
            {
#if SkillXmlBroken
                _skill_types = FeudalSkill.ManualList();
#else
                _skill_types = FeudalSkill.ReadAll(folderPath);
#endif
                _objects_types = FeudalObject.ReadAll(folderPath);
                _object_type_descriptions = FeudalObjectDescription.ReadAll(folderPath);
                _recipes = FeudalRecipe.ReadAll(folderPath);
                _recipe_requirements = FeudalRecipeRequirement.ReadAll(folderPath);

                textBox1.Enabled = true;
                comboBox1.Enabled = true;
            }
#if !DEBUG
            catch (Exception ex)
            {
                DialogResult dialogResult = MessageBox.Show(this, $"Reading the game files failed.{Environment.NewLine}{Environment.NewLine}{ex.Message}{Environment.NewLine}{Environment.NewLine}Do you want to copy fully error message to clipboard?"
                    , "Game File Reading Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.Yes)
                    Clipboard.SetText(ex.ToString());
            }
#endif
        }

        private void SetPreviousFolderPath(string folderPath)
        {
            Properties.Settings.Default.FolderPrevious = folderPath;
            Properties.Settings.Default.Save();
        }
        private string GetPreviousFolderPath()
        {
            return Properties.Settings.Default.FolderPrevious;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            ReadGameDataFolder(tbxBrowsePath.Text);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            ReadGameDataFolder(folderBrowserDialog1.SelectedPath);
        }

        private string OnlyFirstLetterCapitalized(string s)
        {
            return $"{s.Remove(1).ToUpper()}{s.Substring(1).ToLower()}";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                return;

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    textBox1.Text = DataPages.CreateSkills(_skill_types.Values);
                    break;
                case 1:
                    textBox1.Text = DataPages.CreateObjects(_objects_types.Values);
                    break;
                case 2:
                    textBox1.Text = DataPages.CreateObjectDescriptions(_object_type_descriptions.Values);
                    break;
                case 3:
                    textBox1.Text = DataPages.CreateRecipes(_recipes.Values);
                    break;
                case 4:
                    textBox1.Text = DataPages.CreateRecipeRequirements(_recipe_requirements.Values);
                    break;
                default:
                    textBox1.Text = "Not implemented yet.";
                    break;
            }
        }
    }
}
