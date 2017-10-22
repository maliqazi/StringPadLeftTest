//**************************************************
//
// This test suite for test the overlaods for String.PadLeft methods
// The test focuses on the texture of the strings and not
//     necessarily the logic for calculating the padding. That
//     is why we compare returned string directly to the expected value
//
//  
//
//****************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace StringPadTest
{
    [TestClass]
    public class StringPadTest1
    {
        [TestInitialize]
        public void setup()
        {
            //not needed
        }

        [TestCleanup]
        public void breakdown()
        {
            //not needed        
        }

        // TestMethod1 tests a basic happy scenario
        //  10 spaces should be added on the left of the string
        [TestMethod]
        public void TestMethod1()
        {
            String testString = "Pathmatics";  // The test string to be padded
            Int32 paddingCount = 20;   // Parameter value to call .PadLeft

            string expectedValue = "          Pathmatics";
            string actualValue = testString.PadLeft(paddingCount);

            // Compare
            Assert.AreEqual(expectedValue, actualValue);


        }

        // TestMethod2 tests behavior if value of padding is less than string's length
        //  No spaces should be added
        [TestMethod]
        public void TestMethod2() 
        {
            String testString = "Pathmatics";  // The test string to be padded
            Int32 paddingCount = 5;   // Parameter value to call .PadLeft

            string expectedValue = "Pathmatics";
            string actualValue = testString.PadLeft(paddingCount);

            // Compare
            Assert.AreEqual(expectedValue, actualValue);

        }

        //TestMethod3 tests for negative value of padding 
        //  Out of Range exception should be captured
        [TestMethod]
        public void TestMethod3()
        {
            string testString = "Pathmatics";  // The test string to be padded
            Int32 paddingCount = -5;   // The number of spaces or characters string is to be padded with

            try
            {
                string actualValue = testString.PadLeft(paddingCount);

            }
            catch (ArgumentOutOfRangeException argE)
            {
                Assert.IsNotNull(argE);
            }
        }

        //TestMethod4 tests behavior if newline character is encountered
        // It should behave as any other string    
        [TestMethod]
        public void TestMethod4()
        {
            String testString = "Pathm\natics";  // The test string to be padded
            Int32 paddingCount = 20;   // Parameter value to call .PadLeft

            string expectedValue = "         Pathm\natics";
            string actualValue = testString.PadLeft(paddingCount);

            // Compare
            Assert.AreEqual(expectedValue, actualValue);           
        }

        //TestMethod5 tests for padding with character 'a'
        // String should be padded with 10 'a' on the left
        [TestMethod]
        public void TestMethod5()
        {
            String testString = "Pathmatics";  // The test string to be padded
            Int32 paddingCount = 20;   // Parameter value to call .PadLeft

            string expectedValue = "aaaaaaaaaaPathmatics";
            string actualValue = testString.PadLeft(paddingCount,'a');

            // Compare
            Assert.AreEqual(expectedValue, actualValue);

        }

        //TestMethod5 tests for unicode value of character
        // Unicode for Pi is sent, string should be padded with 10 Pi's
        [TestMethod]
        public void TestMethod6()
        {
            String testString = "Pathmatics";  // The test string to be padded
            Int32 paddingCount = 20;   // Parameter value to call .PadLeft

            string expectedValue = "ΠΠΠΠΠΠΠΠΠΠPathmatics";
            string actualValue = testString.PadLeft(paddingCount, '\u03a0');

            // Compare
            Assert.AreEqual(expectedValue, actualValue);

        }

        //TestMethod6 test for a combination of unicode or spaces that are encountered
        // 20 Pi characters should be padded on the left of the 5 spaces already present
        [TestMethod]
        public void TestMethod7()
        {
            String testString = "     Path     matics";  // The test string to be padded
            Int32 paddingCount = 40;   // Parameter value to call .PadLeft

            string expectedValue = "ΠΠΠΠΠΠΠΠΠΠΠΠΠΠΠΠΠΠΠΠ     Path     matics";
            string actualValue = testString.PadLeft(paddingCount, '\u03a0');

            // Compare
            Assert.AreEqual(expectedValue, actualValue);

        }

        //TestMethod8 tests for sending '\' that ends up becoming newline character 
        //   if first letter of string is n
        // Retruned string should be as any other string. \n is just a character
        [TestMethod]
        public void TestMethod8()
        {
            String testString = "nice work Ali";  // The test string to be padded
            Int32 paddingCount = 30;   // Parameter value to call .PadLeft

            string expectedValue = "\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\nice work Ali";
            string actualValue = testString.PadLeft(paddingCount, '\\');

            // Compare
            Assert.AreEqual(expectedValue, actualValue);

        }

        //TestMethod9 tests for sending '\' that ends up becoming tab character 
        //   if first letter of string is t
        // Retruned string should be as any other string. \t is just a character
        [TestMethod]
        public void TestMethod9()
        {
            String testString = "toot your own horn friday";  // The test string to be padded
            Int32 paddingCount = 50;   // Parameter value to call .PadLeft

            string expectedValue = "\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\toot your own horn friday";
            string actualValue = testString.PadLeft(paddingCount, '\\');

            // Compare
            Assert.AreEqual(expectedValue, actualValue);

        }

        //TestMethod8 tests for sending '\' that ends up becoming \r character 
        //   if first letter of string is r
        // Retruned string should be as any other string. \r is just a character
        [TestMethod]
        public void TestMethod10()
        {
            String testString = "rock on";  // The test string to be padded
            Int32 paddingCount = 20;   // Parameter value to call .PadLeft

            string expectedValue = "\\\\\\\\\\\\\\\\\\\\\\\\\\rock on";
            string actualValue = testString.PadLeft(paddingCount, '\\');

            // Compare
            Assert.AreEqual(expectedValue, actualValue);

        }
    }
}
