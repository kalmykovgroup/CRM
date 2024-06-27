using CommunityToolkit.Mvvm.ComponentModel;

namespace KTSFClassLibrary
{
    public partial class User : ObservableObject
    {
        public int Id { get; set; }

        [ObservableProperty] private string email = String.Empty;

        public string Password { get; set; } = String.Empty;

        public string AccessToken { get; set; } = String.Empty;
    }
}
