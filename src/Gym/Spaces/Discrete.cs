using Numpy;
using Numpy.Models;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Gym.Spaces
{
    public class Discrete : Space
    {
        public Discrete(int n)
        {
            Parameters["n"] = n;
            __self__ = Instance.gym.spaces.Discrete;
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
