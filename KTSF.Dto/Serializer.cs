using KTSF.Core.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KTSF.Dto
{
    public static class Serializer
    {

       /* public static T? Deserialize<T>(byte[] data) where T : class
        {
            using (var stream = new MemoryStream(data))

            using (var reader = new StreamReader(stream, Encoding.UTF8))

            return JsonSerializer.Deserialize(reader.BaseStream, typeof(T)) as T;
        }

        public static T? Serialize<T>() where T : class
        {
            User user = new User();
             
            string json = JsonSerializer.Serialize(user); 

             

            return JsonSerializer.Deserialize(reader.BaseStream, typeof(T)) as T;
        }*/
    }
}
