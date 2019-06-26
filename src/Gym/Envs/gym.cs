using System;
using System.Collections.Generic;
using System.Text;
using Gym.Helper;
using Python.Runtime;

namespace Gym
{
    public class gym : Base
    {
        private static dynamic caller = Instance.gym.envs.registration;

        public static object Load(string name)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["name"] = name;
            PyObject py = InvokeStaticMethod(caller, "load", parameters);
            return py.As<object>();
        }

        public static void Register(string id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["id"] = id;
            InvokeStaticMethod(caller, "register", parameters);
        }

        public static Env Make(string id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["id"] = id;
            PyObject py = InvokeStaticMethod(caller, "make", parameters);
            return new Env(py);
        }

        public static Dictionary<string, object> Spec(string id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["id"] = id;
            PyObject py = InvokeStaticMethod(caller, "spec", parameters);
            return DictSolver.ToClr<object>(new PyDict(py));
        }
    }
}
