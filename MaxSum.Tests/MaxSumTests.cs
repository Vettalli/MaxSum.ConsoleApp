using NUnit.Framework;
using MaxSum.Application;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.IO;

namespace MaxSum.Tests
{
    public class MaxSumTests
    {
       private ISum _test;
       private ServiceProvider _serviceProvider;
        
        [SetUp]
        public void Setup()
        {
            _serviceProvider = new ServiceCollection().
                AddSingleton<ISum, MaxSumApplication>().
                BuildServiceProvider();

            _test = _serviceProvider.GetService<ISum>();

            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }

        [Test]
        public void BiggestSumTest()
        {
            string[] testNums = {"1.234,1432.234,124.14", "14,35,25.35,-142.254,1354.52", "1234,35,1324.36,25,36.1354", "-1242,345,25.243","1134,3235.124,2345.2324,124.234", "48.356,357.346,537.2345,4574.2543" };
            int testPosition = 5;
            
            Assert.AreEqual(testPosition, _test.GetIndexOfMaxSum(_test.GetSumFromStrings(testNums)));
        }

        [Test]
        public void NullTest()
        {
            string [] nums = null;
            bool callFailed = false;

            try
            {
                var actualResult = _test.GetSumFromStrings(nums);
            }
            catch (NullReferenceException)
            {
                callFailed = true;
            }

            Assert.IsTrue(callFailed, "Expected call of GetSumFromStrings method failed with NullReferenceException");
        }

        [Test]
        public void EmptyPathTest()
        {
            string path = "";
            bool callFailed=false;

            try
            {
                var actualResult = _test.GetFile(path);
            }
            catch (ArgumentException)
            {
                callFailed = true;
            }

            Assert.IsTrue(callFailed, "Expected call of GetFile method failed with ArgumentException");
        }

        [Test]
        public void WrongPathTest()
        {
            string path = "khjg";
            bool callFailed = false;

            try
            {
                var actualResult = _test.GetFile(path);
            }
            catch (FileNotFoundException)
            {
                callFailed = true;
            }

            Assert.IsTrue(callFailed, "Expected call of GetFile method failed with FileNotFoundException");
        }
    }
}
