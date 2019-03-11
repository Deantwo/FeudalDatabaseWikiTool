#define SkillXmlBroken
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
        Dictionary<int, FeudalRecipe> _recipes;
        Dictionary<int, FeudalRecipeRequirement> _recipe_requirements;

        List<FeudalObject> _tableList;

        public Form1()
        {
            InitializeComponent();

            // Read the previously used folder.
            string previousFolder = GetPreviousFolderPath();

            // If there is no previously used folder, check if the default MMO AppData folder exist.
            // Else open previously used folder.
            if (previousFolder == string.Empty)
            {
                string folderDefaultAppdataEu = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Life is Feudal MMO", "game", "eu");
                if (System.IO.Directory.Exists(folderDefaultAppdataEu))
                    ReadGameDataFolder(folderDefaultAppdataEu);
                // Add other possible default paths here.
            }
            else
                ReadGameDataFolder(previousFolder);
        }

        private void ReadGameDataFolder(string folderPath)
        {
            if (!System.IO.Directory.Exists(folderPath))
            {
                MessageBox.Show(this, $"The game data folder could not be found:{Environment.NewLine}{folderPath}", "Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblBrowsePath.Text = folderPath;
            SetPreviousFolderPath(folderPath);

            // Read the game data files.
#if SkillXmlBroken
            _skill_types = FeudalSkill.ManualList();
#else
            _skill_types = FeudalSkill.ReadAll(folderPath);
#endif
            _objects_types = FeudalObject.ReadAll(folderPath);
            _recipes = FeudalRecipe.ReadAll(folderPath);
            _recipe_requirements = FeudalRecipeRequirement.ReadAll(folderPath);

            _tableList = _objects_types.Values.ToList();
            dgvDatabase.DataSource = _tableList;
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

        //private void TestDataFolder()
        //{
        //    List<FeudalObject> testlist = new List<FeudalObject>();
        //    foreach (FeudalObject objects_type in _objects_types.Values)
        //    {
        //        testlist.Add(objects_type);
        //    
        //        IEnumerable<FeudalRecipe> matching_recipes = recipes.Values.Where(x => x.ResultObjectTypeID == objects_type.ID);
        //        foreach (FeudalRecipe matching_recipe in matching_recipes)
        //        {
        //            TreeNode ctn = tn.Nodes.Add(matching_recipe.ID.ToString(), matching_recipe.Name);
        //    
        //            IEnumerable<FeudalRecipeRequirement> matching_recipe_requirements = recipe_requirements.Values.Where(x => x.RecipeID == matching_recipe.ID);
        //            foreach (FeudalRecipeRequirement matching_recipe_requirement in matching_recipe_requirements)
        //            {
        //                string requirement = $"{matching_recipe_requirement.Quantity} x {objects_types[matching_recipe_requirement.MaterialObjectTypeID].Name}";
        //                if (matching_recipe_requirement.IsRegionItemRequired)
        //                    requirement += $" (Regional)";
        //                ctn.Nodes.Add(matching_recipe_requirement.ID.ToString(), requirement);
        //            }
        //        }
        //    }
        //}

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            ReadGameDataFolder(folderBrowserDialog1.SelectedPath);
        }

        private void tbxFilter_TextChanged(object sender, EventArgs e)
        {
            if (tbxFilter.Text == string.Empty)
                dgvDatabase.DataSource = _tableList;
            else
            {
                int id;
                if (int.TryParse(tbxFilter.Text, out id))
                    dgvDatabase.DataSource = _tableList.FindAll(x => x.ID == id || x.ParentID == id);
                else
                    dgvDatabase.DataSource = _tableList.FindAll(x => x.Name.ToLower().Contains(tbxFilter.Text.ToLower()));
            }
        }

        #region DataGridView ContextMenu RightClick
        private void dgvDatabase_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        { // Based on: http://stackoverflow.com/questions/1718389/right-click-context-menu-for-datagrid.
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DataGridView dgv = (sender as DataGridView);
                dgv.ContextMenuStrip = cmsRightClick;
                DataGridViewCell currentCell = dgv[e.ColumnIndex, e.RowIndex];
                currentCell.DataGridView.ClearSelection();
                currentCell.DataGridView.CurrentCell = currentCell;
                currentCell.Selected = true;
                //Rectangle r = currentCell.DataGridView.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
                //Point p = new Point(r.X + r.Width, r.Y + r.Height);
                Point p = dgv.PointToClient(Control.MousePosition);
                dgv.ContextMenuStrip.Show(currentCell.DataGridView, p);
                dgv.ContextMenuStrip = null;
            }
        }

        private void dgvDatabase_KeyDown(object sender, KeyEventArgs e)
        { // Based on: http://stackoverflow.com/questions/1718389/right-click-context-menu-for-datagrid.
            DataGridView dgv = (sender as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
                cmsRightClick_Opening(sender, null);
                if ((e.KeyCode == Keys.F10 && !e.Control && e.Shift) || e.KeyCode == Keys.Apps)
                {
                    dgv.ContextMenuStrip = cmsRightClick;
                    Rectangle r = currentCell.DataGridView.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
                    Point p = new Point(r.X + r.Width, r.Y + r.Height);
                    dgv.ContextMenuStrip.Show(currentCell.DataGridView, p);
                    dgv.ContextMenuStrip = null;
                }
                else if (e.KeyCode == Keys.C && e.Control && !e.Shift)
                    cmsRightClickCopy_Click(sender, null);
            }
        }

        private void cmsRightClick_Opening(object sender, CancelEventArgs e)
        {
            // Get table in question and currentCell.
            DataGridView dgv = (sender as DataGridView);
            if (dgv == null)
                dgv = ((sender as ContextMenuStrip).SourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;

            // Nothing here yet.
        }

        private void cmsRightClickCopy_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (sender as DataGridView);
            if (dgv == null)
                dgv = (((sender as ToolStripItem).Owner as ContextMenuStrip).SourceControl as DataGridView);
            DataGridViewCell currentCell = dgv.CurrentCell;
            if (currentCell != null)
            {
                // Check if the cell is empty.
                if (!String.IsNullOrEmpty(currentCell.Value.ToString()))
                { // If not empty, add to clipboard and inform the user.
                    Clipboard.SetText(currentCell.Value.ToString());
//                    toolStripStatusLabel1.Text = "Cell content copied to clipboard (\"" + currentCell.Value.ToString() + "\")";
                }
                else
                { // Inform the user the cell was empty and therefor no reason to erase the clipboard.
//                    toolStripStatusLabel1.Text = "Cell is empty";
//#if DEBUG
//                    // Debug code to see if the cell is null or "".
//                    if (dgv.CurrentCell.Value == null)
//                        toolStripStatusLabel1.Text += " (null)";
//                    else
//                        toolStripStatusLabel1.Text += " (\"\")";
//#endif
                }
            }
        }
        #endregion

        private void cmsRightClickItemTemplate_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (sender as DataGridView);
            if (dgv == null)
                dgv = (((sender as ToolStripItem).Owner as ContextMenuStrip).SourceControl as DataGridView);
            DataGridViewRow currentRow = dgv.CurrentRow;
            if (currentRow == null)
                return;
            FeudalObject feudalObject = (currentRow.DataBoundItem as FeudalObject);
            if (feudalObject == null)
                return;

            List<FeudalRecipe> recipes = _recipes.Values.Where(x => x.ResultObjectTypeID == feudalObject.ID).ToList();

            string infobox = $@"{{{{infobox item
| name = {feudalObject.Name}
| image = {feudalObject.FaceImage.Substring(feudalObject.FaceImage.LastIndexOf('\\') + 1)}
| type = {(feudalObject.ParentID != 0 ? OnlyFirstLetterCapitalized(_objects_types[feudalObject.ParentID].Name) : "")}
| container = {(feudalObject.IsContainer ? "1" : "")}
| movable = {(feudalObject.IsMovableObject ? "1" : "")}
| unmovable = {(feudalObject.IsUnmovableobject ? "1" : "")}
| tool = {(feudalObject.IsTool ? "1" : "")}
| device = {(feudalObject.IsDevice ? "1" : "")}
| maxcontsize = {feudalObject.MaxContSize}
| length = {feudalObject.Length}
| maxstacksize = {feudalObject.MaxStackSize}
| unitweight = {feudalObject.UnitWeight}
| id = {feudalObject.ID}
| parentid = {feudalObject.ParentID}
| craftable = {(recipes.Any() ? "y" : "")}";

            for (int r = 0; r < recipes.Count; r++)
            {
                string lineHeader = $"| r{r + 1}_";
                List<FeudalRecipeRequirement> ingredRequirements = _recipe_requirements.Values.Where(x => x.RecipeID == recipes[r].ID && !_objects_types[x.MaterialObjectTypeID].IsTool && !_objects_types[x.MaterialObjectTypeID].IsDevice).ToList();
                List<FeudalRecipeRequirement> equipRequirements = _recipe_requirements.Values.Where(x => x.RecipeID == recipes[r].ID && (_objects_types[x.MaterialObjectTypeID].IsTool || _objects_types[x.MaterialObjectTypeID].IsDevice)).ToList();
                for (int ir = 0; ir < ingredRequirements.Count; ir++)
                {
                    infobox += $@"{Environment.NewLine}{lineHeader}ingred{ir + 1} = {OnlyFirstLetterCapitalized(_objects_types[ingredRequirements[ir].MaterialObjectTypeID].Name)}
{lineHeader}regional{ir + 1} = {(ingredRequirements[ir].IsRegionItemRequired ? "1" : "")}
{lineHeader}quantity{ir + 1} = {ingredRequirements[ir].Quantity}
{lineHeader}influence{ir + 1} = {ingredRequirements[ir].Influence}";
                }
                for (int er = 0; er < equipRequirements.Count; er++)
                {
                    infobox += $@"{Environment.NewLine}{lineHeader}equip{er + 1} = {OnlyFirstLetterCapitalized(_objects_types[equipRequirements[er].MaterialObjectTypeID].Name)}
{lineHeader}cost{er + 1} = {equipRequirements[er].Quantity}
{lineHeader}impact{er + 1} = {equipRequirements[er].Influence}";
                }
                infobox += $@"{Environment.NewLine}{lineHeader}skill = {OnlyFirstLetterCapitalized(_skill_types[recipes[r].SkillTypeID].Name)}
{lineHeader}minskilllevel = {recipes[r].SkillLvl}
{lineHeader}skilldepends = {recipes[r].SkillDepends}
{lineHeader}blueprint = {(recipes[r].IsBlueprint ? "1" : "")}
{lineHeader}quantity = {recipes[r].Quantity}
{lineHeader}duration = ";
            }

            infobox += $"{Environment.NewLine}}}}}";

            textBox1.Text = infobox;
        }

        private void cmsRightClickBuildingTemplate_Click(object sender, EventArgs e)
        { // http://stackoverflow.com/questions/4886327/determine-what-control-the-contextmenustrip-was-used-on
            DataGridView dgv = (sender as DataGridView);
            if (dgv == null)
                dgv = (((sender as ToolStripItem).Owner as ContextMenuStrip).SourceControl as DataGridView);
            DataGridViewRow currentRow = dgv.CurrentRow;
            if (currentRow == null)
                return;
            FeudalObject feudalObject = (currentRow.DataBoundItem as FeudalObject);
            if (feudalObject == null)
                return;
            
            List<FeudalRecipe> recipes = _recipes.Values.Where(x => x.ResultObjectTypeID == feudalObject.ID).ToList();

            string infobox = $@"{{{{infobox building
| name = {feudalObject.Name}
| image = {feudalObject.FaceImage.Substring(feudalObject.FaceImage.LastIndexOf('\\') + 1)}
| type = {(feudalObject.ParentID != 0 ? OnlyFirstLetterCapitalized(_objects_types[feudalObject.ParentID].Name) : "")}
| door = 
| capacity = {feudalObject.MaxContSize}
| animals = 
| bindingpoints = 
| rallypoints = 
| constructionsize = 
| id = {feudalObject.ID}
| parentid = {feudalObject.ParentID}
| craftable = {(recipes.Any() ? "y" : "")}";

            for (int r = 0; r < recipes.Count; r++)
            {
                string lineHeader = $"| r{r + 1}_";
                List<FeudalRecipeRequirement> ingredRequirements = _recipe_requirements.Values.Where(x => x.RecipeID == recipes[r].ID && !_objects_types[x.MaterialObjectTypeID].IsTool && !_objects_types[x.MaterialObjectTypeID].IsDevice).ToList();
                List<FeudalRecipeRequirement> equipRequirements = _recipe_requirements.Values.Where(x => x.RecipeID == recipes[r].ID && (_objects_types[x.MaterialObjectTypeID].IsTool || _objects_types[x.MaterialObjectTypeID].IsDevice)).ToList();
                for (int ir = 0; ir < ingredRequirements.Count; ir++)
                {
                    infobox += $@"{Environment.NewLine}{lineHeader}ingred{ir + 1} = {OnlyFirstLetterCapitalized(_objects_types[ingredRequirements[ir].MaterialObjectTypeID].Name)}
{lineHeader}regional{ir + 1} = {(ingredRequirements[ir].IsRegionItemRequired ? "1" : "")}
{lineHeader}quantity{ir + 1} = {ingredRequirements[ir].Quantity}
{lineHeader}influence{ir + 1} = {ingredRequirements[ir].Influence}";
                }
                for (int er = 0; er < equipRequirements.Count; er++)
                {
                    infobox += $@"{Environment.NewLine}{lineHeader}equip{er + 1} = {OnlyFirstLetterCapitalized(_objects_types[equipRequirements[er].MaterialObjectTypeID].Name)}
{lineHeader}cost{er + 1} = {equipRequirements[er].Quantity}
{lineHeader}impact{er + 1} = {equipRequirements[er].Influence}";
                }
                infobox += $@"{Environment.NewLine}{lineHeader}skill = {OnlyFirstLetterCapitalized(_skill_types[recipes[r].SkillTypeID].Name)}
{lineHeader}minskilllevel = {recipes[r].SkillLvl}
{lineHeader}skilldepends = {recipes[r].SkillDepends}
{lineHeader}duration = ";
            }

            infobox += $"{Environment.NewLine}}}}}";

            textBox1.Text = infobox;
        }

        #region DataGridView
        private void dgvDatabase_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        { // Override of the DataGridView's normal SortCompare. This version converts some of the fields to numbers before sorting them.
            DataGridView dgv = (sender as DataGridView);
            
            if (e.CellValue1 is string)
            {
                string value1 = (e.CellValue1 ?? "").ToString();
                string value2 = (e.CellValue2 ?? "").ToString();
                e.SortResult = String.Compare(value1, value2);
            }
            else if (e.CellValue1 is int)
            {
                int value1 = (int)e.CellValue1;
                int value2 = (int)e.CellValue2;
                e.SortResult = CompareNumbers(value1, value2);
            }
            else
            {
                // Try to sort based on the cells in the current column as srtings.
                string value1 = (e.CellValue1 ?? "").ToString();
                string value2 = (e.CellValue2 ?? "").ToString();
                e.SortResult = String.Compare(value1, value2);
            }

            e.Handled = true;
        }

        /// <summary>
        /// Makes sure the string has one decimal separated with ".", and then pads the start of the string with spaces (" "s).
        /// </summary>
        private string Normalize(string s, int len)
        {
            s = s.Replace(',', '.');
            if (!s.Contains('.'))
                s += ".00";
            return s.PadLeft(len + 3);
        }

        private int CompareNumbers(string value1, string value2)
        {
            int maxLen = Math.Max(value1.Length, value2.Length);
            value1 = Normalize(value1, maxLen);
            value2 = Normalize(value2, maxLen);
            return String.Compare(value1, value2);
        }

        private int CompareNumbers(double value1, double value2)
        {
            return Math.Sign(value1.CompareTo(value2));
        }

        private int CompareNumbers(int value1, int value2)
        {
            return Math.Sign(value1.CompareTo(value2));
        }
        #endregion

        private string OnlyFirstLetterCapitalized(string s)
        {
            return $"{s.Remove(1).ToUpper()}{s.Substring(1).ToLower()}";
        }
    }
}
