using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PakkR.Windows10.Models
{
    public class PackageEvent
    {
        public string Description { get; set; }
        public PackageEventStatus Status { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime Date { get; set; }

        public string StatusDescription
        {
            get
            {
                switch (Status)
                {
                    case PackageEventStatus.PreNotified:
                        return "Forhåndsmeldt";
                    case PackageEventStatus.Delivered:
                        return "Utlevert";
                    default:
                        return Description;
                }
            }
        }

        public string DateAndAddress
        {
            get
            {
                return $"{Date.ToString("dd. MMMM, HH:mm").ToLower()}, {City}";
            }
        }

        public static PackageEventStatus FromStatusStringToEnum(string status)
        {
            switch (status.ToUpper())
            {
                case "PRE_NOTIFIED":
                    return PackageEventStatus.PreNotified;
                case "IN_TRANSIT":
                    return PackageEventStatus.InTransit;
                case "READY_FOR_PICKUP":
                    return PackageEventStatus.ReadyForPickup;
                case "NOTIFICATION_SENT":
                    return PackageEventStatus.NotificationSent;
                case "TRANSPORT_TO_RECIPIENT":
                    return PackageEventStatus.TransportToRecipient;
                case "DELIVERED":
                    return PackageEventStatus.Delivered;
                default:
                    return PackageEventStatus.PreNotified;
            }
        }
    }
}
