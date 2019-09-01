using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FeudalDatabase
{
    public class FeudalRecipeTool
    {
        private static string _filePath = Path.Combine("data", "recipe_tool.xml");

        public static Dictionary<int, FeudalRecipeTool> ReadAll(string fullPath)
        {
            fullPath = Path.Combine(fullPath, _filePath);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fullPath);

            XmlNode tableNode = xmlDoc.SelectSingleNode("/table");

            // Make sure there are actaully any ChildNodes before we continue.
            if (tableNode == null || !tableNode.HasChildNodes)
                throw new Exception($"XML node \"/table\" not found.");

            Dictionary<int, FeudalRecipeTool> recipe_tools = new Dictionary<int, FeudalRecipeTool>();

            XmlNodeList rowNodeList = tableNode.SelectNodes("row");
            foreach (XmlNode rowNode in rowNodeList)
            {
                // Make sure there are actaully any ChildNodes before we continue.
                if (!rowNode.HasChildNodes)
                    continue;

                FeudalRecipeTool recipe_requirement = new FeudalRecipeTool();

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
                        case "StartingToolID":
                            recipe_requirement.StartingToolID = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        default:
                            throw new Exception($"Unknown parameter \"{rowChildNode.Name}\" found in recipe_tools row.");
                            break;
                    }
                }

                recipe_tools.Add(recipe_requirement.ID, recipe_requirement);
            }

            return recipe_tools;
        }
        
        public int ID { get; set; }
        public int RecipeID { get; set; }
        public int StartingToolID { get; set; }
    }
}
