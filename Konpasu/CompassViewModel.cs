using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Konpasu
{
    internal class CompassViewModel : BaseViewModel
    {
        #region Properties
        private int _heading = 0;
        public int Heading
        {
            get => _heading;
            set => SetProperty(ref _heading, value);
        }

        private string _headingDisplay;
        public string HeadingDisplay
        {
            get => _headingDisplay;
            set => SetProperty(ref _headingDisplay, value);
        }

        public ICommand StartCompassCommand { get; }
        public ICommand StopCompassCommand { get; }
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
            Heading = (int)(e.Reading.HeadingMagneticNorth);
            HeadingDisplay = $"Heading: {Heading}°";
        }
        #endregion
    }
}
