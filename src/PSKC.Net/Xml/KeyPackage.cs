using System.Xml.Serialization;

namespace PSKC.Net.Xml
{
    public class KeyPackage
    {
        public DeviceInfo DeviceInfo;
        [XmlElement("Key")]
        public Key Key;
    }
}
