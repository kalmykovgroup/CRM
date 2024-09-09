using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

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