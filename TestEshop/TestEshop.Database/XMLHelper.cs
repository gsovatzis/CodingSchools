using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestEshop.Database
{
   public static class XMLHelper
   {
      public static QueryDefinition getDescriptor(string xmlFile)
      {
         // Open XML file and read the Query definitions
         XmlSerializer serializer = new XmlSerializer(typeof(QueryDefinition));
         FileStream fs = new FileStream(xmlFile, FileMode.Open);
         QueryDefinition result = (QueryDefinition)serializer.Deserialize(fs);
         fs.Close();

         return result;
      }
   }
}
