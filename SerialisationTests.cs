using System;
using System.Xml.Serialization;
using ApprovalTests.Reporters;
using MbUnit.Framework;
using Bender;
using ApprovalTests;

namespace GettingToKnowBender
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))] 
    public class SerialisationTests
    {
        [Test]
        public void MbUnitIsWorking()
        {
            Assert.AreEqual(1, 1);
        }

        [Test]
        public void SecurityCheckCommandSerialisesCorrectly()
        {
            var accountId = Guid.Parse("d39b24ca-fe17-4fc6-b504-399764d10406");
            var requestId = Guid.Parse("21550455-8a1f-4ca4-bffa-0842bb30fc01");
            var qa = new SecurityQuestionAnswer[1];
            qa[0] = new SecurityQuestionAnswer() { QuestionName = "NameOfFavouriteTeacher", QuestionAnswer = "MrsRobinson" };
            var test = new SecurityCheckCommand() { AccountId = accountId, RequestId = requestId, QuestionAnswers = qa };

            var xml = Serializer.Create(x => x.PrettyPrint()).Serialize(test);
            Approvals.Verify(xml);
        }

        [Test]
        public void SecurityQuestionAnswerSerialisesCorrectly()
        {
            var test = new SecurityQuestionAnswer() {QuestionName = "NameOfFavouriteTeacher", QuestionAnswer = "MrsRobinson"};

            var xml = Serializer.Create(x => x.PrettyPrint()).Serialize(test);
            Approvals.Verify(xml);
        }
    }

      public class SecurityCheckCommand 
      {
          public Guid AccountId { get; set; }
          public Guid RequestId { get; set; }
          public SecurityQuestionAnswer[] QuestionAnswers { get; set; }
      }

      public class SecurityQuestionAnswer 
      {
          public String QuestionName { get; set; }
          public String QuestionAnswer { get; set; }
      }
}
