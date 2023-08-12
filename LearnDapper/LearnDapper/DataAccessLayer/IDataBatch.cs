namespace LearnDapper.DataAccessLayer
{
    public interface IDataBatch
    {
        public IEnumerable<T> GetAll<T>();
        public Task InsertAsync<T>(T entity);
        public T GetById<T>(int id);
        public Task Update<T>(T entity);
        public Task Delete<T>(int id);
    }
}
