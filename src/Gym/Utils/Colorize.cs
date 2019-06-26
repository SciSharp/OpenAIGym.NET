using System;
using System.Collections.Generic;
using System.Text;

namespace Gym
{
    public partial class Utils : Base
    {
        public static string Colorize(string _string, string color, bool bold = false, bool highlight = false)
        {
            return Instance.gym.utils.colorize.colorize(_string, color: color, bold: bold, highlight: highlight).ToString();
        }
    }
}
