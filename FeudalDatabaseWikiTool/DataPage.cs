using FeudalDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeudalDatabaseWikiTool
{
    internal static class DataPages
    {
        private static IEnumerable<FeudalRecipeRequirement> feudalRecipeTools;

        private static string JsonFormat(string s)
        {
            if (string.IsNullOrEmpty(s))
                return "{}";
            else
                return $"'{s.Trim().Replace("\\", "\\\\").Replace("\'", "\\\'")}'";
        }
        private static string JsonFormat(int i)
        {
            return $"'{i}'";
        }
        private static string JsonFormat(bool b)
        {
            if (b)
                return "'1'";
            else
                return "'0'";
        }

        internal static string CreateSkills(ICollection<FeudalSkill> feudalSkills)
        {
            StringBuilder sb = new StringBuilder();

            foreach (FeudalSkill feudalSkill in feudalSkills)
            {
                if (sb.Length == 0)
                {
                    sb.AppendLine("return {");
                    sb.AppendLine("\t{");
                }
                else
                {
                    sb.AppendLine("\t},");
                    sb.AppendLine("\t{");
                }

                sb.AppendLine($"\t\tID = {JsonFormat(feudalSkill.ID)},");
                sb.AppendLine($"\t\tName = {JsonFormat(feudalSkill.Name)},");
                sb.AppendLine($"\t\tParent = {JsonFormat(feudalSkill.Parent)},");
                sb.AppendLine($"\t\tGroup = {JsonFormat(feudalSkill.Group)},");
                sb.AppendLine($"\t\tPrimaryStat = {JsonFormat(feudalSkill.PrimaryStat)},");
                sb.AppendLine($"\t\tSecondaryStat = {JsonFormat(feudalSkill.SecondaryStat)},");
                sb.AppendLine($"\t\tIcon = {JsonFormat(feudalSkill.Icon)},");
                sb.AppendLine($"\t\tPassive = {JsonFormat(feudalSkill.Passive)},");
                sb.AppendLine($"\t\tDescLvl0 = {JsonFormat(feudalSkill.DescLvl0)},");
                sb.AppendLine($"\t\tDescLvl30 = {JsonFormat(feudalSkill.DescLvl30)},");
                sb.AppendLine($"\t\tDescLvl60 = {JsonFormat(feudalSkill.DescLvl60)},");
                sb.AppendLine($"\t\tDescLvl90 = {JsonFormat(feudalSkill.DescLvl90)},");
                sb.AppendLine($"\t\tDescLvl100 = {JsonFormat(feudalSkill.DescLvl100)},");
                sb.AppendLine($"\t\tMasterMessageID = {JsonFormat(feudalSkill.MasterMessageID)},");
                sb.AppendLine($"\t\tGMMessageID = {JsonFormat(feudalSkill.GMMessageID)},");
                sb.AppendLine($"\t\tskill_mult = {JsonFormat(feudalSkill.skill_mult)},");
                sb.AppendLine($"\t\tExpToSkillMult = {JsonFormat(feudalSkill.ExpToSkillMult)}");
            }

            sb.AppendLine("\t}");
            sb.AppendLine("}");
            return sb.ToString();
        }

        internal static string CreateObjects(ICollection<FeudalObject> feudalObjects)
        {
            StringBuilder sb = new StringBuilder();

            foreach (FeudalObject feudalObject in feudalObjects)
            {
                if (sb.Length == 0)
                {
                    sb.AppendLine("return {");
                    sb.AppendLine("\t{");
                }
                else
                {
                    sb.AppendLine("\t},");
                    sb.AppendLine("\t{");
                }

                sb.AppendLine($"\t\tID = {JsonFormat(feudalObject.ID)},");
                sb.AppendLine($"\t\tParentID = {JsonFormat(feudalObject.ParentID)},");
                sb.AppendLine($"\t\tName = {JsonFormat(feudalObject.Name)},");
                sb.AppendLine($"\t\tIsContainer = {JsonFormat(feudalObject.IsContainer)},");
                sb.AppendLine($"\t\tIsMovableObject = {JsonFormat(feudalObject.IsMovableObject)},");
                sb.AppendLine($"\t\tIsUnmovableobject = {JsonFormat(feudalObject.IsUnmovableobject)},");
                sb.AppendLine($"\t\tIsTool = {JsonFormat(feudalObject.IsTool)},");
                sb.AppendLine($"\t\tIsDevice = {JsonFormat(feudalObject.IsDevice)},");
                sb.AppendLine($"\t\tIsDoor = {JsonFormat(feudalObject.IsDoor)},");
                sb.AppendLine($"\t\tIsPremium = {JsonFormat(feudalObject.IsPremium)},");
                sb.AppendLine($"\t\tMaxContSize = {JsonFormat(feudalObject.MaxContSize)},");
                sb.AppendLine($"\t\tLength = {JsonFormat(feudalObject.Length)},");
                sb.AppendLine($"\t\tMaxStackSize = {JsonFormat(feudalObject.MaxStackSize)},");
                sb.AppendLine($"\t\tUnitWeight = {JsonFormat(feudalObject.UnitWeight)},");
                sb.AppendLine($"\t\tBackgndImage = {JsonFormat(feudalObject.BackgndImage)},");
                sb.AppendLine($"\t\tFaceImage = {JsonFormat(feudalObject.FaceImage)},");
                sb.AppendLine($"\t\tDescription = {JsonFormat(feudalObject.Description)}");
            }

            sb.AppendLine("\t}");
            sb.AppendLine("}");
            return sb.ToString();
        }

        internal static string CreateObjectDescriptions(ICollection<FeudalObjectDescription> feudalObjectDescriptions)
        {
            StringBuilder sb = new StringBuilder();

            foreach (FeudalObjectDescription feudalObjectDescription in feudalObjectDescriptions)
            {
                if (sb.Length == 0)
                {
                    sb.AppendLine("return {");
                    sb.AppendLine("\t{");
                }
                else
                {
                    sb.AppendLine("\t},");
                    sb.AppendLine("\t{");
                }

                sb.AppendLine($"\t\tID = {JsonFormat(feudalObjectDescription.ID)},");
                sb.AppendLine($"\t\tText = {JsonFormat(feudalObjectDescription.Text)}");
            }

            sb.AppendLine("\t}");
            sb.AppendLine("}");
            return sb.ToString();
        }

        internal static string CreateRecipes(ICollection<FeudalRecipe> feudalRecipes)
        {
            StringBuilder sb = new StringBuilder();

            foreach (FeudalRecipe feudalRecipe in feudalRecipes)
            {
                if (sb.Length == 0)
                {
                    sb.AppendLine("return {");
                    sb.AppendLine("\t{");
                }
                else
                {
                    sb.AppendLine("\t},");
                    sb.AppendLine("\t{");
                }

                sb.AppendLine($"\t\tID = {JsonFormat(feudalRecipe.ID)},");
                sb.AppendLine($"\t\tName = {JsonFormat(feudalRecipe.Name)},");
                sb.AppendLine($"\t\tDescription = {JsonFormat(feudalRecipe.Description)},");
                sb.AppendLine($"\t\tStartingToolsID = {JsonFormat(feudalRecipe.StartingToolsID)},");
                sb.AppendLine($"\t\tSkillTypeID = {JsonFormat(feudalRecipe.SkillTypeID)},");
                sb.AppendLine($"\t\tSkillLvl = {JsonFormat(feudalRecipe.SkillLvl)},");
                sb.AppendLine($"\t\tResultObjectTypeID = {JsonFormat(feudalRecipe.ResultObjectTypeID)},");
                sb.AppendLine($"\t\tSkillDepends = {JsonFormat(feudalRecipe.SkillDepends)},");
                sb.AppendLine($"\t\tQuantity = {JsonFormat(feudalRecipe.Quantity)},");
                sb.AppendLine($"\t\tAutorepeat = {JsonFormat(feudalRecipe.Autorepeat)},");
                sb.AppendLine($"\t\tIsBlueprint = {JsonFormat(feudalRecipe.IsBlueprint)},");
                sb.AppendLine($"\t\tImagePath = {JsonFormat(feudalRecipe.ImagePath)}");
            }

            sb.AppendLine("\t}");
            sb.AppendLine("}");
            return sb.ToString();
        }

        internal static string CreateRecipeRequirements(ICollection<FeudalRecipeRequirement> feudalRecipeRequirements)
        {
            StringBuilder sb = new StringBuilder();

            foreach (FeudalRecipeRequirement feudalRecipeRequirement in feudalRecipeRequirements)
            {
                if (sb.Length == 0)
                {
                    sb.AppendLine("return {");
                    sb.AppendLine("\t{");
                }
                else
                {
                    sb.AppendLine("\t},");
                    sb.AppendLine("\t{");
                }

                sb.AppendLine($"\t\tID = {JsonFormat(feudalRecipeRequirement.ID)},");
                sb.AppendLine($"\t\tRecipeID = {JsonFormat(feudalRecipeRequirement.RecipeID)},");
                sb.AppendLine($"\t\tMaterialObjectTypeID = {JsonFormat(feudalRecipeRequirement.MaterialObjectTypeID)},");
                sb.AppendLine($"\t\tQuality = {JsonFormat(feudalRecipeRequirement.Quality)},");
                sb.AppendLine($"\t\tInfluence = {JsonFormat(feudalRecipeRequirement.Influence)},");
                sb.AppendLine($"\t\tQuantity = {JsonFormat(feudalRecipeRequirement.Quantity)},");
                sb.AppendLine($"\t\tIsRegionItemRequired = {JsonFormat(feudalRecipeRequirement.IsRegionItemRequired)}");
            }

            sb.AppendLine("\t}");
            sb.AppendLine("}");
            return sb.ToString();
        }

        internal static string CreateRecipeTools(Dictionary<int, FeudalRecipeTool>.ValueCollection feudalRecipeTools)
        {
            StringBuilder sb = new StringBuilder();

            foreach (FeudalRecipeTool feudalRecipeTool in feudalRecipeTools)
            {
                if (sb.Length == 0)
                {
                    sb.AppendLine("return {");
                    sb.AppendLine("\t{");
                }
                else
                {
                    sb.AppendLine("\t},");
                    sb.AppendLine("\t{");
                }

                sb.AppendLine($"\t\tID = {JsonFormat(feudalRecipeTool.ID)},");
                sb.AppendLine($"\t\tRecipeID = {JsonFormat(feudalRecipeTool.RecipeID)},");
                sb.AppendLine($"\t\tStartingToolID = {JsonFormat(feudalRecipeTool.StartingToolID)}");
            }

            sb.AppendLine("\t}");
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
