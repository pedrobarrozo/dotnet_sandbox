using System.Collections.Generic;
using System;
using TestApi.Models;
using MySqlConnector;
using Dapper;
using System.Text.Json;


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
        public ChoreItem Create(ChoreItem chore)
        {
            using(MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                String s = String.Format("INSERT INTO Chores(`name`, `description`) VALUES ('{0}', '{1}')", chore.Name, chore.Description);
                connection.Query(s);
                return chore;
            }
        }

        public IEnumerable<ChoreItem> Update(int id, ChoreItem chore)
        {
            using(MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                if (chore.Name != null) {
                    String s = String.Format("UPDATE Chores SET name = '{0}' WHERE id = {1}", chore.Name, id);
                    connection.Query(s);
                }
                if (chore.Description != null) {
                    String s = String.Format("UPDATE Chores SET description = '{0}' WHERE id = {1}", chore.Description, id);
                    connection.Query(s);
                }
                if (chore.IsComplete != null) {
                    Console.WriteLine("ok");
                    if (chore.IsComplete) {
                        String s = String.Format("UPDATE Chores SET iscomplete = true WHERE id = {0}", id);
                        connection.Query(s);
                    } else {
                        String s = String.Format("UPDATE Chores SET iscomplete = false WHERE id = {0}", id);
                        connection.Query(s);
                    }
                }
                String r = String.Format("SELECT * FROM Chores WHERE id = {0}", id);
                return connection.Query<ChoreItem>(r);
            }
        }
    }
}