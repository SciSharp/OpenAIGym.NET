using System;
using System.Collections.Generic;
using System.Text;

namespace Gym
{
    public partial class Utils : Base
    {
        private static dynamic caller = Instance.gym.utils;

        public static void AtomicWrite(string filepath, bool binary = false, bool fsync = false)
        {
            Instance.gym.utils.atomic_write.atomic_write(filepath: filepath, binary: binary, fsync: fsync);
        }
    }
}
