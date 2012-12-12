using System;
using System.Xml.Serialization;
using MbUnit.Framework;
using Bender;

namespace GettingToKnowBender
{
    [TestFixture]
    public class SerialisationTests
    {
        [Test]
        public void MbUnitIsWorking()
        {
            Assert.AreEqual(1, 1);
        }

        [Test]
        public void SecurityCheckCommandDeserialisesCorrectly()
        {
            var accountId = Guid.Parse("d39b24ca-fe17-4fc6-b504-399764d10406");
            var requestId = Guid.Parse("21550455-8a1f-4ca4-bffa-0842bb30fc01");
            var qa = new SecurityQuestionAnswer[1];
            qa[0] = new SecurityQuestionAnswer() { QuestionName = "NameOfFavouriteTeacher", QuestionAnswer = "MrsRobinson" };
            var test = new SecurityCheckCommand() { AccountId = accountId, RequestId = requestId, QuestionAnswers = qa };

            var xml = "<SecurityCheck><AccountId>d39b24ca-fe17-4fc6-b504-399764d10406</AccountId><RequestId>21550455-8a1f-4ca4-bffa-0842bb30fc01</RequestId><QuestionAnswers>";
            xml += "<SecurityQuestionAnswer><QuestionName xsi:type=\"xsd:string\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">NameOfFavouriteTeacher</QuestionName>";
            xml += "<QuestionAnswer xsi:type=\"xsd:string\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">MrsRobinson</QuestionAnswer></SecurityQuestionAnswer></QuestionAnswers></SecurityCheck>";

            var test3 = Serializer.Create(x => x.PrettyPrint()).Serialize(test);
            Assert.AreEqual(xml, test3);
        }
    }

      [XmlRoot("SecurityCheck")]
      public class SecurityCheckCommand 
      {
          public Object AccountId { get; set; }
          public Object RequestId { get; set; }
          public SecurityQuestionAnswer[] QuestionAnswers { get; set; }
      }

      public class SecurityQuestionAnswer 
      {
          public Object QuestionName { get; set; }
          public Object QuestionAnswer { get; set; }
      }
}
