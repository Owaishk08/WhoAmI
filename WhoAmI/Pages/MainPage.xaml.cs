using System.ComponentModel;

namespace WhoAmI.Pages
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        #region UI Properties
        public string Image_name
        {
            get => image_name; set
            {
                image_name = value;
                OnPropertyChanged();
            }
        }
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
        }

        public string GameLevel
        {
            get => gameLevel; set
            {
                gameLevel = value;
                OnPropertyChanged();
            }
        }
        public string Button_1
        {
            get => button_1; set
            {
                button_1 = value;
                OnPropertyChanged();
            }
        }
        public string Button_2
        {
            get => button_2; set
            {
                button_2 = value;
                OnPropertyChanged();
            }
        }
        public string Button_3
        {
            get => button_3; set
            {
                button_3 = value;
                OnPropertyChanged();
            }
        }
        public string Button_4
        {
            get => button_4; set
            {
                button_4 = value;
                OnPropertyChanged();
            }
        }
        
        #endregion

        #region Game Engine
        static int level = 1;
        string correct_ans = "Apple";
        string select_ans = "";
        static int coins = 0;
        static int hearts = 5;
        private string coinshow = coins.ToString();
        private string heartshow = hearts.ToString();
        private string image_name="level1.png";
        private string gameLevel = "Level 1";
        private string button_1="Mango";
        private string button_2="Apple";
        private string button_3="Banana";
        private string button_4="Orange";
        

        #endregion

        #region Levels
        private void level1()
        {
            button_1 = "Mango";
            button_2 = "Apple";
            button_3 = "Banana";
            button_4 = "Orange";
            correct_ans = "Apple";
            image_name = "level1.png";
        }
        private void level2()
        {
            button_1 = "Bat";
            button_2 = "Hat";
            button_3 = "Ball";
            button_4 = "Mango";
            correct_ans = "Ball";
            image_name = "level2.png";
        }

        #endregion
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            checkbtn.IsEnabled = false;
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
        private void btn1_Clicked(object sender, EventArgs e)
        {
            select_ans = btn1.Text;
            selctingbtn1();
            checkbtn.BackgroundColor = Colors.Green;
            checkbtn.IsEnabled = true;
        }
        private void selctingbtn1()
        {
            btn1.BorderWidth = 5;
            btn2.BorderWidth = 0;
            btn3.BorderWidth = 0;
            btn4.BorderWidth = 0;
        }
        private void btn2_Clicked(object sender, EventArgs e)
        {
            select_ans = btn2.Text;
            selctingbtn2();
            checkbtn.BackgroundColor = Colors.Green;
            checkbtn.IsEnabled = true;
        }
        private void selctingbtn2()
        {
            btn1.BorderWidth = 0;
            btn2.BorderWidth = 5;
            btn3.BorderWidth = 0;
            btn4.BorderWidth = 0;
        }
        private void btn3_Clicked(object sender, EventArgs e)
        {
            select_ans = btn3.Text;
            selctingbtn3();
            checkbtn.BackgroundColor = Colors.Green;
            checkbtn.IsEnabled = true;
        }
        private void selctingbtn3()
        {
            btn1.BorderWidth = 0;
            btn2.BorderWidth = 0;
            btn3.BorderWidth = 5;
            btn4.BorderWidth = 0;
        }
        private void btn4_Clicked(object sender, EventArgs e)
        {
            select_ans = btn4.Text;
            selctingbtn4();
            checkbtn.BackgroundColor = Colors.Green;
            checkbtn.IsEnabled = true;
        }
        private void selctingbtn4()
        {
            btn1.BorderWidth = 0;
            btn2.BorderWidth = 0;
            btn3.BorderWidth = 0;
            btn4.BorderWidth = 5;
        }
        private async void ContinueButton_Clicked(object sender, EventArgs e)
        {
            gameLevel = $"Level {level}";
            image_name = $"level{level}.png";
            btn1.Text = "Bat";
            btn2.Text = "Hat";
            btn3.Text = "Ball";
            btn4.Text = "Cat";
            correct_ans = "Ball";
            image_name = "level2.png";
            await Navigation.PushAsync(new MainPage());
            ChechHearts();
        }
        private void CorrectAns()
        {
            if (select_ans == correct_ans)
            {
                continuebtn.IsEnabled = true;
                BtnDisable();
                finalans();
                GetCoins();
                level++;
            }
        }

        private void WrongAns()
        {
            if (select_ans != correct_ans)
            {
                continuebtn.IsEnabled=true;
                BtnDisable();
                finalans();
                LostHeart();
                level++;
            }
        }
        private void finalans()
        {
            if (select_ans == btn1.Text)
            {
                btn1.BackgroundColor = Colors.Red;
                btn2.BackgroundColor = Colors.Green;
            }
            if (select_ans == btn2.Text)
            {
                btn2.BackgroundColor = Colors.Green;
            }
            if (select_ans == btn3.Text)
            {
                btn3.BackgroundColor = Colors.Red;
                btn2.BackgroundColor = Colors.Green;
            }
            if (select_ans == btn4.Text)
            {
                btn4.BackgroundColor = Colors.Red;
                btn2.BackgroundColor = Colors.Green;
            }
        }
        private int GetCoins()
        {
            coins = coins + 10;
            return coins;
        }
        private int LostHeart()
        {
            hearts--;
            return hearts;
        }
        private void Updatelevel()
        {
            gameLevel = $"Level {level}";
            image_name = $"level{level}.png";
            level2();
        }
        private void BtnDisable()
        {
            btn1.IsEnabled=false;
            btn2.IsEnabled=false;
            btn3.IsEnabled=false;
            btn4.IsEnabled=false;
        }
        private async void ChechHearts()
        {
            if(hearts == 0)
            {
                bool answer =await DisplayAlert("Lost!!", "You have 0 Lives","Buy", "Cancel");
                if (answer)
                {
                    await Navigation.PushAsync(new ShopingPage());
                }
                else
                await Navigation.PushAsync(new HomePage());
            }
        }

        private void checkbtn_Clicked(object sender, EventArgs e)
        {
            if (select_ans == correct_ans)
            {
                CorrectAns();
            }
            else
            {
                WrongAns();
            }
            continuebtn.IsVisible = true;
        }
    }
    
}
