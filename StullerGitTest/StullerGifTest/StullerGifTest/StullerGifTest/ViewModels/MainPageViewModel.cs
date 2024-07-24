using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using FFImageLoading;
using StullerGifTest.Models;
using StullerGifTest.Views;
using Xamarin.Forms;

namespace StullerGifTest.ViewModels
{
	public class MainPageViewModel : ViewModelBase
    {
        //I'm going to cut off the amount of gifs to show at once initially to 10 until there is
        // a more detailed design description for how many gifs we initially want to show
        // ideally there would be a maz amount shown from the database, perhaps as you scroll
        // down it can load more from the database as the main view is of type ScrollView
        private  int MAX_GIFS_TO_SHOW = 10;

        //this is s aset list of GifModels, to be replaced eventually with database if there is time
        public List<GIFModel> gifs;

        //observable collection as results from the search bar, make sure that this uses IPropertyChanged so it
        //is updated in the viewmodel and the view whenever SearchCollection is set
        private ObservableCollection<GIFModel> _sarchCollection;
        public ObservableCollection<GIFModel> SearchCollection
        {
            get => _sarchCollection;
            set => SetProperty(ref _sarchCollection, value);
        }

        public MainPageViewModel() 
		{
            //navigation = App.Current.MainPage.Navigation;
            gifs = new List<GIFModel>();

            CreateListOfGifModels();

            //Default the list to the first three in the gifs list
            ShowInitialGifs();
        }

        //Originally this was set to just the first three gifs, I changed this to show all the gifs
        //this is since there is only five they they are currently hard coded since there is no database hookup
        private void ShowInitialGifs()
        {
            SearchCollection = new ObservableCollection<GIFModel>();

            //If there are less gifs in this then the max, lets change the max to the total number of gis we have
            if (MAX_GIFS_TO_SHOW > gifs.Count)
                MAX_GIFS_TO_SHOW = gifs.Count;

            //Default the list to the MAX_GIFS_TO_SHOW in the gifs list, eventually this will be a database
            for (int i = 0; i < MAX_GIFS_TO_SHOW; i++)
            {
                SearchCollection.Add(gifs[i]);
            }
        }

        //search command that looks for eityer URL or name of the gif and shows results,
        // if text is null it shows and error and then displays the original first three gifs
        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new Command<string>(async (text) =>
                {
                    ObservableCollection<GIFModel> gifsFound = new ObservableCollection<GIFModel>();
                    SearchCollection = new ObservableCollection<GIFModel>();
                    foreach (GIFModel gif in gifs)
                    {
                        if(gif.SearchName.Contains(text, StringComparison.OrdinalIgnoreCase))
                        {
                            gifsFound.Add(gif);
                            SearchCollection = gifsFound;
                        }
                        else if (string.Equals(gif.URLLink, text))
                        {
                            gifsFound.Add(gif);
                            SearchCollection = gifsFound;
                        }
                        if (string.IsNullOrEmpty(text))
                        {
                            await App.Current.MainPage.DisplayAlert("GIF Animation App", "Error: Could not find gif by name or URL " + text + ". Will Show all gifs available", "Ok");
                            ShowInitialGifs();
                        }
                    }

                }));
            }
        }

        //When you tap on the image it will navigate to a detailed page where you can watch the animation
        // this is also where you can copy the url link so you can paste it anywhere in the system
        private ICommand _imageTappedAsync;
        public ICommand ImageTappedAsync
        {
            get
            {
                return _imageTappedAsync ?? (_imageTappedAsync = new Command<GIFModel>(async (gifModel) =>
                {
                    GIFModel selectedGIFModel = (GIFModel)gifModel;
                    try
                    {
                        Page page = new NavigationPage(new DetailGifModal(selectedGIFModel));
                        await App.Current.MainPage.Navigation.PushModalAsync(page);
                    }
                    catch (Exception)
                    {
                        //There is n error with this image tap it the command parameter should be of type GIFModel
                        await App.Current.MainPage.DisplayAlert("GIF Animation App", "Error Creating Detail Gif Modal Page", "Ok");
                    }

                }));
            }
        }


        /*
         * THIS IS ONLY TEMPORARY UNTIL I HAVE TIME TO ADD IN A DATABASE, STARTED WITH ONLY 5 GIFS FROM GIPHY
         */

        //This is a list of hardcoded Gif models with search name, name of gif file, URL link, and is Playing variables
        //If there is time this will be placed in an Apple Friendly SQL Database (did not have time due to food poisoining)
        private void CreateListOfGifModels()
        {
            GIFModel model1 = new GIFModel
            {
                SearchName = "Hugs",
                URLLink = "https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExNXdhajJiaWg5czV0b3VwdnR6b29mYjkwZzhyejdhdzlobDhjd2dkZSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/0OgdJVNjbcIifqSb7U/giphy.gif",
                GifImageSource = ImageSource.FromFile("Hugs.gif")
            };
            gifs.Add(model1);


            GIFModel model2 = new GIFModel
            {
                SearchName = "Squirrel",
                URLLink = "https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExNXdhajJiaWg5czV0b3VwdnR6b29mYjkwZzhyejdhdzlobDhjd2dkZSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/0OgdJVNjbcIifqSb7U/giphy.gif",
                GifImageSource = ImageSource.FromFile("Squirrel.gif")
            };
            gifs.Add(model2);


            GIFModel model3 = new GIFModel
            {
                SearchName = "Its Saturday",
                URLLink = "https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExNjllN3FieTM2bXhkNnR0amN6OGVkeG1wZG1mOGlhNWlibDBnYW0zbyZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/mWrXc8R1CJQxq/giphy.gif",
                GifImageSource = ImageSource.FromFile("ItsSaturday.gif")
            };
            gifs.Add(model3);


            GIFModel model4 = new GIFModel
            {
                SearchName = "Happy Birthday",
                URLLink = "https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExNTQ3c2wxbXg1bW1obmtoejRzZWh0eTV3Z2Eza2JkYjhkcHZpOHZmeCZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/LzwcNOrbA3aYvXK6r7/giphy.gif",
                GifImageSource = ImageSource.FromFile("HappyBirthday.gif")
            };
            gifs.Add(model4);


            GIFModel model5 = new GIFModel
            {
                SearchName = "Le Tour De France",
                URLLink = "https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExNXdhajJiaWg5czV0b3VwdnR6b29mYjkwZzhyejdhdzlobDhjd2dkZSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/0OgdJVNjbcIifqSb7U/giphy.gif",
                GifImageSource = ImageSource.FromFile("LeTourDeFrance.gif")
            };
            gifs.Add(model5);
        }

    }

}

