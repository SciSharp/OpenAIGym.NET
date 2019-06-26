using Numpy;
using Numpy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Wrappers.Monitoring
{
    public class VideoRecorder : Base
    {
        public VideoRecorder(Env env, string path = "", Dictionary<string, object> metadata = null, bool enabled = true, string base_path = "")
        {
            Parameters["env"] = env;
            Parameters["path"] = path;
            Parameters["metadata"] = metadata;
            Parameters["enabled"] = enabled;
            Parameters["base_path"] = base_path;

            __self__ = Instance.gym.wrappers.monitoring.VideoRecorder;
            Init();
        }

        public void CaptureFrame()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            InvokeMethod("capture_frame", parameters);
        }

        public void Close()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            InvokeMethod("close", parameters);
        }

        public void WriteMetadata()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            InvokeMethod("write_metadata", parameters);
        }
    }

    public class TextEncoder : Base
    {
        public TextEncoder(string output_path, int frames_per_sec)
        {
            Parameters["output_path"] = output_path;
            Parameters["frames_per_sec"] = frames_per_sec;

            __self__ = Instance.gym.wrappers.monitoring.TextEncoder;
            Init();
        }

        public void CaptureFrame(string frame)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["frame"] = frame;
            InvokeMethod("capture_frame", parameters);
        }

        public void Close()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            InvokeMethod("close", parameters);
        }
    }

    public class ImageEncoder : Base
    {
        public ImageEncoder(string output_path, Shape frame_shape, int frames_per_sec)
        {
            Parameters["output_path"] = output_path;
            Parameters["frame_shape"] = frame_shape;
            Parameters["frames_per_sec"] = frames_per_sec;

            __self__ = Instance.gym.wrappers.monitoring.ImageEncoder;
            Init();
        }

        public void Start()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            InvokeMethod("start", parameters);
        }

        public void CaptureFrame(NDarray frame)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["frame"] = frame;
            InvokeMethod("capture_frame", parameters);
        }

        public void Close()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            InvokeMethod("close", parameters);
        }
    }
}
