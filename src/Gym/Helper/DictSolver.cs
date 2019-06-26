using Numpy;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Helper
{
    public class DictSolver
    {
        public static PyDict FromClr(Dictionary<string, object> obj)
        {
            PyDict dict = new PyDict();
            foreach (var item in obj)
            {
                dict.SetItem(GymObject.ToPython(item.Key), GymObject.ToPython(item.Value));
            }

            return dict;
        }

        public static Dictionary<string, T> ToClr<T>(PyDict dict)
        {
            Dictionary<string, T> result = new Dictionary<string, T>();

            string[] keys = dict.Keys().As<string[]>();
            foreach (var item in keys)
            {
                result[item] = dict[item].As<T>();
            }

            return result;
        }
    }
}
