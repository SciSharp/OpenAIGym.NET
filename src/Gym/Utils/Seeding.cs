using System;
using System.Collections.Generic;
using System.Text;
using Gym.Helper;
using Numpy;
using Python.Runtime;

namespace Gym
{
    public partial class Utils : Base
    {
        public static (PyObject, string) NPRandom(int? seed = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["seed"] = seed;

            var list = TupleSolver.TupleToList<object>((PyObject)InvokeStaticMethod(caller.seeding, "np_random", parameters));
            return ((PyObject)list[0], list[1].ToString());
        }

        public static string HasSeed(int? seed = null, int max_bytes = 8)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["seed"] = seed;
            parameters["max_bytes"] = max_bytes;
            PyObject py = (PyObject)InvokeStaticMethod(caller.seeding, "hash_seed", parameters);
            return py.ToString();
        }

        public static string CreateSeed(int? a = null, int max_bytes = 8)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["a"] = a;
            parameters["max_bytes"] = max_bytes;
            PyObject py = (PyObject)InvokeStaticMethod(caller.seeding, "create_seed", parameters);
            return py.ToString();
        }
    }
}
