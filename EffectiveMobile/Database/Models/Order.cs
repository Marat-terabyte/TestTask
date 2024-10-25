﻿namespace EffectiveMobile.Database.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public required string CityDistrict { get; set; }
        public DateTime DeliveryTime { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Weight: {Weight} District: {CityDistrict} Delivery time: {DeliveryTime}";
        }
    }
}
