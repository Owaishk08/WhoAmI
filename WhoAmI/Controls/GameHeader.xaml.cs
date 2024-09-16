using WhoAmI.Pages;

namespace WhoAmI.Controls;

public partial class GameHeader : ContentPage
{
	public GameHeader()
	{
		InitializeComponent();
	}

    private async void HomeIcon_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HomePage());
    }

    private async void HeartIcon_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ShopingPage());
    }
}