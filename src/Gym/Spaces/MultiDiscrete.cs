using Numpy;
using Numpy.Models;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Gym.Spaces
{
    public class MultiDiscrete : Space
    {
        public MultiDiscrete(Array nvec)
        {
            Parameters["nvec"] = nvec;
            __self__ = Instance.gym.spaces.MultiDiscrete;
            Init();
        }

        public override bool Contains(Array x)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["x"] = x;
            return InvokeMethod("contains", parameters).As<bool>();
        }

        public override NDarray Sample()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            return new NDarray(InvokeMethod("sample", parameters));
        }
    }
}
