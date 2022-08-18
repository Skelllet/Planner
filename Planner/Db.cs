using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Planner.Model;

namespace Planner
{
    class Db : IDb
    {
        private string ConnectionStr = @"Data Source=LAPTOP-IN6OL7C4\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=True";
        public List<Admin> GetAllAdmin()
        {
            List<Admin> admins = new List<Admin>();
            string sql = "SELECT * from administrator";

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var admin = new Admin(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString());


                        admins.Add(admin);
                    }
                    reader.Close();
                }

            }
            return admins;
        }

        public List<Stadiumworkers> GetAllStadiumworkers()
        {
            List<Stadiumworkers> workers = new List<Stadiumworkers>();
            string sql = "SELECT * from stadiumworkers inner join  post on post.id = post_id " +
                "INNER JOIN field ON field.id = field_id INNER JOIN administrator On administrator.id = administrator_id";

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        var worker = new Stadiumworkers(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                            reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                            new Post(Convert.ToInt32(reader[9]), reader[10].ToString()),
                            new Field(Convert.ToInt32(reader[11]), reader[12].ToString(), DateTime.Parse(reader[13].ToString()), DateTime.Parse(reader[14].ToString()), reader[15].ToString(),
                            new Admin(Convert.ToInt32(reader[16]), reader[17].ToString(), reader[18].ToString(), reader[19].ToString(),
                            reader[20].ToString(), reader[21].ToString(), reader[22].ToString())));


                        workers.Add(worker);
                    }
                    reader.Close();
                }

            }
            return workers;


        }
        public List<Post> GetAllPositions()
        {
            List<Post> positions = new List<Post>();
            string sql = "SELECT * FROM post";

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Post position = new Post(Convert.ToInt32(reader[0]), reader[1].ToString());
                        positions.Add(position);
                    }
                    reader.Close();
                }

            }
            return positions;
        }
        public void AddWorker(Stadiumworkers stadiumworkers)
        {
            string sqlExpression = "insert into stadiumworkers (LastName, FirstName, MiddleName, PhoneNumber, Login, Password, Post_id, Field_id) " +
                "values (@LastName, @FirstName, @MiddleName, @PhoneNumber, @Login, @Password, @Post_id, @Field_id);";

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sqlExpression, conn))
                {
                    command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = stadiumworkers.LastName;
                    command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = stadiumworkers.FirstName;
                    command.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = stadiumworkers.MiddleName;
                    command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = stadiumworkers.PhoneNumber;
                    command.Parameters.Add("@Login", SqlDbType.VarChar).Value = stadiumworkers.Login;
                    command.Parameters.Add("@Password", SqlDbType.VarChar).Value = stadiumworkers.Password;
                    command.Parameters.Add("@Post_id", SqlDbType.Int).Value = stadiumworkers.Post.Id;
                    command.Parameters.Add("@Field_id", SqlDbType.Int).Value = stadiumworkers.Field.Id;

                    command.ExecuteNonQuery();
                }
            }
        }
        public Post GetPositionById(int id)
        {
            Post position = null;
            string sql = "SELECT * FROM post WHERE id = " + id;

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        position = new Post(Convert.ToInt32(reader[0]), reader[1].ToString());
                    }
                    reader.Close();
                }
            }

            return position;
        }

        public List<Field> GetAllFields()
        {
            List<Field> fields = new List<Field>();
            string sql = "SELECT  * from field inner  join  administrator on administrator.id = administrator_id;";

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        var field = new Field(Convert.ToInt32(reader[0]), reader[1].ToString(),
                            DateTime.Parse(reader[2].ToString()), DateTime.Parse(reader[3].ToString()), reader[4].ToString(),
                            new Admin(Convert.ToInt32(reader[6]), reader[7].ToString(), reader[8].ToString(),
                            reader[9].ToString(), reader[10].ToString(), reader[11].ToString(), reader[12].ToString()));


                        fields.Add(field);
                    }
                    reader.Close();
                }

            }
            return fields;
        }

        public Admin GetAdminById(int id)
        {
            Admin admin = null;
            string sql = "SELECT * FROM admin WHERE id = " + id;

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        admin = new Admin(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                            reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString());
                    }
                    reader.Close();
                }
            }

            return admin;
        }

        public Stadiumworkers GetStadiumById(int id)
        {
            Stadiumworkers stadium = null;
            string sql = "SELECT * from stadiumworkers inner join  post on post.id = post_id INNER JOIN field ON field.id = field_id " +
                "INNER JOIN administrator On administrator.id = administrator_id WHERE id = " + id;

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        stadium = new Stadiumworkers(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                            reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                            new Post(Convert.ToInt32(reader[9]), reader[10].ToString()),
                            new Field(Convert.ToInt32(reader[11]), reader[12].ToString(), DateTime.Parse(reader[13].ToString()), DateTime.Parse(reader[14].ToString()), reader[15].ToString(),
                            new Admin(Convert.ToInt32(reader[16]), reader[17].ToString(), reader[18].ToString(), reader[19].ToString(),
                            reader[20].ToString(), reader[21].ToString(), reader[22].ToString())));
                        reader.Close();
                    }
                }

                return stadium;
            }

        }

        public void AddAdmin(Admin admin)
        {
            string sqlExpression = "insert into administrator (LastName, FirstName, MiddleName, PhoneNumber, Login, Password) " +
                "values (@LastName, @FirstName, @MiddleName, @PhoneNumber, @Login, @Password);";

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sqlExpression, conn))
                {
                    command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = admin.LastName;
                    command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = admin.FirstName;
                    command.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = admin.MiddleName;
                    command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = admin.PhoneNumber;
                    command.Parameters.Add("@Login", SqlDbType.VarChar).Value = admin.Login;
                    command.Parameters.Add("@Password", SqlDbType.VarChar).Value = admin.Password;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddField(Field field)
        {
            string sqlExpression = "insert into field (Name, WorkingHoursTime, WorkingHoursTimeFinish, StadiumAdress, Administrator_id) " +
                "values (@Name, @WorkingHoursTime,@WorkingHoursTimeFinish, @StadiumAdress, @Administrator_id);";

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sqlExpression, conn))
                {
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = field.Name;
                    command.Parameters.Add("@WorkingHoursTime", SqlDbType.Time).Value = field.WorkingHoursTimeStart.TimeOfDay;
                    command.Parameters.Add("@WorkingHoursTimeFinish", SqlDbType.Time).Value = field.WorkingHoursTimeFinish.TimeOfDay;
                    command.Parameters.Add("@StadiumAdress", SqlDbType.VarChar).Value = field.StadiumAdress;
                    command.Parameters.Add("@Administrator_id", SqlDbType.Int).Value = field.Admin.Id;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateField(Field field)
        {
            string sql = "UPDATE field SET Name = @Name, WorkingHoursTime = @WorkingHoursTime, WorkingHoursTimeFinish = @WorkingHoursTimeFinish, StadiumAdress = @StadiumAdress, " +
                "Administrator_id = @Administrator_id WHERE id = @id";

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = field.Id;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = field.Name;
                    command.Parameters.Add("@WorkingHoursTime", SqlDbType.Time).Value = field.WorkingHoursTimeStart.TimeOfDay;
                    command.Parameters.Add("@WorkingHoursTimeFinish", SqlDbType.Time).Value = field.WorkingHoursTimeFinish.TimeOfDay;
                    command.Parameters.Add("@StadiumAdress", SqlDbType.VarChar).Value = field.StadiumAdress;
                    command.Parameters.Add("@Administrator_id", SqlDbType.Int).Value = field.Admin.Id;
                    command.ExecuteNonQuery();
                }
            }
        }

        public Field GetFieldById(int id)
        {
            Field field = null;
            string sql = "SELECT  * from field inner  join  administrator on administrator.id = administrator_id;";

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        field = new Field(Convert.ToInt32(reader[0]), reader[1].ToString(),
                            DateTime.Parse(reader[2].ToString()), DateTime.Parse(reader[3].ToString()), reader[4].ToString(),
                            new Admin(Convert.ToInt32(reader[6]), reader[7].ToString(), reader[8].ToString(),
                            reader[9].ToString(), reader[10].ToString(), reader[11].ToString(), reader[12].ToString()));
                    }
                    reader.Close();
                }

            }
            return field;
        }

        public List<Job> GetAllJobsByIdWorkers(int id)
        {
            List<Job> jobs = new List<Job>();
            string sql = "SELECT * from job INNER JOIN stadiumworkers ON stadiumworkers.id = job.stadiumworkers_id " +
                "inner join  post on post.id = stadiumworkers.post_id INNER JOIN field ON field.id = stadiumworkers.field_id " +
                "INNER JOIN administrator On administrator.id = field.administrator_id WHERE stadiumworkers_id = " + id;

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var job = new Job(Convert.ToInt32(reader[0]), reader[1].ToString(), Convert.ToBoolean(reader[2]),
                            DateTime.Parse(reader[3].ToString()), DateTime.Parse(reader[4].ToString()),

                            new Stadiumworkers(Convert.ToInt32(reader[6]), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(),
                            reader[10].ToString(), reader[11].ToString(), reader[12].ToString(),
                            new Post(Convert.ToInt32(reader[15]), reader[16].ToString()),
                            new Field(Convert.ToInt32(reader[17]), reader[18].ToString(), DateTime.Parse(reader[19].ToString()), DateTime.Parse(reader[20].ToString()), reader[21].ToString(),
                            new Admin(Convert.ToInt32(reader[23]), reader[24].ToString(), reader[25].ToString(), reader[26].ToString(),
                            reader[27].ToString(), reader[28].ToString(), reader[29].ToString()))));


                        jobs.Add(job);
                    }
                    reader.Close();
                }

            }
            return jobs;
        }

        public void updateJob(Job job)
        {
            string sql = "UPDATE job SET Name = @Name, IsDone = @IsDone, TimeIsDone = @TimeIsDone, " +
                "TimeConstraints = @TimeConstraints, StadiumWorkers_id = @StadiumWorkers_id WHERE id = @id";

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = job.Id;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = job.Name;
                    command.Parameters.Add("@IsDone", SqlDbType.Bit).Value = job.IsDone;
                    command.Parameters.Add("@TimeIsDone", SqlDbType.Time).Value = job.TimeIsDone.TimeOfDay;
                    command.Parameters.Add("@TimeConstraints", SqlDbType.DateTime).Value = job.TimeConstraints;
                    command.Parameters.Add("@StadiumWorkers_id", SqlDbType.Int).Value = job.Stadiumworkers.Id;
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Stadiumworkers> GetAllStadiumworkersByIdField(int id)
        {
            List<Stadiumworkers> workers = new List<Stadiumworkers>();
            string sql = "SELECT * from stadiumworkers inner join  post on post.id = post_id " +
                "INNER JOIN field ON field.id = field_id INNER JOIN administrator On administrator.id = administrator_id " +
                "WHERE field.id = " + id;

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        var worker = new Stadiumworkers(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                            reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                            new Post(Convert.ToInt32(reader[9]), reader[10].ToString()),
                            new Field(Convert.ToInt32(reader[11]), reader[12].ToString(), DateTime.Parse(reader[13].ToString()), DateTime.Parse(reader[14].ToString()), reader[15].ToString(),
                            new Admin(Convert.ToInt32(reader[16]), reader[17].ToString(), reader[18].ToString(), reader[19].ToString(),
                            reader[20].ToString(), reader[21].ToString(), reader[22].ToString())));


                        workers.Add(worker);
                    }
                    reader.Close();
                }

            }
            return workers;
        }

        public void AddJob(Job job)
        {
            string sqlExpression = "insert into job (Name, IsDone, TimeIsDone, TimeConstraints, StadiumWorkers_id) " +
                "values (@Name, @IsDone, @TimeIsDone, @TimeConstraints, @StadiumWorkers_id)";

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sqlExpression, conn))
                {
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = job.Name;
                    command.Parameters.Add("@IsDone", SqlDbType.Bit).Value = job.IsDone;
                    command.Parameters.Add("@TimeIsDone", SqlDbType.Time).Value = job.TimeIsDone.TimeOfDay;
                    command.Parameters.Add("@TimeConstraints", SqlDbType.DateTime).Value = job.TimeConstraints;
                    command.Parameters.Add("@StadiumWorkers_id", SqlDbType.Int).Value = job.Stadiumworkers.Id;

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Job> GetAllJobsByIdFields(int id)
        {
            List<Job> jobs = new List<Job>();
            string sql = "SELECT * from job INNER JOIN stadiumworkers ON stadiumworkers.id = job.stadiumworkers_id " +
                "inner join  post on post.id = stadiumworkers.post_id INNER JOIN field ON field.id = stadiumworkers.field_id " +
                "INNER JOIN administrator On administrator.id = field.administrator_id WHERE stadiumworkers.field_id = " + id;

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var job = new Job(Convert.ToInt32(reader[0]), reader[1].ToString(), Convert.ToBoolean(reader[2]),
                            DateTime.Parse(reader[3].ToString()), DateTime.Parse(reader[4].ToString()),

                            new Stadiumworkers(Convert.ToInt32(reader[6]), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(),
                            reader[10].ToString(), reader[11].ToString(), reader[12].ToString(),
                            new Post(Convert.ToInt32(reader[15]), reader[16].ToString()),
                            new Field(Convert.ToInt32(reader[17]), reader[18].ToString(), DateTime.Parse(reader[19].ToString()), DateTime.Parse(reader[20].ToString()), reader[21].ToString(),
                            new Admin(Convert.ToInt32(reader[23]), reader[24].ToString(), reader[25].ToString(), reader[26].ToString(),
                            reader[27].ToString(), reader[28].ToString(), reader[29].ToString()))));


                        jobs.Add(job);
                    }
                    reader.Close();
                }

            }
            return jobs;
        }

        public Field GetFieldByIdAdmin(int id)
        {
            Field field = null;
            string sql = "SELECT  * from field inner  join  administrator on administrator.id = administrator_id WHERE administrator_id = " + id;

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        field = new Field(Convert.ToInt32(reader[0]), reader[1].ToString(),
                            DateTime.Parse(reader[2].ToString()), DateTime.Parse(reader[3].ToString()), reader[4].ToString(),
                            new Admin(Convert.ToInt32(reader[6]), reader[7].ToString(), reader[8].ToString(),
                            reader[9].ToString(), reader[10].ToString(), reader[11].ToString(), reader[12].ToString()));
                    }
                    reader.Close();
                }

            }
            return field;
        }

        public void AddStorage(Storage storage)
        {
            string sqlExpression = "insert into storage (Name, Field_id) " +
                "values (@Name, @Field_id)";

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sqlExpression, conn))
                {
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = storage.Name;
                    command.Parameters.Add("@Field_id", SqlDbType.Int).Value = storage.Field.Id;

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Technic> GetAllTechnics(int id)
        {
            List<Technic> technics = new List<Technic>();
            string sql = "SELECT * FROM technic INNER JOIN storage ON Storage_id = storage.id " +
                "INNER JOIN company ON company.id = Company_id INNER JOIN field ON Field_id = field.id " +
                "INNER JOIN administrator ON administrator.id = Administrator_id WHERE field.id = " + id;

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        var technic = new Technic(Convert.ToInt32(reader[0]), reader[1].ToString(), Convert.ToInt32(reader[2]),
                            new Storage(Convert.ToInt32(reader[5]), reader[6].ToString(),
                            new Field(Convert.ToInt32(reader[12]), reader[13].ToString(), DateTime.Parse(reader[14].ToString()),
                            DateTime.Parse(reader[15].ToString()), reader[16].ToString(),
                            new Admin(Convert.ToInt32(reader[18]), reader[19].ToString(), reader[20].ToString(), reader[21].ToString(),
                            reader[22].ToString(), reader[23].ToString(), reader[24].ToString()))));


                        technics.Add(technic);
                    }
                    reader.Close();
                }

            }
            return technics;
        }

        public List<Fertilizers> GetAllFertilizers(int id)
        {
            List<Fertilizers> fertilizers = new List<Fertilizers>();
            string sql = "SELECT * FROM fertilizers INNER JOIN storage ON Storage_id = storage.id " +
                "INNER JOIN company ON company.id = Company_id INNER JOIN field ON Field_id = field.id " +
                "INNER JOIN administrator ON administrator.id = Administrator_id WHERE field.id = " + id;

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        var fertilizer = new Fertilizers(Convert.ToInt32(reader[0]), reader[1].ToString(), Convert.ToInt32(reader[2]),
                            new Storage(Convert.ToInt32(reader[5]), reader[6].ToString(),
                            new Field(Convert.ToInt32(reader[12]), reader[13].ToString(), DateTime.Parse(reader[14].ToString()),
                            DateTime.Parse(reader[15].ToString()), reader[16].ToString(),
                            new Admin(Convert.ToInt32(reader[18]), reader[19].ToString(), reader[20].ToString(), reader[21].ToString(),
                            reader[22].ToString(), reader[23].ToString(), reader[24].ToString()))));


                        fertilizers.Add(fertilizer);
                    }
                    reader.Close();
                }

            }
            return fertilizers;
        }

        public List<Inventory> GetAllInventory(int id)
        {
            List<Inventory> inventories = new List<Inventory>();
            string sql = "SELECT * FROM inventory INNER JOIN storage ON Storage_id = storage.id " +
                "INNER JOIN company ON company.id = Company_id INNER JOIN field ON Field_id = field.id " +
                "INNER JOIN administrator ON administrator.id = Administrator_id WHERE field.id = " + id;

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        var inventorie = new Inventory(Convert.ToInt32(reader[0]), reader[1].ToString(), Convert.ToInt32(reader[2]),
                            new Storage(Convert.ToInt32(reader[5]), reader[6].ToString(),
                            new Field(Convert.ToInt32(reader[12]), reader[13].ToString(), DateTime.Parse(reader[14].ToString()),
                            DateTime.Parse(reader[15].ToString()), reader[16].ToString(),
                            new Admin(Convert.ToInt32(reader[18]), reader[19].ToString(), reader[20].ToString(), reader[21].ToString(),
                            reader[22].ToString(), reader[23].ToString(), reader[24].ToString()))));


                        inventories.Add(inventorie);
                    }
                    reader.Close();
                }

            }
            return inventories;
        }

        public List<Storage> GetAllStorageByIdField(int id)
        {
            List<Storage> storages = new List<Storage>();
            string sql = "SELECT * FROM storage INNER JOIN field ON Field_id = field.id " +
                "INNER JOIN administrator ON administrator.id = Administrator_id WHERE field.id = " + id;

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        var storage = new Storage(Convert.ToInt32(reader[0]), reader[1].ToString(),
                            new Field(Convert.ToInt32(reader[3]), reader[4].ToString(), DateTime.Parse(reader[5].ToString()),
                            DateTime.Parse(reader[6].ToString()), reader[7].ToString(),
                            new Admin(Convert.ToInt32(reader[9]), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(),
                            reader[13].ToString(), reader[14].ToString(), reader[15].ToString())));


                        storages.Add(storage);
                    }
                    reader.Close();
                }

            }
            return storages;
        }

        public void AddTechnics(Technic technic)
        {
            string sqlExpression = "insert into technic (Name, Count, Storage_id, Company_id) " +
                "values (@Name, @Count,@Storage_id, @Company_id)";

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sqlExpression, conn))
                {
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = technic.Name;
                    command.Parameters.Add("@Count", SqlDbType.Int).Value = technic.Count;
                    command.Parameters.Add("@Storage_id", SqlDbType.Int).Value = technic.Storage.Id;
                    command.Parameters.Add("@Company_id", SqlDbType.Int).Value = 1;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddFertilizers(Fertilizers fertilizers)
        {
            string sqlExpression = "insert into fertilizers (Name, Count, Storage_id, Company_id) values (@Name, @Count, @Storage_id, @Company_id)";

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sqlExpression, conn))
                {
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = fertilizers.Name;
                    command.Parameters.Add("@Count", SqlDbType.Int).Value = fertilizers.Count;
                    command.Parameters.Add("@Storage_id", SqlDbType.Int).Value = fertilizers.Storage.Id;
                    command.Parameters.Add("@Company_id", SqlDbType.Int).Value = 1;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddAllInventory(Inventory inventory)
        {
            string sqlExpression = "insert into inventory (Name, Count, Storage_id, Company_id) values (@Name, @Count, @Storage_id, @Company_id)";

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sqlExpression, conn))
                {
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = inventory.Name;
                    command.Parameters.Add("@Count", SqlDbType.Int).Value = inventory.Count;
                    command.Parameters.Add("@Storage_id", SqlDbType.Int).Value = inventory.Storage.Id;
                    command.Parameters.Add("@Company_id", SqlDbType.Int).Value = 1;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateTechnics(Technic technic)
        {
            string sqlExpression = "UPDATE technic SET Name = @Name, Count = @Count, Storage_id = @Storage_id, Company_id = @Company_id WHERE id = @id";

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sqlExpression, conn))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = technic.Id;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = technic.Name;
                    command.Parameters.Add("@Count", SqlDbType.Int).Value = technic.Count;
                    command.Parameters.Add("@Storage_id", SqlDbType.Int).Value = technic.Storage.Id;
                    command.Parameters.Add("@Company_id", SqlDbType.Int).Value = 1;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateFertilizers(Fertilizers fertilizers)
        {
            string sqlExpression = "UPDATE fertilizers SET Name = @Name, Count = @Count, Storage_id = @Storage_id, Company_id = @Company_id WHERE id = @id";

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sqlExpression, conn))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = fertilizers.Id;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = fertilizers.Name;
                    command.Parameters.Add("@Count", SqlDbType.Int).Value = fertilizers.Count;
                    command.Parameters.Add("@Storage_id", SqlDbType.Int).Value = fertilizers.Storage.Id;
                    command.Parameters.Add("@Company_id", SqlDbType.Int).Value = 1;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateInventory(Inventory inventory)
        {
            string sqlExpression = "UPDATE inventory SET Name = @Name, Count = @Count, Storage_id = @Storage_id, Company_id = @Company_id WHERE id = @id";

            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sqlExpression, conn))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = inventory.Id;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = inventory.Name;
                    command.Parameters.Add("@Count", SqlDbType.Int).Value = inventory.Count;
                    command.Parameters.Add("@Storage_id", SqlDbType.Int).Value = inventory.Storage.Id;
                    command.Parameters.Add("@Company_id", SqlDbType.Int).Value = 1;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
