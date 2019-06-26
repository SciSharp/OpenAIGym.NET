using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Wrappers
{
    public class Monitor : Wrapper
    {
        public Monitor(Env env, string directory, object video_callable = null, bool force = false, bool resume = false,
                 bool write_upon_reset = false, string uid = "", string mode = "") : base(env)
        {
            Parameters["env"] = env;
            Parameters["directory"] = directory;
            Parameters["video_callable"] = video_callable;
            Parameters["force"] = force;
            Parameters["resume"] = resume;
            Parameters["write_upon_reset"] = write_upon_reset;
            Parameters["uid"] = uid;
            Parameters["mode"] = mode;

            __self__ = Instance.gym.wrappers.Monitor;
            Init();
        }

        public virtual void SetMonitorMode(string mode)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["mode"] = mode;
            InvokeMethod("set_monitor_mode", parameters).As<object>();
        }

        
    }
}
