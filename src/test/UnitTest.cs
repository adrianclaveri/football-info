using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApi;

namespace test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod()
        {
            var client = new NetFootballDataClient();
            var result = client.GetCompetitions().Result;
            Assert.IsTrue(result.Length > 0);

            var result2 = client.GetLeagueTable("445").Result;
            Assert.AreEqual("Premier League 2017/18", result2.leagueCaption);
        }
    }
}
