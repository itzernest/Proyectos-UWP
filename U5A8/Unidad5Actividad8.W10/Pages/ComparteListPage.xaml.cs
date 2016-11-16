//---------------------------------------------------------------------------
//
// <copyright file="ComparteListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/16/2016 7:07:14 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.Menu;
using Unidad5Actividad8.Sections;
using Unidad5Actividad8.ViewModels;
using AppStudio.Uwp;

namespace Unidad5Actividad8.Pages
{
    public sealed partial class ComparteListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }
        public ComparteListPage()
        {
			ViewModel = ViewModelFactory.NewList(new ComparteSection());

            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
			NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
			ShellPage.Current.ShellControl.SelectItem("7e9dd9de-28fa-4279-9e59-695b95d9261b");
			ShellPage.Current.ShellControl.SetCommandBar(commandBar);
			if (e.NavigationMode == NavigationMode.New)
            {			
				await this.ViewModel.LoadDataAsync();
                this.ScrollToTop();
			}			
            base.OnNavigatedTo(e);
        }

    }
}
