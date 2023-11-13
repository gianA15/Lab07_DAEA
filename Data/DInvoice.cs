using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public class DInvoice
    {
        private readonly string connectionString = "Data Source=LAPTOP-ONLL0VT1\\SQLEXPRESS;Initial Catalog=FacturaDB;User ID=garce;Password=admin123";

        public List<Invoice> Get()
        {
            List<Invoice> invoices = new List<Invoice>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("listar_invoices", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Invoice invoice = new Invoice
                            {
                                invoice_id = (int)reader["Invoice_id"],
                                customer_id = (int)reader["Customer_id"],
                                date = (DateTime)reader["Date"],
                                total = (decimal)reader["Total"],
                                active = (bool)reader["Active"]
                            };
                            invoices.Add(invoice);
                        }
                    }
                }
            }
            return invoices;
        }
        public void DeleteInvoice(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("eliminar_invoices", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@invoice_id", SqlDbType.Int));
                    command.Parameters["@invoice_id"].Value = id;

                    command.ExecuteNonQuery();
                }
            }
        }

        public bool insert(Invoice invoice)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertInvoice", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@customer_id", invoice.customer_id);
                    command.Parameters.AddWithValue("@date", invoice.date);
                    command.Parameters.AddWithValue("@total", invoice.total);
                    command.Parameters.AddWithValue("@active", invoice.active);

                    command.ExecuteNonQuery();
                }
            }
            return true;
        }
        public bool eliminar(int invoiceID)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UpdateActiveStatus", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RecordID", invoiceID);

                    int rowsAffected = command.ExecuteNonQuery();


                }
            }
            return true;
        }

    }
}
