using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PakkR.Windows10.Models
{
    public class Package
    {
        public string ShipmentNumber { get; set; }
        public string PackageNumber { get; set; }
        public string StatusDescription { get; set; }
        public string PickupCode { get; set; }

        public double LengthInCm { get; set; }
        public double WidthInCm { get; set; }
        public double HeightInCm { get; set; }
        public double VolumeInDm3 { get; set; }
        public double WeightInKgs { get; set; }

        public IList<PackageEvent> Events { get; set; }

        public IList<PackageEvent> EventsWithoutTheFirst
        {
            get
            {
                return Events.Skip(1).Take(Events.Count - 1).ToList();
            }
        }

        public PackageEvent LastEvent
        {
            get
            {
                return Events?.FirstOrDefault();
            }
        }

        public string Dimensions
        {
            get
            {
                return $"{LengthInCm}x{WidthInCm}x{HeightInCm} cm";
            }
        }

        public string Weight
        {
            get
            {
                return $"{WeightInKgs} kg";
            }
        }
    }
}
