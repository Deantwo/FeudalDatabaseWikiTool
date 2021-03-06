﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FeudalDatabase
{
    public class FeudalObject
    {
        private static string _filePath = Path.Combine("data", "objects_types.xml");

        public static Dictionary<int, FeudalObject> ReadAll(string fullPath)
        {
            fullPath = Path.Combine(fullPath, _filePath);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fullPath);

            XmlNode tableNode = xmlDoc.SelectSingleNode("/table");

            // Make sure there are actaully any ChildNodes before we continue.
            if (tableNode == null || !tableNode.HasChildNodes)
                throw new Exception($"XML node \"/table\" not found.");

            Dictionary<int, FeudalObject> objects_types = new Dictionary<int, FeudalObject>();

            XmlNodeList rowNodeList = tableNode.SelectNodes("row");
            foreach (XmlNode rowNode in rowNodeList)
            {
                // Make sure there are actaully any ChildNodes before we continue.
                if (!rowNode.HasChildNodes)
                    continue;

                FeudalObject objects_type = new FeudalObject();

                XmlNodeList rowChildNodeList = rowNode.ChildNodes;
                foreach (XmlNode rowChildNode in rowChildNodeList)
                {
                    switch (rowChildNode.Name)
                    {
                        case "ID":
                            objects_type.ID = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "ParentID":
                            objects_type.ParentID = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "Name":
                            objects_type.Name = rowChildNode.InnerText;
                            break;
                        case "IsContainer":
                            objects_type.IsContainer = Convert.ToBoolean(Convert.ToInt32(rowChildNode.InnerText));
                            break;
                        case "IsMovableObject":
                            objects_type.IsMovableObject = Convert.ToBoolean(Convert.ToInt32(rowChildNode.InnerText));
                            break;
                        case "IsUnmovableobject":
                            objects_type.IsUnmovableobject = Convert.ToBoolean(Convert.ToInt32(rowChildNode.InnerText));
                            break;
                        case "IsTool":
                            objects_type.IsTool = Convert.ToBoolean(Convert.ToInt32(rowChildNode.InnerText));
                            break;
                        case "IsDevice":
                            objects_type.IsDevice = Convert.ToBoolean(Convert.ToInt32(rowChildNode.InnerText));
                            break;
                        case "IsDoor":
                            objects_type.IsDoor = Convert.ToBoolean(Convert.ToInt32(rowChildNode.InnerText));
                            break;
                        case "IsPremium":
                            objects_type.IsPremium = Convert.ToBoolean(Convert.ToInt32(rowChildNode.InnerText));
                            break;
                        case "MaxContSize":
                            objects_type.MaxContSize = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "Length":
                            objects_type.Length = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "MaxStackSize":
                            objects_type.MaxStackSize = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "UnitWeight":
                            objects_type.UnitWeight = Convert.ToInt32(rowChildNode.InnerText);
                            break;
                        case "BackgndImage":
                            objects_type.BackgndImage = rowChildNode.InnerText;
                            break;
                        case "FaceImage":
                            objects_type.FaceImage = rowChildNode.InnerText;
                            break;
                        case "CensoredFaceImage": // Only seen in MMO files.
                            //objects_type.CensoredFaceImage = rowChildNode.InnerText;
                            break;
                        case "Description":
                            objects_type.Description = rowChildNode.InnerText;
                            break;
                        default:
                            throw new Exception($"Unknown parameter \"{rowChildNode.Name}\" found in objects_types row.");
                            break;
                    }
                }

                objects_types.Add(objects_type.ID, objects_type);
            }

            return objects_types;
        }

        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public bool IsContainer { get; set; }
        public bool IsMovableObject { get; set; }
        public bool IsUnmovableobject { get; set; }
        public bool IsTool { get; set; }
        public bool IsDevice { get; set; }
        public bool IsDoor { get; set; }
        public bool IsPremium { get; set; }
        public int MaxContSize { get; set; }
        public int Length { get; set; }
        public int MaxStackSize { get; set; }
        public int UnitWeight { get; set; }
        public string BackgndImage { get; set; }
        public string FaceImage { get; set; }
        public string Description { get; set; }
    }
}
