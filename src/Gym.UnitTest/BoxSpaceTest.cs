using Gym.Spaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Python.Runtime;
using Numpy.Models;
using Numpy;

namespace Gym.UnitTest
{
    [TestClass]
    public class BoxSpaceTest
    {
        [TestMethod]
        public void SampleTest()
        {
            var space = new Box(0, 1, new Numpy.Models.Shape(3, 3, 2));
            var x = space.Sample();
            var jsonObj = space.ToJsonable(x);

            var array = space.FromJsonable(jsonObj);
        }
    }
}
