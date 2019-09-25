using System.Collections.Generic;
using System.Xml.Serialization;

namespace PSKC.Net.Xml
{
    [XmlRoot("KeyContainer",Namespace = "urn:ietf:params:xml:ns:keyprov:pskc" )]

    public class KeyContainer
    {
        [XmlElement("KeyPackage")]public List<KeyPackage> KeyPackages;
    }
}