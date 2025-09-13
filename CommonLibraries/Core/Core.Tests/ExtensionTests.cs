using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TRW.CommonLibraries.Core.Tests
{
    internal enum TestEnum
    {
        [System.ComponentModel.Description("Default")]
        Default = 0,
        [System.ComponentModel.Description("Next")]
        Next = 1,
        [System.ComponentModel.Description("Enum that skipped a bunch")]
        Skipped = 5,
        [System.ComponentModel.Description("Last enum in the list")]
        Last = 100
    }


    [TestClass]
    public class ExtensionTests : TRW.UnitTesting.UnitTestBase
    {
        [TestMethod]
        public void TestGetEnumValue()
        {
            TestEnum expected = TestEnum.Skipped;

            int target = 5;
            TestEnum result = EnumExtensions.GetEnumValue<TestEnum>(target);

            Assert.AreEqual(expected, result);

            int defaultTarget = 7;
            result = EnumExtensions.GetEnumValue<TestEnum>(defaultTarget);
            Assert.AreEqual(TestEnum.Default, result);

            string stringTarget = "Last";
            result = EnumExtensions.GetEnumValue<TestEnum>(stringTarget);
            Assert.AreEqual(TestEnum.Last, result);
        }

        [TestMethod]
        public void TestGetEnumDescription()
        {
            TestEnum target = TestEnum.Skipped;
            string expected = "Enum that skipped a bunch";

            string result = EnumExtensions.GetDescription(target);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestRandomGetDecimal()
        {
            decimal minExpected = 1;
            decimal maxExpected = 3;
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                decimal result = r.NextDecimal(minExpected, maxExpected);

                Assert.IsTrue(result <= maxExpected);
                Assert.IsTrue(result >= minExpected);
            }
        }

        [TestMethod]
        public void TestRandomGetDecimalNoParams()
        {
            decimal minExpected = -1;
            decimal maxExpected = 1;
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                decimal result = r.NextDecimal();

                Assert.IsTrue(result <= maxExpected);
                Assert.IsTrue(result >= minExpected);
            }
        }

        [TestMethod]
        public void TestGetFactorial()
        {
            AssertFactorial(2, 2);
            AssertFactorial(5, 120);
            AssertFactorial(10, 3628800);
            AssertFactorial(20L, 2432902008176640000);
        }

        private void AssertFactorial(int n, int expected)
        {
            int factorial = (int)n.GetFactorial();
            Assert.AreEqual(expected, factorial);
        }
        private void AssertFactorial(long n, long expected)
        {
            long factorial = n.GetFactorial();
            Assert.AreEqual(expected, factorial);
        }

        [TestMethod]
        public void TestBetween()
        {
            int i = 16;
            int a = 20;
            int b = 30;
            Assert.IsFalse(i.Between(a, b));
            Assert.IsFalse(i.Between(b, a));

            i = 22;
            Assert.IsTrue(i.Between(a, b));
            Assert.IsTrue(i.Between(b, a));

            i = 30;
            Assert.IsTrue(i.Between(a, b));
            Assert.IsFalse(i.Between(a, b, false));

            double da = 30.2;
            double db = 30.1;
            double di = 30;
            Assert.IsFalse(di.Between(da, db));
            Assert.IsFalse(di.Between(db, da));

            di = 30.15;
            Assert.IsTrue(di.Between(da, db));
            Assert.IsTrue(di.Between(db, da));

            di = 30.1;
            Assert.IsTrue(di.Between(da, db));
            Assert.IsFalse(di.Between(da, db, false));

            char ci = 'B';
            char ca = 'A';
            char cb = 'C';
            Assert.IsTrue(ci.Between(ca, cb));
            Assert.IsTrue(ci.Between(cb, ca));

            DateTime ti = new DateTime(2021, 3, 17, 19, 23, 1);
            DateTime ta = new DateTime(2021, 3, 16, 23, 45, 16);
            DateTime tb = new DateTime(2020, 12, 31, 0, 16, 59);
            Assert.IsFalse(ti.Between(ta, tb));
            Assert.IsFalse(ti.Between(tb, ta));

            ti = tb.AddDays(1);
            Assert.IsTrue(ti.Between(ta, tb));
            Assert.IsTrue(ti.Between(tb, ta));
        }

        [TestMethod]
        public void TestIsPowerOfTwo()
        {
            Assert.IsFalse(1.IsPowerOfTwo());
            Assert.IsTrue(2.IsPowerOfTwo());
            Assert.IsTrue(4.IsPowerOfTwo());
            Assert.IsTrue(8.IsPowerOfTwo());
            Assert.IsTrue(16.IsPowerOfTwo());
            Assert.IsTrue(32.IsPowerOfTwo());
            Assert.IsTrue(64.IsPowerOfTwo());
            Assert.IsFalse(3.IsPowerOfTwo());
            Assert.IsFalse(7.IsPowerOfTwo());
            Assert.IsFalse(9.IsPowerOfTwo());
            Assert.IsTrue(1024.IsPowerOfTwo());
        }

        [TestMethod]
        public void TestIsPowerOfTwoPlusOne()
        {
            Assert.IsFalse(1.IsPowerOfTwoPlusOne());
            Assert.IsTrue(3.IsPowerOfTwoPlusOne());
            Assert.IsTrue(5.IsPowerOfTwoPlusOne());
            Assert.IsTrue(9.IsPowerOfTwoPlusOne());
            Assert.IsFalse(2.IsPowerOfTwoPlusOne());
            Assert.IsFalse(4.IsPowerOfTwoPlusOne());
            Assert.IsFalse(6.IsPowerOfTwoPlusOne());
            Assert.IsFalse(8.IsPowerOfTwoPlusOne());
            Assert.IsFalse(16.IsPowerOfTwoPlusOne());
            Assert.IsTrue(2049.IsPowerOfTwoPlusOne());
        }
    }
}
