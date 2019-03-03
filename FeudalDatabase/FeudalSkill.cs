using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FeudalDatabase
{
    public class FeudalSkill
    {
        const string FILE_PATH = @"data\skill_types.xml";

        public static Dictionary<int, FeudalSkill> ReadAll(string folderPath)
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

            Dictionary<int, FeudalSkill> skill_types = new Dictionary<int, FeudalSkill>();

            XmlNodeList rowNodeList = tableNode.SelectNodes("row");
            foreach (XmlNode rowNode in rowNodeList)
            {
                // Make sure there are actaully any ChildNodes before we continue.
                if (!rowNode.HasChildNodes)
                    continue;

                FeudalSkill skill_type = new FeudalSkill();

                XmlNodeList rowChildNodeList = rowNode.ChildNodes;
                foreach (XmlNode rowChildNode in rowChildNodeList)
                {
                    switch (rowChildNode.Name)
                    {
                        case "ID":
                            skill_type.ID = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "Name":
                            skill_type.Name = rowChildNode.InnerText;
                            break;
                        case "Parent":
                            skill_type.Parent = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "Group":
                            skill_type.Group = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "PrimaryStat":
                            skill_type.PrimaryStat = rowChildNode.InnerText;
                            break;
                        case "SecondaryStat":
                            skill_type.SecondaryStat = rowChildNode.InnerText;
                            break;
                        case "Icon":
                            skill_type.Icon = rowChildNode.InnerText;
                            break;
                        case "UnknownIcon":
                            skill_type.UnknownIcon = rowChildNode.InnerText;
                            break;
                        case "Passive":
                            skill_type.Passive = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "DescLvl0":
                            skill_type.DescLvl0 = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "DescLvl30":
                            skill_type.DescLvl30 = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "DescLvl60":
                            skill_type.DescLvl60 = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "DescLvl90":
                            skill_type.DescLvl90 = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "DescLvl100":
                            skill_type.DescLvl100 = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "MasterMessageID":
                            skill_type.MasterMessageID = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "GMMessageID":
                            skill_type.GMMessageID = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "skill_mult":
                            skill_type.skill_mult = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "abilities":
                            break;
                        default:
                            throw new Exception($"Unknown parameter \"{rowChildNode.Name}\" found in recipe_requirement row.");
                            break;
                    }
                }

                skill_types.Add(skill_type.ID, skill_type);
            }

            return skill_types;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int Parent { get; set; }
        public int Group { get; set; }
        public string PrimaryStat { get; set; }
        public string SecondaryStat { get; set; }
        public string Icon { get; set; }
        public string UnknownIcon { get; set; }
        public int Passive { get; set; }
        public int DescLvl0 { get; set; }
        public int DescLvl30 { get; set; }
        public int DescLvl60 { get; set; }
        public int DescLvl90 { get; set; }
        public int DescLvl100 { get; set; }
        public int MasterMessageID { get; set; }
        public int GMMessageID { get; set; }
        public int skill_mult { get; set; }
    }
}
