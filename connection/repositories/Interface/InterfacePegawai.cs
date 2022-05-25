using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace connection.repositories.Interface
{
    interface InterfacePegawai
    {
        public SqlDataReader getAll();
        void getById();
        void Insert();
        void Update();
        void Delete();

        
    }
}
