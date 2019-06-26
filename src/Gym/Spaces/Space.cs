using Numpy;
using Numpy.Models;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Gym.Spaces
{
    public class Space : Base
    {
        public Dtype Dtype => new Dtype(__self__.GetAttr("dtype"));

        public Shape Shape => new Shape(__self__.GetAttr("shape").As<int[]>());

        public Space()
        {

        }

        internal Space(PyObject py)
        {
            __self__ = py;
        }

        public Space(Shape shape = null, Dtype dtype = null)
        {
            Parameters["shape"] = shape;
            Parameters["dtype"] = dtype;

            __self__ = Instance.gym.spaces.Space;
        }

        public virtual NDarray Sample()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            return new NDarray(InvokeMethod("sample", parameters));
        }

        public virtual bool Contains(Array x)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["x"] = x;
            return InvokeMethod("contains", parameters).As<bool>(); throw new NullReferenceException();
        }

        public virtual string[] Seed(int? seed = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["seed"] = seed;
            return InvokeMethod("contains", parameters).As<object[]>().Select(x => (x.ToString())).ToArray();
        }

        public virtual object ToJsonable(params NDarray[] sample_n)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["sample_n"] = sample_n;
            return InvokeMethod("to_jsonable", parameters);
        }

        public virtual NDarray[] FromJsonable(object sample_n)
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
