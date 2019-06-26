using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Envs.Atari
{
    public class AtariEnv : Env
    {
        public AtariEnv(string game = "pong", int mode = 0, int difficulty = 0, string obs_type = "ram",
            int[] frameskip = null, float repeat_action_probability = 0, bool full_action_space = false)
        {
            Parameters["game"] = game;
            Parameters["mode"] = mode;
            Parameters["difficulty"] = difficulty;
            Parameters["obs_type"] = obs_type;
            Parameters["frameskip"] = frameskip;
            Parameters["repeat_action_probability"] = repeat_action_probability;
            Parameters["full_action_space"] = full_action_space;
            __self__ = Instance.gym.envs.atari_env.AtariEnv;
            Init();
        }

        public string[] GetActionMeanings()
        {
            return InvokeMethod("get_action_meanings", new Dictionary<string, object>()).As<string[]>();
        }

        public string[] GetKeysToAction()
        {
            return InvokeMethod("get_keys_to_action", new Dictionary<string, object>()).As<string[]>();
        }
    }
}
