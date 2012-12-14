using System;

namespace GettingToKnowBender
{
    public class SecurityCheckArrayCommand
    {
        public Guid AccountId { get; set; }
        public Guid RequestId { get; set; }
        public SecurityQuestionAnswer[] QuestionAnswers { get; set; }
    }
}
