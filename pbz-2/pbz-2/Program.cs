using System;
using System.Data.Common;
using MySqlConnector;

namespace pbz_2
{
    class Program
    {
        public static MySqlConnection conn;
        static void Main(string[] args)
        {
            conn = GetConnection("localhost", 3306, "lab2", "root", "1111");
            conn.Open();


            // AddWorker("Иванов Иван", "Майор", "проверяющий");
            // EditWorker("Иванов Иван", "Майор", "главный проверяющий");
            // DeleteWorker("Иванов Иван");

            //AddOwner("Петров Петр", "", "", 1999, 8765);
            // EditOwner("Петров Петр", "", "", 1989, 8765);
            // DeleteOwner(8765);

            //AddInspection("Петров Петр", "01.03.2010", "ok", 1328);
            //EditInspection(1,"Петров Петр", "01.03.2010", "not ok", 1328);
            //DeleteInspection(1);

            // AddCar(645, 444, "green", "lada", 1328);
            // EditCar(645,446, "green", "lada", 1328);
            //DeleteCar(645);

            // Console.WriteLine(CarCount("2010.12.12", "2000.01.01"));
            // Console.WriteLine(CarCount("2000.12.12", "2000.01.01"));

            // AddInspection("Петров Петр", "01.03.2010", "ok", 1328);
            // AddInspection("Петров Петр", "11.03.2011", "ok", 1328);
            // AddInspection("Петров Петр", "03.04.2012", "ok", 1328);
            // AddInspection("Петров Петр", "09.01.2019", "ok", 1328);
            //AddCar(1328, 444, "green", "lada",123);

            // GetCarHistory(444);


            //AddInspection("Петров Петр", "01.03.2010", "ok", 1328);
            //AddInspection("Петров Петр Петрович", "01.03.2010", "ok", 1328);
            //AddInspection("Петров Петр Иванович", "01.03.2010", "ok", 1328);
            //AddInspection("Петров Петр Васильевич", "01.03.2010", "ok", 1328);
            //AddInspection("Петров Петр Петрович", "01.03.2010", "ok", 2328);
            //AddInspection("Петров Петр Иванович", "01.03.2010", "ok", 4328);
            //AddInspection("Петров Петр Васильевич", "01.03.2010", "ok", 5328);
            //AddWorker("Петров Петр Петрович", "Младший лейтенант ", "проверяющий");
            //AddWorker("Петров Петр Иванович", "Майор", "главный проверяющий");
            //AddWorker("Петров Петр Васильевич", "Подполковник", "самый главный проверяющий");

           // GetDayInfo("01.03.2010");
           // GetDayInfo("11.03.2011");


            conn.Close();


        } 
        
      

        #region workers
        public static void AddWorker(string name,string rank,string position)
        {           
            string query = string.Format( "INSERT INTO workers (worker_name,worker_rank,worker_position) VALUES ('{0}', '{1}', '{2}')",name,rank,position);           
            MySqlCommand command1 = new MySqlCommand(query, conn);          
            command1.ExecuteNonQuery();
        }

        public static void EditWorker(string name, string rank, string position)
        {
            string query = string.Format("Update workers SET worker_name='{0}',worker_rank='{1}',worker_position='{2}' where worker_name='{0}'", name, rank, position);
            MySqlCommand command1 = new MySqlCommand(query, conn);
            command1.ExecuteNonQuery();
        }
        public static void DeleteWorker(string name)
        {
            string query = string.Format("DELETE FROM workers WHERE worker_name='{0}'", name);
            MySqlCommand command1 = new MySqlCommand(query, conn);
            command1.ExecuteNonQuery();
        }
        #endregion

        #region Inspections

        public static void AddInspection(string inspector, string date, string inspection_result,int car_reg_number)
        {
            string query = string.Format("INSERT INTO inspections (inspector,date,inspection_result,car_reg_number) VALUES ('{0}', '{1}', '{2}', '{3}')", inspector, date, inspection_result, car_reg_number);
            MySqlCommand command1 = new MySqlCommand(query, conn);
            command1.ExecuteNonQuery();
        }

        public static void EditInspection(int inspection_id, string inspector, string date, string inspection_result, int car_reg_number)
        {
            string query = string.Format("Update inspections SET inspector='{0}',date='{1}',inspection_result='{2}',car_reg_number={3} WHERE inspection_id={4}", inspector, date, inspection_result, car_reg_number,inspection_id);
            MySqlCommand command1 = new MySqlCommand(query, conn);
            command1.ExecuteNonQuery();
        }
        public static void DeleteInspection(int inspection_id)
        {
            string query = string.Format("DELETE FROM inspections WHERE inspection_id={0}", inspection_id);
            MySqlCommand command1 = new MySqlCommand(query, conn);
            command1.ExecuteNonQuery();
        }
        #endregion

