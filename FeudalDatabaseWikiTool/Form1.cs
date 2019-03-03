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
        private string _folderGame;
        Dictionary<int, FeudalSkill> _skill_types;
        Dictionary<int, FeudalObject> _objects_types;
        Dictionary<int, FeudalRecipe> _recipes;
        Dictionary<int, FeudalRecipeRequirement> _recipe_requirements;

        public Form1()
        {
            InitializeComponent();

#if SkillXmlBroken
            _skill_types = new Dictionary<int, FeudalSkill>();
            _skill_types.Add(1, new FeudalSkill() { Name = "Artisan", ID = 1 });
            _skill_types.Add(2, new FeudalSkill() { Name = "Mining", ID = 2 });
            _skill_types.Add(3, new FeudalSkill() { Name = "Forging", ID = 3 });
            _skill_types.Add(4, new FeudalSkill() { Name = "Weaponsmithing", ID = 4 });
            _skill_types.Add(5, new FeudalSkill() { Name = "Armorsmithing", ID = 5 });
            _skill_types.Add(6, new FeudalSkill() { Name = "Forestry", ID = 6 });
            _skill_types.Add(7, new FeudalSkill() { Name = "Building Maintain", ID = 7 });
            _skill_types.Add(8, new FeudalSkill() { Name = "Carpentry", ID = 8 });
            _skill_types.Add(9, new FeudalSkill() { Name = "Bowcraft", ID = 9 });
            _skill_types.Add(10, new FeudalSkill() { Name = "Warfare engineering", ID = 10 });
            _skill_types.Add(11, new FeudalSkill() { Name = "Gathering", ID = 11 });
            _skill_types.Add(12, new FeudalSkill() { Name = "Herbalism", ID = 12 });
            _skill_types.Add(13, new FeudalSkill() { Name = "Brewing", ID = 13 });
            _skill_types.Add(14, new FeudalSkill() { Name = "Healing", ID = 14 });
            _skill_types.Add(15, new FeudalSkill() { Name = "Alchemy", ID = 15 });
            _skill_types.Add(16, new FeudalSkill() { Name = "Materials Processing", ID = 16 });
            _skill_types.Add(17, new FeudalSkill() { Name = "Kilning", ID = 17 });
            _skill_types.Add(18, new FeudalSkill() { Name = "Construction", ID = 18 });
            _skill_types.Add(19, new FeudalSkill() { Name = "Masonry", ID = 19 });
            _skill_types.Add(20, new FeudalSkill() { Name = "Architecture", ID = 20 });
            _skill_types.Add(21, new FeudalSkill() { Name = "Farming", ID = 21 });
            _skill_types.Add(22, new FeudalSkill() { Name = "Animal lore", ID = 22 });
            _skill_types.Add(23, new FeudalSkill() { Name = "Procuration", ID = 23 });
            _skill_types.Add(24, new FeudalSkill() { Name = "Cooking", ID = 24 });
            _skill_types.Add(25, new FeudalSkill() { Name = "Tailoring", ID = 25 });
            _skill_types.Add(26, new FeudalSkill() { Name = "Warhorse training", ID = 26 });
            _skill_types.Add(31, new FeudalSkill() { Name = "Precious Prospecting", ID = 31 });
            _skill_types.Add(32, new FeudalSkill() { Name = "Household", ID = 32 });
            _skill_types.Add(48, new FeudalSkill() { Name = "Archer", ID = 48 });
            _skill_types.Add(49, new FeudalSkill() { Name = "Ranger", ID = 49 });
            _skill_types.Add(51, new FeudalSkill() { Name = "Hunting", ID = 51 });
            _skill_types.Add(52, new FeudalSkill() { Name = "Jewelry", ID = 52 });
            _skill_types.Add(53, new FeudalSkill() { Name = "Arts", ID = 53 });
            _skill_types.Add(54, new FeudalSkill() { Name = "Piety", ID = 54 });
            _skill_types.Add(55, new FeudalSkill() { Name = "Mentoring", ID = 55 });
            _skill_types.Add(59, new FeudalSkill() { Name = "Demolition", ID = 59 });
            _skill_types.Add(61, new FeudalSkill() { Name = "Movement", ID = 61 });
            _skill_types.Add(62, new FeudalSkill() { Name = "General actions", ID = 62 });
            _skill_types.Add(63, new FeudalSkill() { Name = "Horseback riding", ID = 63 });
            _skill_types.Add(64, new FeudalSkill() { Name = "Swimming", ID = 64 });
            _skill_types.Add(65, new FeudalSkill() { Name = "Authority", ID = 65 });
#else
#endif
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
#if GameFolderSelector
            DialogResult result = folderBrowserDialog1.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            _folderGame = folderBrowserDialog1.SelectedPath;
#else
            _folderGame = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Life is Feudal MMO", "game", "eu");
#endif
            lblBrowsePath.Text = _folderGame;

#if !SkillXmlBroken
            _skill_types = FeudalSkill.ReadAll(_folderGame);
#endif
            _objects_types = FeudalObject.ReadAll(_folderGame);
            _recipes = FeudalRecipe.ReadAll(_folderGame);
            _recipe_requirements = FeudalRecipeRequirement.ReadAll(_folderGame);

            List<FeudalObject> testlist = new List<FeudalObject>();
            foreach (FeudalObject objects_type in _objects_types.Values)
            {
                testlist.Add(objects_type);

                //IEnumerable<FeudalRecipe> matching_recipes = recipes.Values.Where(x => x.ResultObjectTypeID == objects_type.ID);
                //foreach (FeudalRecipe matching_recipe in matching_recipes)
                //{
                //    TreeNode ctn = tn.Nodes.Add(matching_recipe.ID.ToString(), matching_recipe.Name);
                //
                //    IEnumerable<FeudalRecipeRequirement> matching_recipe_requirements = recipe_requirements.Values.Where(x => x.RecipeID == matching_recipe.ID);
                //    foreach (FeudalRecipeRequirement matching_recipe_requirement in matching_recipe_requirements)
                //    {
                //        string requirement = $"{matching_recipe_requirement.Quantity} x {objects_types[matching_recipe_requirement.MaterialObjectTypeID].Name}";
                //        if (matching_recipe_requirement.IsRegionItemRequired)
                //            requirement += $" (Regional)";
                //        ctn.Nodes.Add(matching_recipe_requirement.ID.ToString(), requirement);
                //    }
                //}
            }

            dgvDatabase.DataSource = testlist;
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
| capacity = 
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
