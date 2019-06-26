using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Wrappers
{
    public class AtariPreprocessing : Wrapper
    {
        public AtariPreprocessing(Env env, int noop_max = 30, int frame_skip = 4, int screen_size = 84, bool terminal_on_life_loss = false, bool grayscale_obs = true)
            : base(env)
        {
            Parameters["env"] = env;
            Parameters["noop_max"] = noop_max;
            Parameters["frame_skip"] = frame_skip;
            Parameters["screen_size"] = screen_size;
            Parameters["terminal_on_life_loss"] = terminal_on_life_loss;
            Parameters["grayscale_obs"] = grayscale_obs;

            __self__ = Instance.gym.wrappers.AtariPreprocessing;
            Init();
        }
    }
}
