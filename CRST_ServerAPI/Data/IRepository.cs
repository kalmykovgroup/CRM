using KTSFClassLibrary;

namespace CRST_ServerAPI.Data
{
    public interface IRepository
    {
        void Create<T>(T value);

        void Delete<T>(int id);

        T? Find<T>(int id);

        List<T> GetAll<T>();

        void Update<T>(T value);

        public string TableName {  get; } 
    }
}
