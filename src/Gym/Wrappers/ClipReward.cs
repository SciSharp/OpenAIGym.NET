using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Wrappers
{
    public class ClipReward : RewardWrapper
    {
        public ClipReward(Env env, float min_r, float max_r) : base(env)
        {
            Parameters["env"] = env;
            Parameters["min_r"] = min_r;
            Parameters["max_r"] = max_r;
            __self__ = Instance.gym.wrappers.ClipReward;
            Init();
        }
    }
}
