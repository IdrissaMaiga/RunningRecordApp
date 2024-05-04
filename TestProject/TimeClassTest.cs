using RunningRecordApp;

namespace TestProject
{
    [TestFixture]
    public class TimeClassTests
    {


        //Parse green test with multiple testcase
        [TestCase("02:22:08")]
        [TestCase("22:08")]
        [TestCase("00:22:08")]
        [TestCase("02:22:00")]
        public void ParseTest(string timeAsString)
        {

            Assert.AreEqual(Time.Parse(timeAsString).ToString(), timeAsString);
        }



    }
}