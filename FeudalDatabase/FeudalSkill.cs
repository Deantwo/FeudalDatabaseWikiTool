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
        private static string _filePath = Path.Combine("data", "skill_types.xml");

        public static Dictionary<int, FeudalSkill> ReadAll(string fullPath)
        {
            fullPath = Path.Combine(fullPath, _filePath);
            if (!File.Exists(fullPath))
                throw new FileNotFoundException("The game XML file could not be found.", fullPath);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fullPath);

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

        public static Dictionary<int, FeudalSkill> ManualList()
        {
            Dictionary<int, FeudalSkill> skillTypes = new Dictionary<int, FeudalSkill>();
            skillTypes.Add(1, new FeudalSkill() { Name = "Artisan", ID = 1 });
            skillTypes.Add(2, new FeudalSkill() { Name = "Mining", ID = 2 });
            skillTypes.Add(3, new FeudalSkill() { Name = "Forging", ID = 3 });
            skillTypes.Add(4, new FeudalSkill() { Name = "Weaponsmithing", ID = 4 });
            skillTypes.Add(5, new FeudalSkill() { Name = "Armorsmithing", ID = 5 });
            skillTypes.Add(6, new FeudalSkill() { Name = "Forestry", ID = 6 });
            skillTypes.Add(7, new FeudalSkill() { Name = "Building Maintain", ID = 7 });
            skillTypes.Add(8, new FeudalSkill() { Name = "Carpentry", ID = 8 });
            skillTypes.Add(9, new FeudalSkill() { Name = "Bowcraft", ID = 9 });
            skillTypes.Add(10, new FeudalSkill() { Name = "Warfare engineering", ID = 10 });
            skillTypes.Add(11, new FeudalSkill() { Name = "Gathering", ID = 11 });
            skillTypes.Add(12, new FeudalSkill() { Name = "Herbalism", ID = 12 });
            skillTypes.Add(13, new FeudalSkill() { Name = "Brewing", ID = 13 });
            skillTypes.Add(14, new FeudalSkill() { Name = "Healing", ID = 14 });
            skillTypes.Add(15, new FeudalSkill() { Name = "Alchemy", ID = 15 });
            skillTypes.Add(16, new FeudalSkill() { Name = "Materials Processing", ID = 16 });
            skillTypes.Add(17, new FeudalSkill() { Name = "Kilning", ID = 17 });
            skillTypes.Add(18, new FeudalSkill() { Name = "Construction", ID = 18 });
            skillTypes.Add(19, new FeudalSkill() { Name = "Masonry", ID = 19 });
            skillTypes.Add(20, new FeudalSkill() { Name = "Architecture", ID = 20 });
            skillTypes.Add(21, new FeudalSkill() { Name = "Farming", ID = 21 });
            skillTypes.Add(22, new FeudalSkill() { Name = "Animal lore", ID = 22 });
            skillTypes.Add(23, new FeudalSkill() { Name = "Procuration", ID = 23 });
            skillTypes.Add(24, new FeudalSkill() { Name = "Cooking", ID = 24 });
            skillTypes.Add(25, new FeudalSkill() { Name = "Tailoring", ID = 25 });
            skillTypes.Add(26, new FeudalSkill() { Name = "Warhorse training", ID = 26 });
            skillTypes.Add(31, new FeudalSkill() { Name = "Precious Prospecting", ID = 31 });
            skillTypes.Add(32, new FeudalSkill() { Name = "Household", ID = 32 });
            skillTypes.Add(48, new FeudalSkill() { Name = "Archer", ID = 48 });
            skillTypes.Add(49, new FeudalSkill() { Name = "Ranger", ID = 49 });
            skillTypes.Add(51, new FeudalSkill() { Name = "Hunting", ID = 51 });
            skillTypes.Add(52, new FeudalSkill() { Name = "Jewelry", ID = 52 });
            skillTypes.Add(53, new FeudalSkill() { Name = "Arts", ID = 53 });
            skillTypes.Add(54, new FeudalSkill() { Name = "Piety", ID = 54 });
            skillTypes.Add(55, new FeudalSkill() { Name = "Mentoring", ID = 55 });
            skillTypes.Add(59, new FeudalSkill() { Name = "Demolition", ID = 59 });
            skillTypes.Add(61, new FeudalSkill() { Name = "Movement", ID = 61 });
            skillTypes.Add(62, new FeudalSkill() { Name = "General actions", ID = 62 });
            skillTypes.Add(63, new FeudalSkill() { Name = "Horseback riding", ID = 63 });
            skillTypes.Add(64, new FeudalSkill() { Name = "Swimming", ID = 64 });
            skillTypes.Add(65, new FeudalSkill() { Name = "Authority", ID = 65 });
            return skillTypes;
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
