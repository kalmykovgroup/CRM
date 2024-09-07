using System.Collections.ObjectModel;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using KTSF.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KTSF.Components.CommonComponents.PaginateComponent;

public partial class PaginateComponent : Component
{
    public ObservableCollection<PageElement> ListPage { get; set; }

    public PaginateComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl)
    {
        ListPage = new ObservableCollection<PageElement>();
        ListPage.Add(new PageElement("page", 1));
        ListPage.Add(new PageElement("page", 2));
        ListPage.Add(new PageElement("page", 3));
        ListPage.Add(new PageElement("page", 4));
        ListPage.Add(new PageElement("page", 5));
        ListPage.Add(new PageElement("page", 6));
        ListPage.Add(new PageElement("page", 7));
        ListPage.Add(new PageElement("page", 8));
        ListPage.Add(new PageElement("page", 9));
        ListPage.Add(new PageElement("page", 10));
        ListPage.Add(new PageElement("page", 11));
        ListPage.Add(new PageElement("page", 12));
        ListPage.Add(new PageElement("page", 13));
        ListPage.Add(new PageElement("page", 14));
        ListPage.Add(new PageElement("page", 15));
    }
    
    public override UserControl Initial() => new PaginateUC(this);
}

public partial class PageElement : ObservableObject
{
    [ObservableProperty] private string name;
    public int PageIndex { get; set; } = 0;

    public PageElement(string text, int index)
    {
        Name = text;
        PageIndex = index;
    }

    public PageElement()
    {
        Name = "page";
        PageIndex = 1;
    }
}