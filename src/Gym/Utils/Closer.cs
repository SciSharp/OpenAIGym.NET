using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.utils
{
    public class Closer : Base
    {
        public Closer(bool atexit_register = true)
        {
            Parameters["atexit_register"] = atexit_register;

            __self__ = Instance.gym.utils.Closer;
        }

        public int GenerateNextID()
        {
            return (int)__self__.generate_next_id();
        }

        public virtual int Register(Closer closeable)
        {
            return (int)__self__.register(closeable: closeable);
        }

        public virtual void UnRegister(int id)
        {
            __self__.unregister(id: id);
        }

        public virtual void Close()
        {
            __self__.close();
        }
    }
}
