using System;
using System.Collections.Generic;
using System.Data.Common;
using AdminDemo.Domains.Entities;
using AdminDemo.Usecases.DatabaseConfiguration;
using AdminDemo.Usecases.Repositories;
using MySql.Data.MySqlClient;

namespace AdminDemo.Usecases.RepositoriesImpl
{
    public class MySqlTransactionRepository : IRepository<Transaction>
    {
        private MySqlConnection _connection = DatabaseConnectionConfiguration.GetDatabaseConnection();

        public List<Transaction> FindAll()
        {
            List<Transaction> transactions = new List<Transaction>();
            
            try
            {
                _connection.Open();
            
            
                string sql = "select * from transactions";
            
                MySqlCommand command = new MySqlCommand(sql, _connection);
                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string id = reader.GetString(reader.GetOrdinal("id"));
                        string userId = reader.GetString(reader.GetOrdinal("users_id"));
                        string hash = reader.GetString(reader.GetOrdinal("hash"));
                        string address = reader.GetString(reader.GetOrdinal("address"));
                        string countryId = reader.GetString(reader.GetOrdinal("countries_id"));
                    
                        transactions.Add(new Transaction(id, userId, hash, address, countryId));
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
            
            return transactions;
        }

        public List<Transaction> FindOnePart(int limit)
        {
            List<Transaction> transactions = new List<Transaction>();
            
            try
            {
                _connection.Open();
                
                string sql = "select * from transactions limit @limit, 2";
            
                MySqlCommand command = new MySqlCommand(sql, _connection);
                command.Parameters.Add(new MySqlParameter("@limit", MySqlDbType.Int32)).Value = limit;
                
                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string id = reader.GetString(reader.GetOrdinal("id"));
                        string userId = reader.GetString(reader.GetOrdinal("users_id"));
                        string hash = reader.GetString(reader.GetOrdinal("hash"));
                        string address = reader.GetString(reader.GetOrdinal("address"));
                        string countryId = reader.GetString(reader.GetOrdinal("countries_id"));
                    
                        transactions.Add(new Transaction(id, userId, hash, address, countryId));
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
            
            return transactions;
        }

        public Transaction FindById(string id)
        {
            Transaction transaction = new Transaction();

            try
            {
                _connection.Open();
                
                string sql = "select * from transactions where id=@id";

                MySqlCommand command = new MySqlCommand(sql, _connection);
                command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.VarChar)).Value = id;

                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        string userId = reader.GetString(reader.GetOrdinal("users_id"));
                        string hash = reader.GetString(reader.GetOrdinal("hash"));
                        string address = reader.GetString(reader.GetOrdinal("address"));
                        string countryId = reader.GetString(reader.GetOrdinal("countries_id"));

                        transaction = new Transaction(id, userId, hash, address, countryId);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            finally
            {
                _connection.Close();
            }

            return transaction;
        }

        public void Create(Transaction t)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Transaction t)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Transaction t)
        {
            throw new System.NotImplementedException();
        }
    }
}