using System;
using StullerGifTest.Models;
using StullerGifTest.ViewModels;
using Xamarin.Forms;

namespace StullerGifTest.Views
{
    public partial class DetailGifModal : ContentPage
    {
        protected GIFModel gifModel { get; set; } 

        public DetailGifModal(GIFModel _gifModel)
        {
            InitializeComponent();
            gifModel = _gifModel;

            //Set the binding context when navigated to and make sure to give the string to the viewmodel
            BindingContext = new DetailGifViewModel(gifModel);

        }

        /*
         * This code would Animate if the Xamarin.Forms update, I left this in here on purpose
         */
        /*protected override void OnAppearing()
        {
            base.OnAppearing();

            //On Appearing Start the Animation (this would work on Maui or latest version of Xamarin.Forms,
            //known bug in this version
            GifImage.IsAnimationPlaying = true;
        }

        protected override void OnDisappearing()
        {
            //stop this animation when the view is closing (this would work on Maui or latest version of Xamarin.Forms,
            //known bug in this version
            if (GifImage.IsAnimationPlaying)
            {
                GifImage.CancelAnimations();
            }
            base.OnDisappearing();
        }*/
    }
}

