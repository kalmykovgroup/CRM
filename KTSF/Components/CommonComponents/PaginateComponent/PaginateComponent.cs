using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CSharpFunctionalExtensions;
using KTSF.Core.Object.Product_;
using KTSF.Core.Object.Receipt_;
using KTSF.Dto.Product_;
using KTSF.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KTSF.Components.CommonComponents.PaginateComponent;

public partial class PaginateComponent : Component
{
    private IPaganatable TypeClass { get; }
    public ObservableCollection<int> ListPage { get; set; }
    
    [ObservableProperty] private int currentPage;
    [ObservableProperty] private bool isPopupOpen;
    [ObservableProperty] private int allCountItems;
    [ObservableProperty] private int currentCountItems;
    private int countItemsForPage = 20;
    public event Action<List<object>> GetCurrentPage;
    public PaginateComponent(UserControlVM binding, AppControl appControl, IPaganatable typeClass) : base(binding, appControl)
    {
        TypeClass = typeClass;
        ListPage = new ObservableCollection<int>();
    }

    public async Task<List<object>> TakeFirstPage()
    {
        Result<FirstPage<object>, (string? Message, HttpStatusCode)> result = await AppControl.Server.GetFirstPage(TypeClass);
    
        if (result.IsFailure)
        {
            MessageBox.Show(result.Error.Message);
            return null;
        }
        
        ListPage.Clear();
        
        for (int i = 0; i < result.Value.PageCount; i++)
        {
            ListPage.Add(i + 1);
        }
    
        List<object> returnElements = new List<object>();
        
        foreach (object item in result.Value.Items)
        {
            returnElements.Add(item);
        }

        CurrentPage = 1;
        AllCountItems = result.Value.CountAllItems;

        countItemsForPage = result.Value.CountItemsForPage;

        if (AllCountItems <= countItemsForPage)
        {
            CurrentCountItems = AllCountItems;
        }
        else
        {
            CurrentCountItems = countItemsForPage;
        }
        
        return returnElements;
    }

    [RelayCommand]
    private void TogglePopup(object parameter)
    {
        IsPopupOpen = (bool)parameter;
    }

    [RelayCommand]
    private async Task SelectedCurrentPageReceipt(object parameter)
    {
        CurrentPage = (int)parameter;
        
        int i = await TakeCurrentPageElements();

        if (CurrentPage == ListPage.Count)
        {
            CurrentCountItems = (countItemsForPage * (ListPage.Count - 1)) + i;
        }
        else
        {
            CurrentCountItems = countItemsForPage * CurrentPage;
        }
    }

    [RelayCommand]
    private async Task SelectedNextPageReceipt()
    {
        if (ListPage.Count < CurrentPage + 1)
        {
            return;
        }
        CurrentPage++;
        int i = await TakeCurrentPageElements();

        if (CurrentPage == ListPage.Count)
        {
            CurrentCountItems = (countItemsForPage * (ListPage.Count - 1)) + i;
        }
        else
        {
            CurrentCountItems = countItemsForPage * CurrentPage;
        }
    }

    [RelayCommand]
    private async Task SelectedPreviousPageReceipt()
    {
        if (1 > CurrentPage - 1)
        {
            return;
        }
        
        CurrentPage--;
        int i = await TakeCurrentPageElements();

        if (CurrentPage == ListPage.Count)
        {
            CurrentCountItems = (countItemsForPage * (ListPage.Count - 1)) + i;
        }
        else
        {
            CurrentCountItems = countItemsForPage * CurrentPage;
        }
    }
    
    private async Task<int> TakeCurrentPageElements()
    {
        Result<List<object>, (string? Message, HttpStatusCode)> result = await AppControl.Server.GetElements(TypeClass, CurrentPage);
        
        if (result.IsFailure)
        {
            MessageBox.Show(result.Error.Message);
            return 0;
        }
    
        List<object> returnElements = new List<object>();
        
        foreach (object item in result.Value)
        {
            returnElements.Add(item);
        }
        
        GetCurrentPage?.Invoke(returnElements);
        return returnElements.Count;
    }
    
    public override UserControl Initial() => new PaginateUC(this);
}