# StullerGifTest

* *Disclaimer* *
This is and Android only app (decided to do this to save time, especially since iOS required a version of xCode that would not work on my computer. I left in the Animation code currently commented out and notated.) Ideally if I had the time I did not have enough time to add in the Apple SqlServer Database that I had hoped. Here is a link to a thread that is one of many demonstrating the issue with this version fo Xamarin.Forms, gifs, and Animation: https://stackoverflow.com/questions/61102724/xamarin-forms-image-gif-animation-doesnt-play-on-android
* *End Disclaimer* *

INSTRUCTIONS FOR SETTING UP YOUR COMPUTER TO RUN THE APP:
Details on Version for my personal Computer MAC iOS, .NetStandardLibrary, Xamarin.Forms, nuget packages, xCode, AndroidStudio, and Android Emulator, warning this may not compile if you are on a newer versin of an iOS or .Net that is more up to date aka a development laptop and has only been developed on a MAC (For mobile development and Maui development you need a MAC to release/update anything to the Apple Store)
    
    1.) I am running this app on a Mac OS Big Sur version 11.6 which allows me to only use Xamarin. I am stuck with .NET 2 and Maui requires a minimum of .NET 6.
    2.) .NewStandardLibrary v2.0.3
    3.) Xamarin.Forms v5.00.2196
    4.) The following nuget packages: Xamarin.Essentials v1.7.0, Xamarin.Plugins.Clipboard v 2.0.0, Xamarin.FFImageLoading, Xamarin.FFImageLoading.Forms, and XamarinImageLoading.Transformations v 2.4.11.982
    5.) Xcode v 13.1 (13A1030d)
    6.) Android Studio Flamingo v 2022.2.1 Patch 2
    7.) In order to add an Adroid Emulator to test, in Visual Studio you will need to go to Tools -> SDK Locations -> Android and insteall Android 12.0 S which is API 31 and the version I used to test the entire App
  8.) DOWNLOAD THE CODE FROM GITHUB LOCATED HERE: https://github.com/lindsayjsemler/StullerGifTest.git


OVERALL DESIGN OF THE APP AND MAJOR DESIGN DECISIONS:

    1.) Xamarin/Maui follows a strict MVVM architetural pattern so I devided my modules up for my MainPage and DetailGifPage by separating out the Model, View, and View Models.
    2.)For the GifModel, I used this throughout the entire app and it had all the information needed for my Gif files including the SearchName, URL, GifImageSource, and PngImageSource. These were key for both the search functionality as well asl displaying the gif files on the screen
    3.) All of the View Model are the updating of User interactions on the views that may udpate information on the models, and also changes tothe models that may update the views
    4.) View are the files that deal directly with the xaml files with is the layout of the screen and deals with the binding of important data between the xaml, view, and viewmodel.
    5.) The model is primarily the information that is retrieved or updated from the server and stored in the database, tehse values change depending on the UI interaction on the front end of the App.

DIVISION OF SCREENS WHILE MAINTAINING THE MVVM PATTERN:

    1.) The MainPage, is the screen with the title, search bar, and images of gifs. Each of the gifs are click able and will lead to a DetailGiveView where there is an exit button, the animation (currently not working, but still working on this), and the Copy Link button which copies the link of the gif and you can paste it system wide to any other app such as notes, messages, word docs, etc. 
    
    This I decided to have a CollectionView for the stil images of the gifs that I got from giphy I  started with 5 hard-coded gifs, and it will allow a max of 10 gis to be show at a time. The Search bar you can type (case insensitive) for the name of the gi (under the inage in the main view) or the URL of the gif itself, this will update the CollectionView with the results of the search
    
    If you click on an image of a gif, you are navigated to the DetailGiFView page
    
    2.) The DetailGiFView is a modal (a screen that is a pop up on top of a main screen (one that fills the entire mobiel app). This has an X button to close, a currently missing animation of the gift, and a button to copy to the system the url link for the gif you can paste anywhere in the computer
    
    3.) The App classes are there as a default enterance to the app for both Android and iOS.
    
    4.) THe other portion to take note of is any images, gifs, or mp4's are locted in the Resources director of Android, iOS would have a similar layout becaus ethey are dependent on the type of mobile device. 
    5.) I have a ViewModelBase class that both MainPageViewModel and DetailGifViewModel Derive from and this implements the IPropertyChanged values for any changes that the user makes that need to be updated between the view/xaml and model, this si deprecated in Maui is set up so this class will not be needed in the future.

Thank you!
Lindsay Semler



Note I did try several other options to get gifs working in the app, however all are messy design an bandaid fixes for the Xamarin.Forms know issue as documented here: https://stackoverflow.com/questions/61102724/xamarin-forms-image-gif-animation-doesnt-play-on-android

Options I tried were CrossMediaManager, using Webview with the URL to Animate in screen, FFTImageLoading, and approx. 5 other trials to fix this issue. I also tried to switch to an iOS implementation, however my xCode version is several years out of date and imcompatible with iOS development on my machine.


