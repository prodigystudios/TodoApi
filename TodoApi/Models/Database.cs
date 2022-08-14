using System.Data.SqlClient;

namespace TodoApi.Models
{
    public class Database
    {
        public List<Todo> GetTodosFromDatabase()
        {
            List<Todo> todolist = new List<Todo>();
            var cmd = GetSqlCommand();
            cmd.CommandText = "SELECT * FROM Todo_Table";
            var reader = cmd.ExecuteReader();
            
            while(reader.Read())
            {
                var todo = new Todo()
                {
                    id = int.Parse(reader["id"].ToString()),
                    title = reader["Title"].ToString()
                };
                todolist.Add(todo);
            }
            return todolist;
        }
        public Todo GetTodoById(int id)
        {
            var cmd = GetSqlCommand();
            cmd.CommandText = "SELECT * FROM Todo_Table WHERE id =@id";
            cmd.Parameters.AddWithValue("id", id);
            var reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                var todo = new Todo()
                {
                    id = int.Parse(reader["id"].ToString()),
                    title = reader["Title"].ToString()
                };
                return todo;
            }
            return null;
        }

        public void CreateNewTodo(Todo todo)
        {
            var cmd = GetSqlCommand();
            cmd.CommandText = "INSERT INTO Todo_Table (Title) VALUES (@title)";
            cmd.Parameters.AddWithValue("Title", todo.title);

            cmd.ExecuteNonQuery();
        }
        public void DeleteTodo(int id)
        {
            var cmd = GetSqlCommand();
            cmd.CommandText = "DELETE FROM Todo_Table WHERE id = @id";
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }
        public SqlCommand GetSqlCommand()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=TodoDB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;

            return cmd;
        }
    }
}
