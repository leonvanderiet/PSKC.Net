using System.Xml.Serialization;

namespace PSKC.Net.Xml
{
    public class Key
    {

        [XmlAttribute("Algorithm")]
        public string Algorithm;

        [XmlAttribute("Id")]
        public string Id;

        [XmlElement]
        public AlgorithmParameters AlgorithmParameters;

        [XmlElement]
        public Data Data;

        [XmlElement] 
        public string UserId;

    }

    public class AlgorithmParameters
    {
        [XmlElement]
        public ChallengeFormat ChallengeFormat;
        [XmlElement]
        public ResponseFormat ResponseFormat;
    }

    public class ChallengeFormat
    {

    }

    public class ResponseFormat
    {
        [XmlAttribute]
        public string Encoding;
        [XmlAttribute]
        public string Length;
    }

}