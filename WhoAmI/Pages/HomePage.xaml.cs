using Microsoft.Maui.ApplicationModel.DataTransfer;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace WhoAmI.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        BindingContext = new MainPage();
	}
    private async void HomeIcon_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HomePage());
    }
    private async void CoinIcon_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ShopingPage());
    }
    private async void HeartIcon_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ShopingPage());
    }
    private async void PlayButton_Clicked(object sender, EventArgs e)
    {
        var checkhearts = int.Parse(heartlbl.Text);
        if (checkhearts > 0)
        {
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            bool answer = await DisplayAlert("Sorry!!", "You have 0 Lives", "Buy", "Cancel");
            if (answer)
            {
                await Navigation.PushAsync(new ShopingPage());
            }
        } 
    }

    private async void ShareButton_Clicked(object sender, EventArgs e)
    {
        await Share.Default.RequestAsync(new ShareTextRequest               // for sharing text
        {
            Text = "Currenty in Developement",
            Title = "Share Text"
        });
    /*private async void ShareButton_Clicked(string uri, IShare share)              // for sharing uri
        /*{
            await share.RequestAsync(new ShareTextRequest
            {
                Uri = uri,
                Title = "Share Web Link"
            });
        }*/
    }

    private void SettingButton_Clicked(object sender, EventArgs e)
    {

    }

    private void StarButton_Clicked(object sender, EventArgs e)
    {

    }

    
}