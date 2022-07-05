using MySql.Data.MySqlClient;
using System.Data;
using TicketTracking.Models;

namespace TicketTracking.DB
{
    public static class DataBase
    {
        public static MySqlConnection conn = new MySqlConnection();
        static DataBase()
        {
            string connString = "server=127.0.0.1;port=3306;user id=root;database=tickettracking;charset=utf8;";
            conn.ConnectionString = connString;
        }

        public static DataTable SQLExecute(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenDB();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                adapter.Fill(dt);
                CloseDB();
            }
            catch (Exception ee)
            {
                CloseDB();
                Console.WriteLine(ee);
            }

            return dt;
        }

        public static User Login(string account, string password)
        {
            User user = new User();
            string sql = @$" SELECT * FROM `user` WHERE `account`='{account}' AND `password`='{password}' ";
            DataTable dt = DataBase.SQLExecute(sql);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                #pragma warning disable CS8604 // 可能有 Null 參考引數。
                user.SetUser(row["id"].ToString(), row["account"].ToString(), row["password"].ToString(), row["level"].ToString());
                #pragma warning restore CS8604 // 可能有 Null 參考引數。
            }

            return user;
        }

        public static List<Bug> BugList()
        {
            List<Bug> list = new List<Bug>();
            string sql = @$" SELECT * FROM `bugs`";
            try
            {
                OpenDB();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Bug bug = new Bug();
                        #pragma warning disable CS8601 // 可能有 Null 參考指派。
                        bug.Id = dr["id"].ToString();
                        bug.Name = dr["name"].ToString();
                        bug.IsResolved = (bool)dr["isResolved"];
                        bug.IsDel = (bool)dr["isDel"];
                        bug.Statement = dr["statement"].ToString();
                        list.Add(bug);
                        #pragma warning restore CS8601 // 可能有 Null 參考指派。
                    }
                }
                CloseDB();
            }
            catch (Exception ee)
            {
                CloseDB();
                Console.WriteLine(ee);
            }

            return list;
        }

        public static bool BugCreate(string name, string statement, string userid)
        {
            if (CheckLevel(userid) != "QA")
                return false;

            string sql = @$"INSERT INTO `bugs` (`id`, `name`, `statement`, `isResolved`, `isDel`) VALUES (NULL, '{name}', '{statement}', '0', '0')";
            try
            {
                OpenDB();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                CloseDB();
                return true;
            }
            catch (Exception ee)
            {
                CloseDB();
                Console.WriteLine(ee);
                return false;
            }
        }

        public static bool BugEdit(string id, string name, string statement, string userid)
        {
            if (CheckLevel(userid) != "QA")
                return false;

            string sql = @$"UPDATE `bugs` SET `name` = '{name}', `statement` = '{statement}' WHERE `bugs`.`id` = {id}";
            try
            {
                OpenDB();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                CloseDB();
                return true;
            }
            catch (Exception ee)
            {
                CloseDB();
                Console.WriteLine(ee);
                return false;
            }
        }

        public static bool BugResolve(string id, string userid)
        {
            if (CheckLevel(userid) != "RD")
                return false;

            string sql = @$"UPDATE `bugs` SET `isResolved` = '1' WHERE `bugs`.`id` = {id}";
            try
            {
                OpenDB();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                CloseDB();
                return true;
            }
            catch (Exception ee)
            {
                CloseDB();
                Console.WriteLine(ee);
                return false;
            }
        }

        public static bool BugDelete(string id, string userid)
        {
            if (CheckLevel(userid) != "QA")
                return false;

            string sql = @$"UPDATE `bugs` SET `isDel` = '1' WHERE `bugs`.`id` = {id}";
            try
            {
                OpenDB();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                CloseDB();
                return true;
            }
            catch (Exception ee)
            {
                CloseDB();
                Console.WriteLine(ee);
                return false;
            }
        }

        private static string CheckLevel(string userid)
        {
            string sql = @$"SELECT * FROM `user` WHERE `id` = {userid}";
            string level = "";
            try
            {
                OpenDB();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        #pragma warning disable CS8600 // 正在將 Null 常值或可能的 Null 值轉換為不可為 Null 的型別。
                        level = dr["level"].ToString();
                        #pragma warning restore CS8600 // 正在將 Null 常值或可能的 Null 值轉換為不可為 Null 的型別。
                    }
                }
                CloseDB();
            }
            catch (Exception ee)
            {
                CloseDB();
                Console.WriteLine(ee);
            }

            #pragma warning disable CS8603 // 可能有 Null 參考傳回。
            return level;
            #pragma warning restore CS8603 // 可能有 Null 參考傳回。
        }

        // 開啟DB
        private static void OpenDB()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }

        // 關閉DB
        private static void CloseDB()
        {
            if (conn.State != ConnectionState.Closed)
                conn.Close();
        }
    }
}
