using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Wrappers
{
    public class ClipAction : ActionWrapper
    {
        public ClipAction(Env env) : base(env)
        {
            Parameters["env"] = env;
            __self__ = Instance.gym.wrappers.ClipAction;
            Init();
        }
    }
}