        #region car owners

        //`owner_name,owner_adress,owner_sex,owner_birth_yearowner_license` int NOT NULL,
        //PRIMARY KEY(`owner_license`),

        public static void AddOwner(string owner_name, string owner_adress, string owner_sex, int owner_birth_year, int owner_license)
        {
            string query = string.Format(
                "INSERT INTO car_owner (owner_name, owner_adress, owner_sex, owner_birth_year,owner_license) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                owner_name, owner_adress, owner_sex, owner_birth_year,owner_license);

            MySqlCommand command1 = new MySqlCommand(query, conn);
            command1.ExecuteNonQuery();
        }

        public static void EditOwner(string owner_name, string owner_adress, string owner_sex,  int owner_birth_year, int owner_license)
        {
            string query = string.Format(
                "Update car_owner SET owner_name='{0}', owner_adress='{1}', owner_sex='{2}', owner_birth_year={3},owner_license={4} where owner_license={4}",
                owner_name, owner_adress, owner_sex, owner_birth_year,owner_license);
            MySqlCommand command1 = new MySqlCommand(query, conn);
            command1.ExecuteNonQuery();
        }
        public static void DeleteOwner(int owner_license)
        {
            string query = string.Format("DELETE FROM car_owner WHERE owner_license={0}", owner_license);
            MySqlCommand command1 = new MySqlCommand(query, conn);
            command1.ExecuteNonQuery();
        }
        #endregion

        #region cars
        //car_reg_number,car_engine_id,car_color,car_model,car_tech_pass_number

        public static void AddCar(int car_reg_number,int  car_engine_id,string car_color,string car_model, int car_tech_pass_number)
        {
            string query = "INSERT INTO cars (car_reg_number,car_engine_id,car_color,car_model,car_tech_pass_number) " +
                $"VALUES ('{car_reg_number}', '{car_engine_id}', '{car_color}', '{car_model}', '{car_tech_pass_number}')";

            MySqlCommand command1 = new MySqlCommand(query, conn);
            command1.ExecuteNonQuery();
        }

        public static void EditCar(int car_reg_number, int car_engine_id, string car_color, string car_model, int car_tech_pass_number)
        {
            string query = 
                $"Update cars SET car_reg_number='{car_reg_number}',car_engine_id='{car_engine_id}',car_color='{car_color}',car_model='{car_model}',car_tech_pass_number='{car_tech_pass_number}'" +
                $" where car_reg_number='{car_reg_number}'";
            MySqlCommand command1 = new MySqlCommand(query, conn);
            command1.ExecuteNonQuery();
        }
        public static void DeleteCar(int car_reg_number)
        {
            string query = $"DELETE FROM cars WHERE car_reg_number={car_reg_number}";
            MySqlCommand command1 = new MySqlCommand(query, conn);
            command1.ExecuteNonQuery();
        }
        #endregion

        static int CarCount(string dateStart,string dateEnd)
        {
            string sql = $"SELECT count(*) FROM lab2.inspections where inspections.date < '{dateStart}' and '{dateStart}'";
            MySqlCommand command = new MySqlCommand(sql, conn);
            return (int)(Int64)command.ExecuteScalar();
        }

        static string GetCarHistory(int engine_id)
        {
            string sql =
                @$"SELECT inspections.date,inspections.inspection_result
                FROM inspections
                JOIN cars
                ON cars.car_reg_number = inspections.car_reg_number
                WHERE cars.car_engine_id ={engine_id}";

            MySqlCommand command = new MySqlCommand(sql, conn);

            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString());
            }
            reader.Close(); // закрываем reader

            return "";
        }

        static string GetDayInfo(string date)
        {
            string sql =
                @$"SELECT 
                workers.worker_name,
                 workers.worker_rank,
                inspections.car_reg_number
                FROM inspections
                JOIN workers
                ON workers.worker_name=inspections.inspector
                WHERE inspections.date='{date}'";

            MySqlCommand command = new MySqlCommand(sql, conn);

            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString()+ " " + reader[2].ToString());
            }
            reader.Close(); // закрываем reader

            return "";
        }


        public static MySqlConnection GetConnection(string host, int port, string database, string username, string password)
        {
            string connString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
    }
}
