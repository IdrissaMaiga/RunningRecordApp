using RunningRecordApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestFixture]
    public class RunnerResultsTes
    {


        //Parse green test with multiple testcase

        [Test]
        // Not sorted test
        public void sortedtest()
        {
            string[] inputs = new string[] { "Zlice,02:22:08", "Alice,02:02:08", "Ahice,02:22:08", "Aldfdice,02:22:34" };
            RaceResults raceResults = new(inputs.Length, inputs);

            Assert.AreEqual(raceResults.IsSorted(), false);
        }
    }
}
