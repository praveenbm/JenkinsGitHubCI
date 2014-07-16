using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace SharepointTestProjForJenkins.Test
{
    [TestFixture]
    public class TestClass
    {
        [TestCase]
        public void AddTest()
        {             
            MathUtility helper = new MathUtility();
            int result = helper.Add(20, 20);
            Assert.AreEqual(30, result);
        }
                
    }
}
