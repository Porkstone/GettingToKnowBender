using System;
using System.Xml.Serialization;

namespace GettingToKnowBender
{
    public partial class SecurityCheckCommand
    {
        [XmlElement(Type = typeof(Guid))]
        public Object AccountId { get; set; }
        [XmlElement(Type = typeof(Guid))]
        public Object RequestId { get; set; }
        public SecurityQuestionAnswer FirstSecurityQuestion { get; set; }
        public SecurityQuestionAnswer SecondSecurityQuestion { get; set; }
    }

}
