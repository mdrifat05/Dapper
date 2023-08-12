using Dapper;
using LearnDapper.Database;
using static Dapper.SqlMapper;

namespace LearnDapper.DataAccessLayer
{
    public class D_Data_Batch : IDataBatch
    {
        private readonly DapperDBContext _db;

        public D_Data_Batch(DapperDBContext db)
        {
            _db = db;
        }
        public IEnumerable<T> GetAll<T>()
        {
            string query = $"SELECT * FROM Employee";
            using (var connection = _db.CreateConnection())
            {
                IEnumerable<T> entities = connection.Query<T>(query);
                return entities;
            }
        }
        public async Task InsertAsync<T>(T entity)
        {
            string query = "Insert into Employee(name,email,phone) values (@name,@email,@phone)";
            using (var connection = _db.CreateConnection())
            {
                await connection.ExecuteAsync(query, entity);
            }
        }
        public T GetById<T>(int id)
        {
            string query = "Select * From Employee where ID=@Id";
            using (var connection = _db.CreateConnection())
            {
                return connection.QueryFirstOrDefault<T>(query, new { Id = id });
            }
        }
        public async Task Update<T>(T entity)
        {
            //string tableName = GetTableName<T>();
            string query = "update Employee set name=@name,email=@email,phone=@phone where ID=@Id";
            using (var connection = _db.CreateConnection())
            {
                await connection.ExecuteAsync(query, entity);
            }
        }

        public async Task Delete<T>(int id)
        {
            string deleteQuery = $"DELETE FROM Employee WHERE Id = @Id";
            using (var connection = _db.CreateConnection())
            {
                await connection.ExecuteAsync(deleteQuery,new { Id = id }); 
            }
        }

       /* private string GetTableName<T>()
        {
            var type = typeof(T);
            return type.Name + "s"; // Assuming plural table names convention
        }*/
    }
}
