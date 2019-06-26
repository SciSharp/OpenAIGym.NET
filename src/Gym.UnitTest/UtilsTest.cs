using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gym.UnitTest
{
    [TestClass]
    public class UtilsTest
    {
        [TestMethod]
        public void NPRandomTest()
        {
            var (rng, seed) = Utils.NPRandom();

            var hasSeed = Utils.HasSeed(5243, 8);
            string s = Utils.JsonEncodeNp(hasSeed);
        }
    }
}
