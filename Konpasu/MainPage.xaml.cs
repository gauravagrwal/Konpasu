using Xamarin.Forms;

namespace Konpasu
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((CompassViewModel)BindingContext).StartCompassCommand.Execute(null);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((CompassViewModel)BindingContext).StopCompassCommand.Execute(null);
        }
    }
}
