using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    // Define a public class named Subscription.
    public class Subscription
    {
        // Mark SubscriptionId as the primary key for the Subscription entity.
        [Key]
        // Map this property to the "subscription_id" column in the database and set the order of the column.
        [Column("subscription_id", Order = 1)]
        // Define a public property named SubscriptionId of type int.
        public int SubscriptionId { get; set; }

        // Map this property to the "agency_id" column in the database and set the order of the column.
        [Column("agency_id", Order = 2)]
        // Make the AgencyId property required and set a custom error message.
        [Required(ErrorMessage = "Agency is required")]
        // Define a public property named AgencyId of type int.
        public int AgencyId { get; set; }

        // Map this property to the "origin_city_id" column in the database and set the order of the column.
        [Column("origin_city_id", Order = 3)]
        // Make the OriginCityId property required and set a custom error message.
        [Required(ErrorMessage = "Origin city is required")]
        // Define a public property named OriginCityId of type int.
        public int OriginCityId { get; set; }

        // Map this property to the "destination_city_id" column in the database and set the order of the column.
        [Column("destination_city_id", Order = 4)]
        // Make the DestinationCityId property required and set a custom error message.
        [Required(ErrorMessage = "Destination city is required")]
        // Define a public property named DestinationCityId of type int.
        public int DestinationCityId { get; set; }
    }
}
