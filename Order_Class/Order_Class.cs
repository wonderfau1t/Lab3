using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Order_Class
{
    public class Order
    {
        private string deviceType;
        private string deviceBrand;
        private DateTime date;
        private bool priority;
        private float repairCost;
        private bool ready;


        public Order(string deviceType, string deviceBrand, DateTime date, bool priority, float typeCoefficient, float brandCoefficient)
        {
            this.deviceType = deviceType;
            this.deviceBrand = deviceBrand;
            this.date = date;
            this.priority = priority;
            this.repairCost = CalculateSum(typeCoefficient, brandCoefficient, priority);
            this.ready = false;
        }

        public float CalculateSum(float typeCoefficient, float brandCoefficient, bool priority)
        {
            float baseSum = 1000.0f;
            float baseCoefficient = 1.0f;

            baseCoefficient += typeCoefficient;
            baseCoefficient += brandCoefficient;

            float calculatedSum = baseSum * baseCoefficient;

            return priority ? calculatedSum * 2.0f : calculatedSum;
        }

    public string DeviceType { get => deviceType; }
        public string DeviceBrand { get => deviceBrand; }
        public string Date { get => date.ToShortDateString(); }
        public string Priority { get { return priority ? "Высокий" : "Обычный"; } }
        public string RepairCost { get => string.Format("{0:C2}", repairCost); }
        public bool Ready { get => ready; set => ready = value; }
      
    }
}
