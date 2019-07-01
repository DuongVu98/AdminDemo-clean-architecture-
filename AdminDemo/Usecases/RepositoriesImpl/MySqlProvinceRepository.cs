using System;
using System.Collections.Generic;
using System.Data.Common;
using AdminDemo.Domains.Entities;
using AdminDemo.Usecases.DatabaseConfiguration;
using AdminDemo.Usecases.Repositories;
using MySql.Data.MySqlClient;

namespace AdminDemo.Usecases.RepositoriesImpl
{
    public class MySqlProvinceRepository : IRepository<Province>
    {
        private MySqlConnection _connection = DatabaseConnectionConfiguration.GetDatabaseConnection();
        public List<Province> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public List<Province> FindOnePart(int limit)
        {
            throw new NotImplementedException();
        }

        public Province FindById(string id)
        {
            Province province = new Province();

            try
            {
                _connection.Open();

                string sql = "select * from provinces where id=@id";

                MySqlCommand command = new MySqlCommand(sql, _connection);
                command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.VarChar)).Value = id;

                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        string provinceName = reader.GetString(reader.GetOrdinal("province_name"));
                        string provinceCode = reader.GetString(reader.GetOrdinal("province_code"));
                        string countryId = reader.GetString(reader.GetOrdinal("countries_id"));

                        province = new Province(id, provinceName, provinceCode, countryId);
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
            
            return province;
        }

        public void Create(Province t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Province t)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Province t)
        {
            throw new System.NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}