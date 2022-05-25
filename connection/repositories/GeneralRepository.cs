using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using connection.model;
using connection.repositories.Interface;

namespace connection.repositories
{
    class GeneralRepository : InterfacePegawai
    {
        public SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-OONRB3GT;Initial Catalog=CRUD;User ID=sa;Password=qwertyuiop123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"); 

        protected string namaTabel;

        public SqlDataReader getAll()
        {

            conn.Open();
            Console.WriteLine("Connection established successfully!");
            //string displayQuery = "SELECT * FROM "+namaTabel, conn;
            SqlCommand displayCommand = new SqlCommand("SELECT * FROM " + namaTabel, conn);
            return displayCommand.ExecuteReader();
            
        }

        public void Insert(string userName, int userAge)
        {
            modelPegawai model = new modelPegawai();
            conn.Open();
            string insertQuery = $"INSERT INTO Details(user_name, user_age) VALUES('{userName}','{userAge}')";
            SqlCommand insertCommand = new SqlCommand(insertQuery, conn); ;
            insertCommand.ExecuteNonQuery();
            conn.Close();
        }

        public void Update()
        {
            conn.Open();
            string updateQuery = "UPDATE Details SET user_name = 'Agus', user_age = '22' WHERE user_id = '1'";
            SqlCommand updateCommand = new SqlCommand(updateQuery, conn);
            updateCommand.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete()
        {
            conn.Open();
            string deleteQuery = "DELETE Details WHERE user_id ='3'";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, conn);
            deleteCommand.ExecuteNonQuery();
            conn.Close();
        }

        public void getById()
        {
            throw new NotImplementedException();
        }
    }
}
