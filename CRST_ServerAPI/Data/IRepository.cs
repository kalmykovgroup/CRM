using KTSFClassLibrary;

namespace CRST_ServerAPI.Data
{
    public interface IRepository
    {
        public Type ClassType { get; }

        T? Find<T>(int id);

        List<T> GetAll<T>();

        T Create<T>(T value);
         
        T Update<T>(T value);

       
    }
}
