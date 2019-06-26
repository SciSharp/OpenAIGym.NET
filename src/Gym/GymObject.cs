using Numpy;
using Numpy.Models;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using static Python.Runtime.Py;

namespace Gym
{
    public class GymObject : IDisposable
    {
        public static GymObject Instance => _instance.Value;

        private static Lazy<GymObject> _instance = new Lazy<GymObject>(() =>
        {
            var instance = new GymObject();
            instance.gym = InstallAndImport("gym");
            
            return instance;
        }
        );

        private static PyObject InstallAndImport(string module)
        {
            if(!PythonEngine.IsInitialized)
                PythonEngine.Initialize();
            var mod = Py.Import(module);
            return mod;
        }

        public dynamic gym = null;

        private bool IsInitialized => gym != null;

        internal GymObject() { }

        public void Dispose()
        {
            gym?.Dispose();
            PythonEngine.Shutdown();
        }

        internal static PyObject ToPython(object obj)
        {
            if (obj == null) return Runtime.GetPyNone();
            switch (obj)
            {
                // basic types
                case int o: return new PyInt(o);
                case float o: return new PyFloat(o);
                case double o: return new PyFloat(o);
                case string o: return new PyString(o);
                case bool o:
                    if (o)
                        return new PyObject(Runtime.PyTrue);
                    else
                        return new PyObject(Runtime.PyFalse);

                // sequence types
                case Array o: return ToList(o);
                // special types from 'ToPythonConversions'
                case Shape o: return ToTuple(o.Dimensions);
                case Slice o: return o.ToPython();
                case PythonObject o: return o.PyObject;
                case PyObject o: return o;
                default: throw new NotImplementedException($"Type is not yet supported: { obj.GetType().Name}. Add it to 'ToPythonConversions'");
            }
        }

        protected static PyTuple ToTuple(Array input)
        {
            var array = new PyObject[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                array[i] = ToPython(input.GetValue(i));
            }

            return new PyTuple(array);
        }

        protected static PyList ToList(Array input)
        {
            var array = new PyObject[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                array[i] = ToPython(input.GetValue(i));
            }

            return new PyList(array);
        }

    }
}
