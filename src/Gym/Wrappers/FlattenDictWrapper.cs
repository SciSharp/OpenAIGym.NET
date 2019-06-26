using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Wrappers
{
    public class FlattenDictWrapper : ObservationWrapper
    {
        public FlattenDictWrapper(Env env, string[] dict_keys) : base(env)
        {
            Parameters["env"] = env;
            Parameters["dict_keys"] = dict_keys;
            __self__ = Instance.gym.wrappers.FlattenDictWrapper;
            Init();
        }
    }
}
