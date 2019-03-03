using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FeudalDatabase
{
    public class FeudalRecipeRequirement
    {
        const string FILE_PATH = @"data\recipe_requirement.xml";

        public static Dictionary<int, FeudalRecipeRequirement> ReadAll(string folderPath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Path.Combine(folderPath, FILE_PATH));

            XmlNode tableNode = xmlDoc.SelectSingleNode("/table");

            //// Check if the StarMap is new enough.
            //if (tableNode.Attributes["createDate"] == null)
            //    throw new Exception("XML root node missing reuqired attribute.");

            // Make sure there are actaully any ChildNodes before we continue.
            if (!tableNode.HasChildNodes)
                return null;

            Dictionary<int, FeudalRecipeRequirement> recipe_requirements = new Dictionary<int, FeudalRecipeRequirement>();

            XmlNodeList rowNodeList = tableNode.SelectNodes("row");
            foreach (XmlNode rowNode in rowNodeList)
            {
                // Make sure there are actaully any ChildNodes before we continue.
                if (!rowNode.HasChildNodes)
                    continue;

                FeudalRecipeRequirement recipe_requirement = new FeudalRecipeRequirement();

                XmlNodeList rowChildNodeList = rowNode.ChildNodes;
                foreach (XmlNode rowChildNode in rowChildNodeList)
                {
                    switch (rowChildNode.Name)
                    {
                        case "ID":
                            recipe_requirement.ID = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "RecipeID":
                            recipe_requirement.RecipeID = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "MaterialObjectTypeID":
                            recipe_requirement.MaterialObjectTypeID = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "Quality":
                            recipe_requirement.Quality = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "Influence":
                            recipe_requirement.Influence = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "Quantity":
                            recipe_requirement.Quantity = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "IsRegionItemRequired":
                            recipe_requirement.IsRegionItemRequired = Convert.ToBoolean(Convert.ToInt32(rowChildNode.InnerText));
                            break;
                        default:
                            throw new Exception($"Unknown parameter \"{rowChildNode.Name}\" found in recipe_requirement row.");
                            break;
                    }
                }

                recipe_requirements.Add(recipe_requirement.ID, recipe_requirement);
            }

            return recipe_requirements;
        }
        
        public int ID { get; set; }
        public int RecipeID { get; set; }
        public int MaterialObjectTypeID { get; set; }
        public int Quality { get; set; }
        public int Influence { get; set; }
        public int Quantity { get; set; }
        public bool IsRegionItemRequired { get; set; }
    }
}
