using Contacts.Model;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Repository
{
    public class ContactRepo : IContact
    {
        //private string sqlConnction = @"Data Source=(localdb)\MsSqllocalDb;Initial Catalog=Exam;Integrated Security=True;Pooling=False";

        private IConfiguration Configuration;

        public ContactRepo(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        
        public void AddContact(Users users)
        {
            string sqlConnction = Configuration.GetConnectionString("myDb1");
            using (SqlConnection cn = new SqlConnection(sqlConnction))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "addUserDetails";
                cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = users.UserName;
                cmd.Parameters.Add("@UserMobileNo", SqlDbType.Int).Value = users.MobileNo;
                cmd.Parameters.Add("@UserEmailId", SqlDbType.VarChar).Value = users.EmailId;
                cmd.Parameters.Add("@UserHouseNo", SqlDbType.Int).Value = users.address.HouseNo;
                cmd.Parameters.Add("@UserCity", SqlDbType.VarChar).Value = users.address.City;
                cmd.Parameters.Add("@UserState", SqlDbType.VarChar).Value = users.address.State;
                cmd.Parameters.Add("@UserCountry", SqlDbType.VarChar).Value = users.address.Country;
                cmd.ExecuteNonQuery();
                cn.Close();
            }


        }


        public List<Users> GetAllConatct()
        {
            string sqlConnction = Configuration.GetConnectionString("myDb1");

            List<Users> list = new List<Users>();


            using (SqlConnection cn = new SqlConnection(sqlConnction))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getAllUserDetails";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    
                    Users ct = new Users
                    {
                        UserId=Convert.ToInt32(dr["user_Id"]),
                        UserName= Convert.ToString(dr["user_name"]),
                        MobileNo = Convert.ToInt32(dr["mobile_No"]),
                        EmailId = Convert.ToString(dr["email_Id"]),
                        address = new Address{
                            HouseNo = Convert.ToInt32(dr["house_No"]),
                            City = Convert.ToString(dr["city"]),
                            State = Convert.ToString(dr["state"]),
                            Country = Convert.ToString(dr["country"])
                        }        
                        

                    };

                    list.Add(ct);
                }

                dr.Close();
                cn.Close();
            }


            return list;
        }

        public Users GetContactByMobileNo(int mobileNo)
        {
            string sqlConnction = Configuration.GetConnectionString("myDb1");
            Users users=null;
            using (SqlConnection cn = new SqlConnection(sqlConnction))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getUsers";
                cmd.Parameters.Add("@mobiledetails",SqlDbType.Int).Value=mobileNo;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    users = new Users
                    {
                        UserId = Convert.ToInt32(dr["user_Id"]),
                        UserName = Convert.ToString(dr["user_name"]),
                        MobileNo = Convert.ToInt32(dr["mobile_No"]),
                        EmailId= Convert.ToString(dr["email_Id"]),
                        address = new Address
                        {
                            HouseNo = Convert.ToInt32(dr["house_No"]),
                            City = Convert.ToString(dr["city"]),
                            State = Convert.ToString(dr["state"]),
                            Country = Convert.ToString(dr["country"])
                        }
                    };

                    
                }

                dr.Close();
                cn.Close();

               
            }
            return users;

        }
    }
}
