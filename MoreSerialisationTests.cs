using System;
using ApprovalTests;
using ApprovalTests.Reporters;
using Bender;
using MbUnit.Framework;

namespace GettingToKnowBender.MoreTests
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class MoreSerialisationTests
    {
        [Test]
        public void SecurityCheckCommandSerialisesCorrectly()
        {
            var accountId = Guid.Parse("d39b24ca-fe17-4fc6-b504-399764d10406");
            var requestId = Guid.Parse("21550455-8a1f-4ca4-bffa-0842bb30fc01");
            var qa = new SecurityQuestionAnswer[1];
            qa[0] = new SecurityQuestionAnswer() { QuestionName = "NameOfFavouriteTeacher", QuestionAnswer = "MrsRobinson" };
            var test = new SecurityCheckCommand() { AccountId = accountId, RequestId = requestId, FirstSecurityQuestion = qa[0] };

            var xml = Serializer.Create(x => x.PrettyPrint()).Serialize(test);
            Approvals.Verify(xml);
        }
    }

    
    public partial class SecurityCheckCommand
    {
        public Object AccountId { get; set; }
        public Object RequestId { get; set; }
        public SecurityQuestionAnswer FirstSecurityQuestion { get; set; }
        public SecurityQuestionAnswer SecondSecurityQuestion { get; set; }
    }

    public partial class SecurityQuestionAnswer 
    {
        public String QuestionName { get; set; }
        public String QuestionAnswer { get; set; }
    }
}
