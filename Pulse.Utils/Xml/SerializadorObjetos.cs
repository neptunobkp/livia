using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Pulse.Utils.Exceptions;

namespace Pulse.Utils.Xml
{
    public class SerializadorObjetos
    {

        public static XmlTextReader String2XmlTextReader(string inputXml)
        {
            return new XmlTextReader(new System.IO.StringReader(inputXml));
        }

        private static String UTF8ByteArrayToString(Byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        public static String SerializeObject<T>(Object pObject)
        {
            try
            {
                String XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(T));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                xs.Serialize(xmlTextWriter, pObject);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                return XmlizedString;
            }
            catch (Exception e)
            {
                LoggerManager.LoggerError(e);
                throw new PulseUtilsException("No se ha podido serializar el objeto");
            }
        }

        public static T DeserializeXml2Object<T>(string inputXml)
        {
            try
            {
                if (inputXml.StartsWith("?"))
                    inputXml = inputXml.Remove(0, 1);
                XmlTextReader xmlReader = String2XmlTextReader(inputXml);
                XmlSerializer xs = new XmlSerializer(typeof(T));
                return (T)xs.Deserialize(xmlReader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String TestSerailize<T>(T parametro)
        {
            String parametrosSerializado = SerializeObject<T>(parametro);
            return parametrosSerializado;
        }
    }
}
