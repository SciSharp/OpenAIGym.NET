using System;
using System.Collections.Generic;
using System.Text;

namespace Gym
{
    public class EnvResult
    {
        public EnvResult()
        {
            Info = new Dictionary<string, object>();
        }

        public object Observation { get; set; }

        public float Reward { get; set; }
        
        public bool Done { get; set; }

        public Dictionary<string, object> Info { get; set; }
    }
}
