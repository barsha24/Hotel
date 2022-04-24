namespace HotelReserSystem.Models
{
    public class booked
    {
        public int booking_id { get; set; }
        public int customer_id { get; set; }
        public DateTime booked_date { get; set; }
        public int booked_rooms { get; set; }
        public string booked_status { get; set; }
        public int room_id { get; set; }
    }
}
