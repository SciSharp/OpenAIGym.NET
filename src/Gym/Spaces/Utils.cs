using Numpy;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Spaces
{
    public class Utils : Base
    {
        private static dynamic caller = Instance.gym.spaces.utils;

        public static int FlatDim(Space space)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["space"] = space;
            return InvokeStaticMethod(caller, "flatdim", parameters).As<int>();
        }

        public static NDarray Flatten(Space space, Array x)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["space"] = space;
            parameters["x"] = x;
            PyObject py = InvokeStaticMethod(caller, "flatten", parameters);
            return new NDarray(py);
        }

        public static object UnFlatten<T>(Space space, Array x)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["space"] = space;
            parameters["x"] = x;
            PyObject py = InvokeStaticMethod(caller, "flatten", parameters);
            object result = null;
            if (typeof(T).Name == "NDarray")
                result = new NDarray(py);
            else if (typeof(T).Name == "Int32")
                result = py.As<int>();
            else
                result = py;

            return result;
        }
    }
}
