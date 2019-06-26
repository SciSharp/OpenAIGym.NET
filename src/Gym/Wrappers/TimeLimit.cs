using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Wrappers
{
    public class TimeLimit : Wrapper
    {
        public TimeLimit(Env env, int? max_episode_steps = null) : base(env)
        {
            Parameters["env"] = env;
            Parameters["max_episode_steps"] = max_episode_steps;
            __self__ = Instance.gym.wrappers.TimeLimit;
            Init();
        }
    }
}
