using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Rwd.Framework.XML
{
    public class XMLSerializationHelper
    {

        public class XmlSerializationHelper
        {
            public static void Serialize<T>(string filename, T obj)
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                using (StreamWriter wr = new StreamWriter(filename))
                {
                    xs.Serialize(wr, obj);
                }
            }

            public static T Deserialize<T>(string filename)
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                using (StreamReader rd = new StreamReader(filename))
                {
                    return (T)xs.Deserialize(rd);
                }
            }
        } 


    }
}
