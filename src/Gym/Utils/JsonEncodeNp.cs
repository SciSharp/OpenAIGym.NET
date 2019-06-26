using System;
using System.Collections.Generic;
using System.Text;

namespace Gym
{
    public partial class Utils : Base
    {
        public static string JsonEncodeNp(object obj)
        {
            return Instance.gym.json_utils.json_encode_np(obj: obj).ToString();
        }
    }
}
