using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary
{
    public partial class MainUser: ObservableObject
    {
        public int Id { get; set; }

        [ObservableProperty] public string email = String.Empty;
        [ObservableProperty] public string phone = String.Empty;

        public string Username { get; set; } = String.Empty;

        public string Password { get; set; } = String.Empty;

        public string AccessToken { get; set; } = String.Empty;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronimyc { get; set; }


        public override bool Equals(object? obj)
        {
            return obj is not null && obj is User user && user.Id == Id;
        }
    }
}
