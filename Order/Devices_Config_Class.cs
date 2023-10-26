using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Config_Class
{
    public class ConfigLoader
    {
        public string path;

        public ConfigLoader(string path)
        {
            this.path = path;
        }

        public DevicesConfig LoadConfig()
        {
            string json = File.ReadAllText(path);
            DevicesConfig config = JsonConvert.DeserializeObject<DevicesConfig>(json);
            return config;
        }
    }

    public class DevicesConfig
    {
        public List<DeviceBrand> Brands;
        public List<DeviceType> Types;
    }

    public class DeviceBrand
    {
        public int id { get; set; }
        public string brand { get; set; }
        public float coefficient { get; set; }
    }

    public class DeviceType
    {
        public int id { get; set; }
        public string type { get; set; }
        public float coefficient { get; set; }
    }
}
