using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Wrappers
{
    public class FilterObservationWrapper : ObservationWrapper
    {
        public FilterObservationWrapper(Env env, string[] filter_keys) : base(env)
        {
            Parameters["env"] = env;
            Parameters["filter_keys"] = filter_keys;
            __self__ = Instance.gym.wrappers.FilterObservationWrapper;
            Init();
        }
    }
}
