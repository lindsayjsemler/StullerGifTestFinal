using System;
using StullerGifTest.Models;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.Clipboard;

namespace StullerGifTest.ViewModels
{
    public class DetailGifViewModel : ViewModelBase
    {
        GIFModel gifModel;

        public DetailGifViewModel(GIFModel _gifModel)
        {
            gifModel = _gifModel;
        }

        private ICommand _copyLink;
        public ICommand CopyLink
        {
            get
            {
                return _copyLink ?? (_copyLink = new Command<string>((urlLink) =>
                {

                    //Xamarin Forms has a cross clipboard library that will allow the text to be copied and
                    //pasted outside the mobile app
                    CrossClipboard.Current.SetText(gifModel.URLLink);
                }));
            }
        }

        private ICommand _popModelCommand;
        public ICommand PopModelCommand
        {
            get
            {
                return _popModelCommand ?? (_popModelCommand = new Command<string>(async (text) =>
                {
                    //Pop this modal and return to the previous screen
                    await App.Current.MainPage.Navigation.PopModalAsync();

                }));
            }
        }

    }
}

