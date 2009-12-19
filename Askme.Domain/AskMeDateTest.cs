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
        public void NowShouldReturnCurrentTimeByDefault()
        {
            Assert.AreEqual(DateTime.Now,AskMeDate.Now);//somewhat iffy but ok
        }

        [Test]
        public void NowShouldChangeAsAssigned()
        {
            DateTime jan2010 = new DateTime(2010,1,1);
            AskMeDate.Now = jan2010;
            Assert.AreEqual(jan2010, AskMeDate.Now);
        }
    }
}