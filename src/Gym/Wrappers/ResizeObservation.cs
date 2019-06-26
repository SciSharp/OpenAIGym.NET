using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Wrappers
{
    public class ResizeObservation : ObservationWrapper
    {
        public ResizeObservation(Env env, int[] shape) : base(env)
        {
            Parameters["env"] = env;
            Parameters["shape"] = shape;
            __self__ = Instance.gym.wrappers.ResizeObservation;
            Init();
        }
    }
}
