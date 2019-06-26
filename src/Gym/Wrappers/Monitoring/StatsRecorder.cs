using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Wrappers.Monitoring
{
    public class StatsRecorder : Base
    {
        public StatsRecorder(string directory, string file_prefix, bool autoreset = false, string env_id = "")
        {
            Parameters["directory"] = directory;
            Parameters["file_prefix"] = file_prefix;
            Parameters["autoreset"] = autoreset;
            Parameters["env_id"] = env_id;

            __self__ = Instance.gym.wrappers.monitoring.StatsRecorder;
            Init();
        }

        public void BeforeStep(object action)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["action"] = action;

            InvokeMethod("before_step", parameters);
        }

        public void AfterStep(object observation, float reward, bool done, Dictionary<string, object> info )
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["observation"] = observation;
            parameters["reward"] = reward;
            parameters["done"] = done;
            parameters["info"] = info;

            InvokeMethod("after_step", parameters);
        }

        public void BeforeReset()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            InvokeMethod("before_reset", parameters);
        }

        public void AfterReset(object observation)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["observation"] = observation;
            InvokeMethod("after_reset", parameters);
        }

        public void SaveComplete()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            InvokeMethod("save_complete", parameters);
        }

        public void Close()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            InvokeMethod("close", parameters);
        }
    }
}
