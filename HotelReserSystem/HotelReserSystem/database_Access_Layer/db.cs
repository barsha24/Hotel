using HotelReserSystem.Models;
using System.Data;
using System.Data.SqlClient;


namespace HotelReserSystem.database_Access_Layer
{
    public class db
    {
        string connectionString = "Data Source = DESKTOP-B4K227K; Initial Catalog = HotelReservationSystem; Integrated Security=SSPI; User ID=''; Password='' ";


        public IEnumerable<customers> GetAllcustomers()
        {
            var customerslist = new List<customers>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("getall_customers", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var Customers = new customers();
                    Customers.customer_id = Convert.ToInt32(dr["customer_id"].ToString());
                    Customers.customer_name = dr["customer_name"].ToString();
                    Customers.customer_address = dr["customer_address"].ToString();
                    Customers.customer_status = dr["customer_status"].ToString();

                    customerslist.Add(Customers);
                }
                con.Close();
            }
            return customerslist;
        }
        public void InsertCustomers(customers Customers)

        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spInsert_customers", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@customer_id", Customers.customer_id);
                cmd.Parameters.AddWithValue("@customer_name", Customers.customer_name);
                cmd.Parameters.AddWithValue("@customer_address", Customers.customer_address);
                cmd.Parameters.AddWithValue("@customer_status", Customers.customer_status);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public void UpdateCustomers(customers Customers)

        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateRecord_customers", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@customer_id", Customers.customer_id);
                cmd.Parameters.AddWithValue("@customer_name", Customers.customer_name);
                cmd.Parameters.AddWithValue("@customer_address", Customers.customer_address);
                cmd.Parameters.AddWithValue("@customer_status", Customers.customer_status);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public void DeleteCustomers(int? customer_id)

        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteRecord_customers", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@customer_id", customer_id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public customers GetCustomerByid(int? customer_id)

        {
            var Cuss = new customers();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("getbyid_customers", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@customer_id", customer_id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cuss.customer_id = Convert.ToInt32(dr["customer_id"].ToString());
                    Cuss.customer_name = dr["customer_name"].ToString();
#pragma warning disable CS8601 // Possible null reference assignment.
                    Cuss.customer_address = dr["customer_address"].ToString();
#pragma warning restore CS8601 // Possible null reference assignment.
                    Cuss.customer_status = dr["customer_status"].ToString();

                }
                con.Close();

            }
            return Cuss;
        }













        public IEnumerable<rooms> GetAllrooms()
        {
            var roomslist = new List<rooms>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("getall_rooms", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var Rooms = new rooms();
                    Rooms.room_id = Convert.ToInt32(dr["room_id"].ToString());
                    Rooms.room_no = Convert.ToInt32(dr["room_no"].ToString());
                    Rooms.room_status = dr["room_status"].ToString();
                    Rooms.room_price = Convert.ToInt32(dr["room_price"].ToString());
                    Rooms.room_type = dr["room_type"].ToString();


                    roomslist.Add(Rooms);
                }
                con.Close();
            }
            return roomslist;
        }
        public void InsertRooms(rooms Rooms)

        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertRecord_rooms", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@room_id", Rooms.room_id);
                cmd.Parameters.AddWithValue("@room_no", Rooms.room_no);
                cmd.Parameters.AddWithValue("@room_status", Rooms.room_status);
                cmd.Parameters.AddWithValue("@room_price", Rooms.room_price);
                cmd.Parameters.AddWithValue("@room_type", Rooms.room_type);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public void UpdateRooms(rooms Rooms)

        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateRecord_rooms", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@room_id", Rooms.room_id);
                cmd.Parameters.AddWithValue("@room_no", Rooms.room_no);
                cmd.Parameters.AddWithValue("@room_status", Rooms.room_status);
                cmd.Parameters.AddWithValue("@room_price", Rooms.room_price);
                cmd.Parameters.AddWithValue("@room_type", Rooms.room_type);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public void DeleteRooms(int? room_id)

        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteRecord_rooms", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@room_id", room_id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public rooms GetRoomsByid(int? room_id)

        {
            var Russ = new rooms();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("getbyid_rooms", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@room_id", room_id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Russ.room_id = Convert.ToInt32(dr["room_id"].ToString());
                    Russ.room_no = Convert.ToInt32(dr["room_no"].ToString());
                    Russ.room_status = dr["room_status"].ToString();
                    Russ.room_price = Convert.ToInt32(dr["room_price"].ToString());
                    Russ.room_type = dr["room_type"].ToString();

                }
                con.Close();

            }
            return Russ;
        }




        public IEnumerable<booked> GetAllbooked()
        {
            var bookedlist = new List<booked>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("fetchdata", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var Booked = new booked();
                    cmd.Parameters.AddWithValue("@customer_id", Booked.customer_id);
                    cmd.Parameters.AddWithValue("@booking_id", Booked.booking_id);
                    cmd.Parameters.AddWithValue("@room_id", Booked.room_id);
                    cmd.Parameters.AddWithValue("@booked_date", Booked.booked_date);
                    cmd.Parameters.AddWithValue("@booked_rooms", Booked.booked_rooms);
                    cmd.Parameters.AddWithValue("@booked_status", Booked.booked_status);
                    bookedlist.Add(Booked);
                }
                con.Close();
            }
            return bookedlist;
        }

        public void InsertBooked(booked Booked)

        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertRecord_booked", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@customer_id", Booked.customer_id);
                cmd.Parameters.AddWithValue("@booking_id", Booked.booking_id);
                cmd.Parameters.AddWithValue("@room_id", Booked.room_id);
                cmd.Parameters.AddWithValue("@booked_date", Booked.booked_date);
                cmd.Parameters.AddWithValue("@booked_rooms", Booked.booked_rooms);
                cmd.Parameters.AddWithValue("@booked_status", Booked.booked_status);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public void UpdateBooked(booked Booked)

        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateRecord_booked", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@customer_id", Booked.customer_id);
                cmd.Parameters.AddWithValue("@booking_id", Booked.booking_id);
                cmd.Parameters.AddWithValue("@room_id", Booked.room_id);
                cmd.Parameters.AddWithValue("@booked_date", Booked.booked_date);
                cmd.Parameters.AddWithValue("@booked_rooms", Booked.booked_rooms);
                cmd.Parameters.AddWithValue("@booked_status", Booked.booked_status);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public void DeleteBooked(int? booked_id)

        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteRecord_booked", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@booked_id", booked_id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }


        public booked GetBookedByid(int? booking_id)

        {
            var Buss = new booked();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("getbyid_booked", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@booking_id", booking_id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Buss.customer_id = Convert.ToInt32(dr["customer_id"].ToString());
                    Buss.booking_id = Convert.ToInt32(dr["booking_id"].ToString());
                    Buss.room_id = Convert.ToInt32(dr["room_id"].ToString());
                    Buss.booked_date = Convert.ToDateTime(dr["booked_date"].ToString());
                    Buss.booked_rooms = Convert.ToInt32(dr["booked_rooms"].ToString());
                    Buss.booked_status = dr["booked_status"].ToString();

                }
                con.Close();

            }
            return Buss;
        }



        public IEnumerable<invoice> GetAllinvoice()
        {
            var invoicelist = new List<invoice>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("invoicedata", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var Invoice = new invoice();
                    cmd.Parameters.AddWithValue("@invoice_id", Invoice.invoice_id);
                    cmd.Parameters.AddWithValue("@customer_id", Invoice.customer_id);
                    cmd.Parameters.AddWithValue("@room_id", Invoice.room_id);
                    cmd.Parameters.AddWithValue("@booking_id", Invoice.booking_id);
                    cmd.Parameters.AddWithValue("@days_of_stay", Invoice.days_of_stay);
                    cmd.Parameters.AddWithValue("@per_room", Invoice.per_room);
                    cmd.Parameters.AddWithValue("@no_of_rooms", Invoice.no_of_rooms);
                    cmd.Parameters.AddWithValue("@total_amt", Invoice.total_amt);
                    invoicelist.Add(Invoice);
                }
                con.Close();
            }
            return invoicelist;
        }

        public void InsertInvoice(invoice Invoice)

        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertRecord_invoice", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@invoice_id", Invoice.invoice_id);
                cmd.Parameters.AddWithValue("@customer_id", Invoice.customer_id);
                cmd.Parameters.AddWithValue("@room_id", Invoice.room_id);
                cmd.Parameters.AddWithValue("@booking_id", Invoice.booking_id);
                cmd.Parameters.AddWithValue("@days_of_stay", Invoice.days_of_stay);
                cmd.Parameters.AddWithValue("@per_room", Invoice.per_room);
                cmd.Parameters.AddWithValue("@no_of_rooms", Invoice.no_of_rooms);
                cmd.Parameters.AddWithValue("@total_amt", Invoice.total_amt);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }


        public void UpdateInvoice(invoice Invoice)

        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateRecord_invoice", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@invoice_id", Invoice.invoice_id);
                cmd.Parameters.AddWithValue("@customer_id", Invoice.customer_id);
                cmd.Parameters.AddWithValue("@room_id", Invoice.room_id);
                cmd.Parameters.AddWithValue("@booking_id", Invoice.booking_id);
                cmd.Parameters.AddWithValue("@days_of_stay", Invoice.days_of_stay);
                cmd.Parameters.AddWithValue("@per_room", Invoice.per_room);
                cmd.Parameters.AddWithValue("@no_of_rooms", Invoice.no_of_rooms);
                cmd.Parameters.AddWithValue("@total_amt", Invoice.total_amt);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public void DeleteInvoice(int? invoice_id)

        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteRecord_invoice", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@invoice_id", invoice_id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }


        public invoice GetInvoiceByid(int? invoice_id)

        {
            var Iuss = new invoice();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("getbyid_invoice", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@invoice_id", invoice_id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Iuss.invoice_id = Convert.ToInt32(dr["invoice_id"].ToString());
                    Iuss.customer_id = Convert.ToInt32(dr["customer_id"].ToString());
                    Iuss.booking_id = Convert.ToInt32(dr["booking_id"].ToString());
                    Iuss.room_id = Convert.ToInt32(dr["room_id"].ToString());
                    Iuss.days_of_stay = Convert.ToInt32(dr["days_of_stay"].ToString());
                    Iuss.per_room = Convert.ToInt32(dr["per_room"].ToString());
                    Iuss.no_of_rooms = Convert.ToInt32(dr["no_of_rooms"].ToString());
                    Iuss.total_amt = Iuss.days_of_stay* Iuss.per_room * Iuss.no_of_rooms;
                    Iuss.total_amt = Convert.ToInt32(dr["total_amt"].ToString());


                }
                con.Close();

            }
            return Iuss;
        }



    }


}

    

 