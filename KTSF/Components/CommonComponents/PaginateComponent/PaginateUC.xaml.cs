using System.Windows.Controls;

namespace KTSF.Components.CommonComponents.PaginateComponent;

public partial class PaginateUC : UserControl
{
    public PaginateComponent PaginateComponent { get; }
    public PaginateUC(PaginateComponent paginateComponent)
    {
        InitializeComponent();
        PaginateComponent = paginateComponent;
        DataContext = PaginateComponent;
    }
}