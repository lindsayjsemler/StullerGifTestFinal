using System;
using System.Collections.Generic;
using System.ComponentModel;
using StullerGifTest.Models;
using StullerGifTest.ViewModels;
using Xamarin.Forms;
using static System.Net.WebRequestMethods;

namespace StullerGifTest
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();

        }

    }
}

