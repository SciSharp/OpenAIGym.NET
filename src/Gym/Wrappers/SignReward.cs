using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Wrappers
{
    public class SignReward : ObservationWrapper
    {
        public SignReward(Env env) : base(env)
        {
            Parameters["env"] = env;
            __self__ = Instance.gym.wrappers.SignReward;
            Init();
        }
    }
}
