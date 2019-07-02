using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AdminDemo.Domains.Entities;
using AdminDemo.Usecases.DatabaseConfiguration;
using AdminDemo.Usecases.Interactors;
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

        public List<Transaction> FindOnePart(int limit, int amount)
        {
            List<Transaction> transactions = new List<Transaction>();
            
            try
            {
                _connection.Open();
                
                string sql = "select * from transactions limit @limit, @amount";
            
                MySqlCommand command = new MySqlCommand(sql, _connection);
                command.Parameters.Add(new MySqlParameter("@limit", MySqlDbType.Int32)).Value = limit;
                command.Parameters.Add(new MySqlParameter("@amount", MySqlDbType.Int32)).Value = amount;
                
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

        public int Count()
        {
            int count = 2;
            
            try
            {
                _connection.Open();
                
                MySqlCommand cmd = new MySqlCommand("select count(*) from transactions", _connection);
                  
                cmd.CommandType = CommandType.Text;
 
                // The ExecuteScalar method returns the value of the first column on the first row.
                object countObj =  cmd.ExecuteScalar();
                
                if (countObj != null)
                {
                    count = Convert.ToInt32(countObj);
                }
                
                Console.WriteLine("Emp Count: " + count);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            finally
            {
                _connection.Close();
            }

            return count;
        }
    }
}