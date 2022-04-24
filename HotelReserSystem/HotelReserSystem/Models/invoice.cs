namespace HotelReserSystem.Models
{
    public class invoice
    {
        public int invoice_id { get; set; }
        public int customer_id { get; set; }
        public int booking_id { get; set; }
        public int days_of_stay { get; set; }
        public int per_room { get; set; }
        public int no_of_rooms { get; set; }
        public int total_amt { get; set; }
        public int room_id { get; set; }


    }
}
