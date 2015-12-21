using Soundex;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Soundex.Tests
{
    /// <summary>
    ///This is a test class for Soundex and is intended
    ///to contain all Soundex Unit Tests
    ///</summary>
    [TestClass]
    public class SoundexTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        /// A test for the Soundex.For method. Runs a series of words through
        /// Soundex.For and asserts that their output is correct.
        ///</summary>
        [TestMethod]
        public void ForTests()
        {
            Soundex soundex = new Soundex();
            string word, expected, actual;

            word = "";
            expected = "0000";
            actual = soundex.For(word);
            Assert.AreEqual(expected, actual);

            word = null;
            expected = "0000";
            actual = soundex.For(word);
            Assert.AreEqual(expected, actual);

            word = "Robert";
            expected = "R163";
            actual = soundex.For(word);
            Assert.AreEqual(expected, actual);

            word = "Rupert".ToLower();
            actual = soundex.For(word);
            Assert.AreEqual(expected, actual);

            word = "Rubin";
            expected = "R150";
            actual = soundex.For(word);
            Assert.AreEqual(expected, actual);

            word = "Ashcraft";
            expected = "A261";
            actual = soundex.For(word);
            Assert.AreEqual(expected, actual);

            word = "Ashcroft";
            actual = soundex.For(word);
            Assert.AreEqual(expected, actual);

            word = "Tymczak";
            expected = "T522";
            actual = soundex.For(word);
            Assert.AreEqual(expected, actual);

            word = "Pfister";
            expected = "P236";
            actual = soundex.For(word);
            Assert.AreEqual(expected, actual);
        }
    }
}