using Gym.Helper;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym
{
    public class EnvSpec: Base
    {
        public EnvSpec(string id, string entry_point = "", int? reward_threshold = null, Dictionary<string, object> kwargs = null,
                        bool nondeterministic = false, Dictionary<string, object> tags = null, int? max_episode_steps = null)
        {
            Parameters["id"] = id;
            Parameters["entry_point"] = entry_point;
            Parameters["reward_threshold"] = reward_threshold;
            Parameters["kwargs"] = kwargs;
            Parameters["nondeterministic"] = nondeterministic;
            Parameters["tags"] = tags;
            Parameters["max_episode_steps"] = max_episode_steps;
            __self__ = Instance.gym.envs.registration.EnvSpec;
            Init();
        }

        public Env Make()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            PyObject py = InvokeMethod("make", parameters);
            return new Env(py);
        }

    }

    public class EnvRegistry : Base
    {
        public EnvRegistry()
        {
            Init();
        }

        public Env Make(string path, Dictionary<string, object> kwargs)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["path"] = path;
            parameters["kwargs"] = kwargs;
            PyObject py = InvokeMethod("make", parameters);
            return new Env(py);
        }

        public object[] All()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            PyObject py = InvokeMethod("all", parameters);
            return py.As<object[]>();
        }

        public Dictionary<string, object> Spec(string path)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["path"] = path;
            PyObject py = InvokeMethod("spec", parameters);
            return DictSolver.ToClr<object>(new PyDict(py));
        }

        public void Register(string id, Dictionary<string, object> kwargs)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["id"] = id;
            parameters["kwargs"] = kwargs;
            InvokeMethod("register", parameters);
        }
    }
}
