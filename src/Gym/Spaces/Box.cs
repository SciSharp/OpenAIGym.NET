using Numpy;
using Numpy.Models;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Gym.Spaces
{
    public class Box : Space
    {
        public Box(float low, float high, Shape shape = null, Dtype dtype = null)
        {
            Parameters["low"] = low;
            Parameters["high"] = high;
            Parameters["shape"] = shape;
            Parameters["dtype"] = dtype == null ? np.float32 : dtype;
            __self__ = Instance.gym.spaces.Box;
            Init();
        }

        public override string[] Seed(int? seed = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["seed"] = seed;
            return InvokeMethod("contains", parameters).As<object[]>().Select(x=>(x.ToString())).ToArray();
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

        public override object ToJsonable(params NDarray[] sample_n)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["sample_n"] = sample_n;
            return InvokeMethod("to_jsonable", parameters);
        }

        public override NDarray[] FromJsonable(object sample_n)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["sample_n"] = sample_n;
            var py = InvokeMethod("from_jsonable", parameters);
            List<NDarray> result = new List<NDarray>();
            foreach (PyObject item in py)
            {
                result.Add(new NDarray(item));
            }

            return result.ToArray();
        }
    }
}
