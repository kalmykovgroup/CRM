using CommunityToolkit.Mvvm.ComponentModel;

namespace KTSFClassLibrary
{
    public partial class User : ObservableObject
    { 
        public int Id { get; set; }

        [ObservableProperty] public string email = String.Empty;
        [ObservableProperty] public string phone = String.Empty;

        public string login = String.Empty;

        public string Password { get; set; } = String.Empty;

        public string AccessToken { get; set; } = String.Empty;

        public string Name {  get; set; }
        public string Surname {  get; set; }
        public string Patronimyc {  get; set; }

    }
}
