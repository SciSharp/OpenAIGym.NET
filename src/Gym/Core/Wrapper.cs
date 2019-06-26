using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym
{
    public class Wrapper : Env
    {
        internal Env env;
        public Wrapper(Env env)
        {
            this.env = env;
        }

        public override EnvResult Step(object action)
        {
            return env.Step(action);
        }

        public override object Reset()
        {
            return env.Reset();
        }

        public override void Render(string mode = "human")
        {
            env.Render(mode);
        }

        public override void Close()
        {
            env.Close();
        }

        public override void Seed(int? seed = null)
        {
            env.Seed(seed);
        }

        public override (float, object) ComputeReward(object achieved_goal, object desired_goal, Dictionary<string, object> info)
        {
            return env.ComputeReward(achieved_goal, desired_goal, info);
        }
    }

    public class ObservationWrapper : Wrapper
    {
        public ObservationWrapper(Env env) : base(env)
        {
            __self__ = Instance.gym.core.ObservationWrapper;
            Init();
        }

        public override object Reset()
        {
            var observation = base.Reset();
            return Observation(observation);
        }

        public override EnvResult Step(object action)
        {
            var result = env.Step(action);
            result.Observation = Observation(result.Observation);
            return result;
        }

        public virtual object Observation(object observation)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["observation"] = observation;
            return InvokeMethod("observation", parameters).As<object>();
        }
    }

    public class RewardWrapper : Wrapper
    {
        public RewardWrapper(Env env) : base(env)
        {
            __self__ = Instance.gym.core.RewardWrapper;
            Init();
        }

        public override object Reset()
        {
            return env.Reset();
        }

        public override EnvResult Step(object action)
        {
            var result = env.Step(action);
            result.Reward = Reward(result.Reward);
            return result;
        }

        public virtual float Reward(float reward)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["reward"] = reward;
            return InvokeMethod("reward", parameters).As<float>();
        }
    }

    public class ActionWrapper : Wrapper
    {
        public ActionWrapper(Env env) : base(env)
        {
            __self__ = Instance.gym.core.ActionWrapper;
            Init();
        }

        public override object Reset()
        {
            return env.Reset();
        }

        public override EnvResult Step(object action)
        {
            return env.Step(action);
        }

        public virtual object Action(float action)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["action"] = action;
            return InvokeMethod("action", parameters).As<object>();
        }

        public virtual object ReverseAction(float action)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["action"] = action;
            return InvokeMethod("reverse_action", parameters).As<object>();
        }
    }
}
