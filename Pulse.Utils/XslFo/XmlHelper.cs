using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Utils.XslFo
{
    public class XmlHelper
    {
        public static String DeserializeXmlTagsDecoded(String xmlData)
        {
            string noescapedXmlData = xmlData.Replace("&amp;", "&").
                Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", "\"").Replace("&apos;", "'");
            return noescapedXmlData;
        }
    }
}
