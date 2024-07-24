using KTSFClassLibrary;

namespace CRST_ServerAPI.Data
{
    public interface IRepository
    {
        public Type ClassType { get; }

        T? Find<T>(int id);

        List<T> GetAll<T>();

        void Create<T>(T value);
         
        void Update<T>(T value);

       
    }
}
