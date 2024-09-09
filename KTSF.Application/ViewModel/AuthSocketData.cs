using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Infrastructure
{
    public class AuthSocketData
    {
        public string IdentityString {  get; } 
        public int UserId {  get; }
        public int CompanyId {  get; }
        public int ObjectId {  get; }
        public WebSocket WebSocket {  get; }
        public DateTime CreatedAt {  get; } = DateTime.Now;

        public AuthSocketData(int userId, int companyId, int objectId, WebSocket webSocket)
        {
            IdentityString = Guid.NewGuid().ToString();
            UserId = userId;
            CompanyId = companyId;
            ObjectId = objectId;
            WebSocket = webSocket;
        }
    }
}
