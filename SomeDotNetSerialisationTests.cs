
using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using ApprovalTests;
using ApprovalTests.Reporters;
using MbUnit.Framework;

namespace GettingToKnowBender
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))] 
    public class SomeDotNetSerialisationTests
    {
        [Test]
        public void SimpleSerialisation()
        {
            var accountId = Guid.Parse("d39b24ca-fe17-4fc6-b504-399764d10406");
            var requestId = Guid.Parse("21550455-8a1f-4ca4-bffa-0842bb30fc01");
            var qa = new MoreTests.SecurityQuestionAnswer[1];
            qa[0] = new MoreTests.SecurityQuestionAnswer() { QuestionName = "NameOfFavouriteTeacher", QuestionAnswer = "MrsRobinson" };
            var test = new MoreTests.SecurityCheckCommand() { AccountId = accountId, RequestId = requestId, FirstSecurityQuestion = qa[0] };

            var sb = new StringBuilder();
            var serializer = new XmlSerializer(test.GetType());
            var settings = new XmlWriterSettings() {OmitXmlDeclaration = true, Indent = true};

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            using (var writer = XmlWriter.Create(sb, settings))
            {
                serializer.Serialize(writer, test, namespaces);
            }

            Approvals.Verify(sb.ToString());
        }
    }
}
