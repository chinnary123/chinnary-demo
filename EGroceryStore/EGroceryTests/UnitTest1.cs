using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EGroceryTests
{
   
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestF2C()
            {
                double f = 32;
                double c = 0;
                double rvalue = EGroceryTests.Grocery.f2c(f);
                Assert.AreEqual(c, rvalue);
                Assert.AreEqual(100, EGroceryTests.Grocery.f2c(212));
            }
            [TestMethod]
            public void TestC2F()
            {
                Assert.AreEqual(212, EGroceryTests.Grocery.c2f(100));
                Assert.AreEqual(212, EGroceryTests.Grocery.c2f(100));
            }
        }
    }

