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
        
        [Test]
        public void NowShouldReturnStartOfTimeByDefault()
        {
            Assert.AreEqual(DateTime.MinValue, AskMeDate.CurrentTime);//somewhat iffy but ok
        }

        [Test]
        public void NowShouldChangeAsAssigned()
        {
            DateTime jan2010 = new DateTime(2010,1,1);
            AskMeDate.CurrentTime = new AskMeDate(jan2010);
            Assert.AreEqual(jan2010, AskMeDate.CurrentTime.Value);
        }
    }
}