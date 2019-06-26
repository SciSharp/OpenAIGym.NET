using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.utils
{
    public class EzPickle : Base
    {
        public EzPickle(params object[] args)
        {
            for(int i=0;i<args.Length;i++)
            {
                Parameters[args[i].GetType().Name] = args[i];
            }

            __self__ = Instance.gym.utils.EzPickle;
        }
    }
}
