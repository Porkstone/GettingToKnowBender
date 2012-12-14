using System;

namespace GettingToKnowBender
{
    public partial class SecurityCheckCommand
    {
        public Object AccountId { get; set; }
        public Object RequestId { get; set; }
        public SecurityQuestionAnswer FirstSecurityQuestion { get; set; }
        public SecurityQuestionAnswer SecondSecurityQuestion { get; set; }
    }

}
