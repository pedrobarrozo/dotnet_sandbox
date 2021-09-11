using System.Collections.Generic;
using System;
using TestApi.Models;
using MySqlConnector;
using Dapper;


namespace TestApi.Repositories
{
    public class ChoreRepository : IChoreRepository
    {
        private readonly string _connectionString;
        public ChoreRepository(string connectionString)
        {
            _connectionString = connectionString;   // Injetando a string de conexão no construtor da classe
        }
        public IEnumerable<ChoreItem> GetAll()
        {
            using(MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<ChoreItem>("SELECT * FROM Chores ORDER BY name ASC");
            }
        }
        public IEnumerable<ChoreItem> Get(int id)
        {
            using(MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                String s = String.Format("SELECT * FROM Chores WHERE id = {0}", id);
                return connection.Query<ChoreItem>(s);
            }
        }
    }
}