using connection.repositories;
using System;
using System.Data.SqlClient;
using connection.repositories.Data;

namespace connection
{
    class Program
    {
	//test perubahan code
        static Data data = new Data();
        static void Main(string[] args)
        {
            bool jalan = true;

            while (jalan)
            {
                Console.Clear();
                mainMenu();
                int pilihan = int.Parse(Console.ReadLine());

                GeneralRepository general = new GeneralRepository();
                


                try
                {
                    switch (pilihan)
                    {
                        case 1:
                            Console.Clear();
                            SqlDataReader dataReader = data.getAll() ;

                            while (dataReader.Read())
                            {
                                Console.WriteLine("============================================");
                                Console.WriteLine("ID   : " + dataReader.GetValue(0).ToString());
                                Console.WriteLine("Nama : " + dataReader.GetValue(1).ToString());
                                Console.WriteLine("Umur : " + dataReader.GetValue(2).ToString());
                                Console.WriteLine("============================================");
                            }
                            
                            data.conn.Close();
                            wait();
                            break;
                        case 2:
                            Console.Clear();
                            Console.Write("Masukan Nama : ");
                            string userName = Console.ReadLine();
                            Console.Write("Masukan Umur : ");
                            int userAge = int.Parse(Console.ReadLine());
                            general.Insert(userName, userAge);
                            wait();
                            break;
                        case 3:
                            Console.Clear();
                            general.Update();
                            wait();
                            break;
                        case 4:
                            Console.Clear();
                            general.Delete();
                            wait();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Aplikasi Berhenti!");
                            jalan = false;
                            wait();
                            break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                
            }
        }

        public static void mainMenu()
        {
            Console.WriteLine("====================CRUD====================");
            Console.WriteLine("1. Lihat Data");
            Console.WriteLine("2. Tambah Data");
            Console.WriteLine("3. Edit Data");
            Console.WriteLine("4. Hapus Data");
            Console.WriteLine("5. Exit");

            Console.Write("Pilih Menu : ");
        }

        public static void wait()
        {
            Console.WriteLine("Tekan tombol ENTER untuk kembali ke menu utama");
            Console.ReadLine();
        }
    }
}
