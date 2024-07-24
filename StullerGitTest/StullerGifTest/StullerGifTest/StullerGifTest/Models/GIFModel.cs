using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace StullerGifTest.Models
{
	public struct GIFModel
    {
        public string SearchName { get; set; }
        public ImageSource GifImageSource { get; set; }
        public string URLLink { get; set; }
    }
}

