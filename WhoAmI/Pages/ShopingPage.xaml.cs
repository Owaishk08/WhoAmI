using System.ComponentModel;
using WhoAmI.Pages;
using WhoAmI.Controls;

namespace WhoAmI.Pages;

public partial class ShopingPage : ContentPage,INotifyPropertyChanged
{
    /*static int coins = 0;
    static int hearts = 5;
    private string heartshow = hearts.ToString();
    private string coinshow = coins.ToString();

    public string Heartshow
    {
        get => heartshow; set
        {
            heartshow = value;
            OnPropertyChanged();
        }
    }

    public string Coinshow
    {
        get => coinshow; set
        {
            coinshow = value;
            OnPropertyChanged();
        }
    }*/
    public ShopingPage()
	{
		InitializeComponent();
        BindingContext =new MainPage();
	}

    private async void HomeIcon_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new HomePage());
    }

    private async void HeartIcon_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ShopingPage());
    }

    private void Get5Hearts(object sender, EventArgs e)
    {
        var checkcoin = int.Parse(coinlbl.Text);
        var checkheart = int.Parse(heartlbl.Text);
        if (checkcoin >= 15 )
        {
             int coins = checkcoin - 15;
             int hearts = checkheart + 5;
        }
        else
        {
            DisplayAlert("Insufficient Coins", "You want more coins to Buy it.", "OK");
        }
    }

    private void Get3Hearts(object sender, EventArgs e)
    {
        var checkcoin = int.Parse(coinlbl.Text);
        var checkheart = int.Parse(heartlbl.Text);
        if (checkcoin >= 10)
        {
            int coins = checkcoin - 10;
            int hearts = checkheart + 3;
        }
        else
        {
            DisplayAlert("Insufficient Coins", "You want more coins to Buy it.", "OK");
        }
    }

    private void Get1Hearts(object sender, EventArgs e)
    {
        var checkcoin = int.Parse(coinlbl.Text);
        var checkheart = int.Parse(heartlbl.Text);
        if (checkcoin >= 5)
        {
           int coins = checkcoin - 5;
           int hearts = checkheart + 1;
        }
        else
        {
            DisplayAlert("Insufficient Coins", "You want more coins to Buy it.", "OK");
        }
    }
}