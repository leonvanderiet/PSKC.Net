using System.Xml.Serialization;

namespace PSKC.Net.Xml
{
    public class DeviceInfo
    {
        [XmlElement]
        public string Manufacturer;
        [XmlElement]
        public string SerialNo;
        [XmlElement]
        public string UserId;
    }
}