//---------------------------------------------------------------------------
//
// <copyright file="AboutPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/16/2016 7:07:14 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Unidad5Actividad8.ViewModels;

namespace Unidad5Actividad8.Pages
{
    public sealed partial class AboutPage : Page
    {
        public AboutPage()
        {
            AboutThisAppModel = new AboutThisAppViewModel();

            this.InitializeComponent();
        }

        public AboutThisAppViewModel AboutThisAppModel { get; private set; }
		
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ShellPage.Current.ShellControl.SelectItem("About");
            base.OnNavigatedTo(e);
        }
    }
}
