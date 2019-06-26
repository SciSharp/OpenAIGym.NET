using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Core
{
    public class GoalEnv : Env
    {
        public GoalEnv()
        {
            __self__ = Instance.gym.core.GoalEnv;
            Init();
        }

        internal GoalEnv(PyObject py)
        {
            __self__ = py;
        }

        public override object Reset()
        {
            return (object)InvokeMethod("reset", new Dictionary<string, object>());
        }
    }
}
