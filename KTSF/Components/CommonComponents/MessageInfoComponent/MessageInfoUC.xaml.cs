using System.Windows.Controls;

namespace KTSF.Components.CommonComponents.MessageInfoComponent;

public partial class MessageInfoUC : UserControl
{
    public MessageInfoComponent MessageInfoComponent { get; }
    public MessageInfoUC(MessageInfoComponent messageInfoComponent)
    {
        InitializeComponent();
        MessageInfoComponent = messageInfoComponent;
        DataContext = MessageInfoComponent;
    }
}