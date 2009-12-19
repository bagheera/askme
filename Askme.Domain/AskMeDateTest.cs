using System;
using NUnit.Framework;

namespace Askme.Domain
{
    [TestFixture]
    public class AskMeDateTest
    {
        [Test]
        public void ShouldBeAbleToCreateAskMeDate()
        {
            var askedOn = new DateTime(2009,12,31);
            AskMeDate date = new AskMeDate(askedOn);
            Assert.AreEqual(askedOn, date.Value);
        }
    }
}