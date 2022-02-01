using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringExtension.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension.Extensions.Tests
{
    [TestClass()]
    public class AToZExtensionTests
    {
        [TestMethod()]
        public void ChangeAToZIgnoreCapitalsTest()
        {
            string testStr = "aZzAabcdAb";
            string expectedStr = "zZzZzbcdZb";
            var result = testStr.ChangeAToZ(Enums.LetterTypeEnum.LetterType.IgnoreCapitals);
            
            Assert.AreEqual(expectedStr, result);
        }

        [TestMethod()]
        public void ChangeAToZAcceptCapitalsTest()
        {
            string testStr = "aZzAabcdAb";
            string expectedStr = "zZzAzbcdAb";
            var result = testStr.ChangeAToZ(Enums.LetterTypeEnum.LetterType.AcceptCapitals);
            
            Assert.AreEqual(expectedStr, result);
        }
    }
}