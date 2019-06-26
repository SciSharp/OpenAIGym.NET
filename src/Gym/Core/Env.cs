using Gym.Helper;
using Gym.Spaces;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym
{
    public class Env : Base
    {
        internal Env()
        {

        }

        internal Env(PyObject py)
        {
            __self__ = py;
        }

        public Space ActionSpace
        {
            get
            {
                return new Space((PyObject)__self__.GetAttr("action_space"));
            }
        }

        public Space ObservationSpace
        {
            get
            {
                return new Space((PyObject)__self__.GetAttr("observation_space"));
            }
        }

        public float[] RewardRange
        {
            get
            {
                return TupleSolver.TupleToList<float>((PyObject)__self__.GetAttr("reward_range"));
            }
        }

        public virtual EnvResult Step(object action)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["action"] = action;
            PyObject py = InvokeMethod("step", parameters);
            var list = TupleSolver.TupleToList<object>(py);
            EnvResult result = new EnvResult()
            {
                Observation = list[0],
                Reward = Convert.ToSingle(list[1].ToString()),
                Done = list[2].ToString() == "True" ? true : false,
                Info = DictSolver.ToClr<object>(new PyDict((PyObject)list[3]))
            };

            return result;
        }

        public virtual object Reset()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            PyObject py = InvokeMethod("reset", parameters);
            return py.As<object>();
        }

        public virtual void Render(string mode = "human")
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["mode"] = mode;
            InvokeMethod("render", parameters);
        }

        public virtual void Close()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            InvokeMethod("close", parameters);
        }

        public virtual void Seed(int? seed = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["seed"] = seed;
            InvokeMethod("seed", parameters);
        }

        public virtual (float, object) ComputeReward(object achieved_goal, object desired_goal, Dictionary<string, object> info)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["achieved_goal"] = achieved_goal;
            parameters["desired_goal"] = desired_goal;
            parameters["info"] = info;

            var py = InvokeMethod("compute_reward", parameters);
            var list = TupleSolver.TupleToList<object>(py);
            return ((float)list[0], list[1]);
        }
    }
}
