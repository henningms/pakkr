using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PakkR.Windows10.Models
{
    /// <summary>
    /// Event status
    /// 
    /// PreNotified - Posten has gotten a notification from the sender that there is a package on its way
    /// InTransit - Posten has received the package and is now being moved between terminals and to their destination
    /// ReadyForPickup - The package is at the pickup point ready for the recipient to swing on by and retrieve it
    /// NotificationSent - A notification has been sent out (SMS, E-mail etc) to the recipient that a package is ready to be picked up
    /// TransportToRecipient - Posten has loaded the package on a distribution car ready to deliver it to the recipient
    /// Delivered - The package has been delivered to the recipient
    /// </summary>
    public enum PackageEventStatus
    {
        PreNotified,
        InTransit,
        ReadyForPickup,
        NotificationSent,
        TransportToRecipient,
        Delivered
    }
}
