using System;
using System.Collections.Generic;
using System.Data.Common;
using AdminDemo.Domains.Entities;
using AdminDemo.Usecases.DatabaseConfiguration;
using AdminDemo.Usecases.Repositories;
using MySql.Data.MySqlClient;

namespace AdminDemo.Usecases.RepositoriesImpl
{
    public class MySqlCountryRepository : IRepository<Country>
    {
        private MySqlConnection _connection = DatabaseConnectionConfiguration.GetDatabaseConnection();
        
        public List<Country> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Country FindById(string id)
        {
            Country country = new Country();

            try
            {
                _connection.Open();

                string sql = "select * from countries where id=@id";

                MySqlCommand command = new MySqlCommand(sql, _connection);
                command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.VarChar)).Value = id;

                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        string countryName = reader.GetString(reader.GetOrdinal("country_name"));
                        string countryCode = reader.GetString(reader.GetOrdinal("country_code"));

                        country = new Country(id, countryName, countryCode);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);

            }
            finally
            {
                _connection.Close();
            }
            
            return country;
        }

        public void Create(Country t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Country t)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Country t)
        {
            throw new System.NotImplementedException();
        }
    }
}