using System.Windows.Controls;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using KTSF.ViewModel;

namespace KTSF.Components.CommonComponents.MessageInfoComponent;

public partial class MessageInfoComponent : Component
{

    [ObservableProperty] private string messageTitle;
    [ObservableProperty] private string messageContext;
    [ObservableProperty] private bool isOpenPopup = false;
    
    private DispatcherTimer timer;

    public MessageInfoComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl)
    {
        timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
        timer.Tick += (s, e) => MessageClose();
    }
    
    public override UserControl Initial() => new MessageInfoUC(this);

    public void MessageShow(string title, string context)
    {
        MessageTitle = title;
        MessageContext = context;
        IsOpenPopup = true;
        timer.Start();
    }
    
    private void MessageClose()
    {
        MessageTitle = "";
        MessageContext = "";
        IsOpenPopup = false;
        timer.Stop();
    }
}