using Xamarin.Essentials;
using Xamarin.Forms;

namespace Konpasu
{
    internal class CompassViewModel : MvvmHelpers.BaseViewModel
    {
        #region Properties
        private double heading = 0;
        public double Heading
        {
            get => heading;
            set => SetProperty(ref heading, value);
        }

        private string headingDisplay;
        public string HeadingDisplay
        {
            get => headingDisplay;
            set => SetProperty(ref headingDisplay, value);
        }

        public Command StartCompassCommand { get; }
        public Command StopCompassCommand { get; }
        #endregion

        /* Constructor */
        public CompassViewModel()
        {
            StartCompassCommand = new Command(StartCompass);
            StopCompassCommand = new Command(StopCompass);
        }

        #region Methods
        private void StartCompass()
        {
            if (Compass.IsMonitoring)
            {
                return;
            }

            Compass.ReadingChanged += CompassReading;
            Compass.Start(SensorSpeed.UI, true);
        }

        private void StopCompass()
        {
            if (!Compass.IsMonitoring)
            {
                return;
            }

            Compass.ReadingChanged -= CompassReading;
            Compass.Stop();
        }

        private void CompassReading(object sender, CompassChangedEventArgs e)
        {
            Heading = e.Reading.HeadingMagneticNorth;
            HeadingDisplay = $"Heading: {Heading}";
        }
        #endregion
    }
}
