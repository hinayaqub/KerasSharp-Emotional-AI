using KerasSharp.Layers;
//using KerasSharp.Utils;
using Numpy;
using Numpy.Models;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using static Python.Runtime.Py;

namespace Keras
{
    public class Keras : IDisposable
    {
        public static Keras Instance => _instance.Value;

        private static Lazy<Keras> _instance = new Lazy<Keras>(() =>
        {
            var instance = new Keras();
            instance.keras = InstallAndImport(Setup.KerasModule);

            try
            {
                instance.tensorflow = InstallAndImport("tensorflow");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Warning! tensorflow is not installed. Required to load models");
            }

            try
            {
                instance.keras2onnx = InstallAndImport("onnxmltools");
            }
            catch (Exception ex)
            {
            }

            try
            {
                instance.tfjs = InstallAndImport("tensorflowjs");
            }
            catch (Exception ex)
            {
            }

            return instance;
        }
        );

        private static PyObject InstallAndImport(string module)
        {
            Console.WriteLine(module);
            if(!PythonEngine.IsInitialized)
                PythonEngine.Initialize();
            var mod = Py.Import(module);
            return mod;
        }

        public dynamic keras = null;

        public dynamic tensorflow = null;

        public dynamic keras2onnx = null;

        public dynamic tfjs = null;

        private bool IsInitialized => keras != null;

        internal Keras() { }

        public void Dispose()
        {
            keras?.Dispose();
            PythonEngine.Shutdown();
        }   

    }
}