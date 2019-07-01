using System;
using System.Collections.Generic;
using System.Data.Common;
using AdminDemo.Domains.Entities;
using AdminDemo.Usecases.DatabaseConfiguration;
using AdminDemo.Usecases.Repositories;
using MySql.Data.MySqlClient;

namespace AdminDemo.Usecases.RepositoriesImpl
{
    public class MySqlUserRepository : IRepository<User>
    {
        private MySqlConnection _connection = DatabaseConnectionConfiguration.GetDatabaseConnection();

        
        public List<User> FindAll()
        {
            List<User> users = new List<User>();
            try
            {
                _connection.Open();
            
                
                string sql = "select * from users";
            
                MySqlCommand command = new MySqlCommand(sql, _connection);
                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string id = reader.GetString(reader.GetOrdinal("id"));
                        string username = reader.GetString(reader.GetOrdinal("user_name"));
                        string password = reader.GetString(reader.GetOrdinal("password"));
                        string firstName = reader.GetString(reader.GetOrdinal("first_name"));
                        string lastName = reader.GetString(reader.GetOrdinal("last_name"));
                        DateTime birthDate = reader.GetDateTime(reader.GetOrdinal("birth_date"));
                        string address = reader.GetString(reader.GetOrdinal("address"));
                        string provinceId = reader.GetString(reader.GetOrdinal("provinces_id"));
                    
                        users.Add(new User(id, username, password, firstName, lastName,birthDate, address, provinceId));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e);   
            }
            finally
            {
                _connection.Close();
            }
            
            return users;
            
        }

        public List<User> FindOnePart(int limit)
        {
            throw new NotImplementedException();
        }

        public User FindById(string id)
        {
            User user = new User();
            
            try
            {
                _connection.Open();
                
                
                string sql = "select * from users where id = @id";
            
                MySqlCommand command = new MySqlCommand(sql, _connection);
                command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.VarChar)).Value = id;
            
                DbDataReader reader = command.ExecuteReader();
            
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string username = reader.GetString(reader.GetOrdinal("user_name"));
                        string password = reader.GetString(reader.GetOrdinal("password"));
                        string firstName = reader.GetString(reader.GetOrdinal("first_name"));
                        string lastName = reader.GetString(reader.GetOrdinal("last_name"));
                        DateTime birthDate = reader.GetDateTime(reader.GetOrdinal("birth_date"));
                        string address = reader.GetString(reader.GetOrdinal("address"));
                        string provinceId = reader.GetString(reader.GetOrdinal("provinces_id"));
                    
                        user = new User(id, username, password, firstName, lastName,birthDate, address, provinceId);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e);
            }
            finally
            {
                _connection.Close();
            }
            
            
            
            return user;
        }

        public void Create(User user)
        {
            throw new System.NotImplementedException();
        }

        public void Update(User user)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}