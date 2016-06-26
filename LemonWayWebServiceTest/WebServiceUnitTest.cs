
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace LemonWayWebServiceTest
{
    [TestClass]
    public class WebServiceUnitTest
    {
        private static TestContext context;

        [ClassInitialize()]
        public static void InitTestSuite(TestContext testContext)
        {
            context = testContext;
        }

        LemonWayWebServiceProxy _target;
        bool _urlRedirectionTryResult;

        [TestInitialize()]
        public void TestInitialize()
        {               
            _target = new LemonWayWebServiceProxy();

            _urlRedirectionTryResult = WebServiceHelper.TryUrlRedirection
             (
              _target,
              context,
              "DevServer"
             );
        }

        #region Fibonacci Tests with 1 to 8 integer parameters

        [TestMethod()]
        [AspNetDevelopmentServer("DevServer", @"$(SolutionDir)\LemonWayWebService")]
        public void fibonacciTest_with_arg_1_returns_1()
        {
            Assert.IsTrue(_urlRedirectionTryResult, "The redirection to LemonWay web service Url failed.");

            const int FACTOR = 1;
            const string EXPECTED = "{\"response\":\"1\"}";

            string actual = _target.Fibonacci(FACTOR);
            Assert.AreEqual(EXPECTED, actual, "Wrong result from Finobacci function with in range parameter.");
        }

        [TestMethod()]
        [AspNetDevelopmentServer("DevServer", @"$(SolutionDir)\LemonWayWebService")]
        public void fibonacciTest_with_arg_2_returns_1()
        {
            Assert.IsTrue(_urlRedirectionTryResult, "The redirection to LemonWay web service Url failed.");

            const int FACTOR = 2;
            const string EXPECTED = "{\"response\":\"1\"}";

            string actual = _target.Fibonacci(FACTOR);
            Assert.AreEqual(EXPECTED, actual, "Wrong result from Finobacci function with in range parameter.");
        }

        [TestMethod()]
        [AspNetDevelopmentServer("DevServer", @"$(SolutionDir)\LemonWayWebService")]
        public void fibonacciTest_with_arg_3_returns_2()
        {
            Assert.IsTrue(_urlRedirectionTryResult, "The redirection to LemonWay web service Url failed.");

            const int FACTOR = 3;
            const string EXPECTED = "{\"response\":\"2\"}";

            string actual = _target.Fibonacci(FACTOR);
            Assert.AreEqual(EXPECTED, actual, "Wrong result from Finobacci function with in range parameter.");
        }

        [TestMethod()]
        [AspNetDevelopmentServer("DevServer", @"$(SolutionDir)\LemonWayWebService")]
        public void fibonacciTest_with_arg_4_returns_3()
        {
            Assert.IsTrue(_urlRedirectionTryResult, "The redirection to LemonWay web service Url failed.");

            const int FACTOR = 4;
            const string EXPECTED = "{\"response\":\"3\"}";

            string actual = _target.Fibonacci(FACTOR);
            Assert.AreEqual(EXPECTED, actual, "Wrong result from Finobacci function with in range parameter.");
        }

        [TestMethod()]
        [AspNetDevelopmentServer("DevServer", @"$(SolutionDir)\LemonWayWebService")]
        public void fibonacciTest_with_arg_5_returns_5()
        {
            Assert.IsTrue(_urlRedirectionTryResult, "The redirection to LemonWay web service Url failed.");

            const int FACTOR = 5;
            const string EXPECTED = "{\"response\":\"5\"}";

            string actual = _target.Fibonacci(FACTOR);
            Assert.AreEqual(EXPECTED, actual, "Wrong result from Finobacci function with in range parameter.");
        }

        [TestMethod()]
        [AspNetDevelopmentServer("DevServer", @"$(SolutionDir)\LemonWayWebService")]
        public void fibonacciTest_arg_6_returns_8()
        {
            Assert.IsTrue(_urlRedirectionTryResult, "The redirection to LemonWay web service Url failed.");

            const int FACTOR = 6;
            const string EXPECTED = "{\"response\":\"8\"}";

            string actual = _target.Fibonacci(FACTOR);
            Assert.AreEqual(EXPECTED, actual, "Wrong result from Finobacci function with in range parameter.");
        }

        [TestMethod()]
        [AspNetDevelopmentServer("DevServer", @"$(SolutionDir)\LemonWayWebService")]
        public void fibonacciTest_with_arg_7_returns_13()
        {
            Assert.IsTrue(_urlRedirectionTryResult, "The redirection to LemonWay web service Url failed.");

            const int FACTOR = 7;
            const string EXPECTED = "{\"response\":\"13\"}";

            string actual = _target.Fibonacci(FACTOR);
            Assert.AreEqual(EXPECTED, actual, "Wrong result from Finobacci function with in range parameter.");
        }

        [TestMethod()]
        [AspNetDevelopmentServer("DevServer", @"$(SolutionDir)\LemonWayWebService")]
        public void fibonacciTest_with_arg_8_returns_21()
        {
            Assert.IsTrue(_urlRedirectionTryResult, "The redirection to LemonWay web service Url failed.");

            const int FACTOR = 8;
            const string EXPECTED = "{\"response\":\"21\"}";

            string actual = _target.Fibonacci(FACTOR);
            Assert.AreEqual(EXPECTED, actual, "Wrong result from Finobacci function with in range parameter.");
        }
        #endregion Fibonacci Tests with 1 to 8 integer parameters

        #region Fibonacci Tests with parameters out of range

        [TestMethod]
        [AspNetDevelopmentServer("DevServer", @"$(SolutionDir)\LemonWayWebService")]
        public void fibonacciNegativeInputTest()
        {
            Assert.IsTrue(_urlRedirectionTryResult, "The redirection to web service Url failed in \"DevServer\" context.");

            const int FACTOR = -3;
            const string EXPECTED = "{\"response\":\"-1\"}";

            string actual = _target.Fibonacci(FACTOR);
            Assert.AreEqual(EXPECTED, actual, "Wrong result from Finobacci function with out of range parameter.");
        }

        [TestMethod]
        [AspNetDevelopmentServer("DevServer", @"$(SolutionDir)\LemonWayWebService")]
        public void fibonacciZeroAsInputTest()
        {
            Assert.IsTrue(_urlRedirectionTryResult, "The redirection to web service Url failed in \"DevServer\" context.");

            const int FACTOR = 0;
            const string EXPECTED = "{\"response\":\"-1\"}";

            string actual = _target.Fibonacci(FACTOR);
            Assert.AreEqual(EXPECTED, actual, "Wrong result from Finobacci function with out of range parameter.");
        }

        [TestMethod]
        [AspNetDevelopmentServer("DevServer", @"$(SolutionDir)\LemonWayWebService")]
        public void fibonacciMoreThanHundredInputTest()
        {
            Assert.IsTrue(_urlRedirectionTryResult, "The redirection to web service Url failed in \"DevServer\" context.");

            const int FACTOR = 104;
            const string EXPECTED = "{\"response\":\"-1\"}";

            string actual = _target.Fibonacci(FACTOR);
            Assert.AreEqual(EXPECTED, actual, "Wrong result from Finobacci function with out of range parameter.");
        }

        #endregion Fibonacci Tests with parameters out of range

        #region XmlToJsonTests

        [TestMethod]
        [AspNetDevelopmentServer("DevServer", @"$(SolutionDir)\LemonWayWebService")]
        public void badXmlToJsonTest()
        {
            Assert.IsTrue(_urlRedirectionTryResult, "The redirection to web service Url failed in \"DevServer\" context.");

            const string FACTOR = "<foo>hello</bar>";
            const string EXPECTED = "Bad Xml format";

            string actual = _target.XmlToJson(FACTOR);
            Assert.AreEqual(EXPECTED, actual, "Wrong result from XmlToJson function");
        }

        [TestMethod]
        [AspNetDevelopmentServer("DevServer", @"$(SolutionDir)\LemonWayWebService")]
        public void xmlToJsonTest()
        {
            Assert.IsTrue(_urlRedirectionTryResult, "The redirection to web service Url failed in \"DevServer\" context.");

            const string FACTOR = "<foo>bar</foo>";
            const string EXPECTED = "{\"foo\":\"bar\"}";

            string actual = _target.XmlToJson(FACTOR);
            Assert.AreEqual(EXPECTED, actual, "Wrong result from XmlToJson function");
        }

        #endregion XmlToJsonTests
    }
}
