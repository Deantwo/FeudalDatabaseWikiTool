using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FeudalDatabase
{
    public class FeudalObjectDescription
    {
        private static string _filePath = Path.Combine("data", "objects_types_Description.xml");

        public static Dictionary<int, FeudalObjectDescription> ReadAll(string fullPath)
        {
            fullPath = Path.Combine(fullPath, _filePath);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fullPath);

            XmlNode stringsNode = xmlDoc.SelectSingleNode("/root/strings");

            // Make sure there are actaully any ChildNodes before we continue.
            if (stringsNode == null || !stringsNode.HasChildNodes)
                throw new Exception($"XML node \"/root/strings\" not found.");

            Dictionary<int, FeudalObjectDescription> object_type_descriptions = new Dictionary<int, FeudalObjectDescription>();

            XmlNodeList rowNodeList = stringsNode.SelectNodes("string");
            foreach (XmlNode rowNode in rowNodeList)
            {
                FeudalObjectDescription object_type_description = new FeudalObjectDescription();

                object_type_description.ID = Convert.ToInt32(rowNode.Attributes["id"].InnerText);
                object_type_description.Text = rowNode.InnerText;

                object_type_descriptions.Add(object_type_description.ID, object_type_description);
            }

            return object_type_descriptions;
        }

        public int ID { get; set; }
        public string Text { get; set; }
    }
}
