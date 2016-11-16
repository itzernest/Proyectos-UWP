//---------------------------------------------------------------------------
//
// <copyright file="MisFotosEnFlickrListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/16/2016 7:07:14 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using AppStudio.DataProviders.Flickr;
using Unidad5Actividad8.Sections;
using Unidad5Actividad8.ViewModels;
using AppStudio.Uwp;

namespace Unidad5Actividad8.Pages
{
    public sealed partial class MisFotosEnFlickrListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }
        public MisFotosEnFlickrListPage()
        {
			ViewModel = ViewModelFactory.NewList(new MisFotosEnFlickrSection());

            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
			NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
			ShellPage.Current.ShellControl.SelectItem("a6c3ef13-d41c-4fbc-899c-dccf4ec2a3bd");
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
