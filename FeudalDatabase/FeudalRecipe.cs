using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FeudalDatabase
{
    public class FeudalRecipe
    {
        const string FILE_PATH = @"data\recipe.xml";

        public static Dictionary<int, FeudalRecipe> ReadAll(string folderPath)
        {
            folderPath = Path.Combine(folderPath, FILE_PATH);
            if (!File.Exists(folderPath))
                throw new FileNotFoundException("The game XML file could not be found.", folderPath);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(folderPath);

            XmlNode tableNode = xmlDoc.SelectSingleNode("/table");

            //// Check if the StarMap is new enough.
            //if (tableNode.Attributes["createDate"] == null)
            //    throw new Exception("XML root node missing reuqired attribute.");

            // Make sure there are actaully any ChildNodes before we continue.
            if (!tableNode.HasChildNodes)
                return null;

            Dictionary<int, FeudalRecipe> recipes = new Dictionary<int, FeudalRecipe>();

            XmlNodeList rowNodeList = tableNode.SelectNodes("row");
            foreach (XmlNode rowNode in rowNodeList)
            {
                // Make sure there are actaully any ChildNodes before we continue.
                if (!rowNode.HasChildNodes)
                    continue;

                FeudalRecipe recipe = new FeudalRecipe();

                XmlNodeList rowChildNodeList = rowNode.ChildNodes;
                foreach (XmlNode rowChildNode in rowChildNodeList)
                {
                    switch (rowChildNode.Name)
                    {
                        case "ID":
                            recipe.ID = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "Name":
                            recipe.Name = rowChildNode.InnerText;
                            break;
                        case "Description":
                            recipe.Description = rowChildNode.InnerText;
                            break;
                        case "StartingToolsID":
                            recipe.StartingToolsID = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "SkillTypeID":
                            recipe.SkillTypeID = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "SkillLvl":
                            recipe.SkillLvl = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "ResultObjectTypeID":
                            recipe.ResultObjectTypeID = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "SkillDepends":
                            recipe.SkillDepends = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "Quantity":
                            recipe.Quantity = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "Autorepeat":
                            recipe.Autorepeat = Convert.ToBoolean(Convert.ToInt32(rowChildNode.InnerText));
                            break;
                        case "IsBlueprint":
                            recipe.IsBlueprint = Convert.ToBoolean(Convert.ToInt32(rowChildNode.InnerText));
                            break;
                        case "ImagePath":
                            recipe.ImagePath = rowChildNode.InnerText;
                            break;
                        default:
                            throw new Exception($"Unknown parameter \"{rowChildNode.Name}\" found in recipe row.");
                            break;
                    }
                }

                recipes.Add(recipe.ID, recipe);
            }

            return recipes;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StartingToolsID { get; set; }
        public int SkillTypeID { get; set; }
        public int SkillLvl { get; set; }
        public int ResultObjectTypeID { get; set; }
        public int SkillDepends { get; set; }
        public int Quantity { get; set; }
        public bool Autorepeat { get; set; }
        public bool IsBlueprint { get; set; }
        public string ImagePath { get; set; }
    }
}
