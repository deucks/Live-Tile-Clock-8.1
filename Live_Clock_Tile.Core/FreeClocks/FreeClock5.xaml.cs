using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.IO.IsolatedStorage;

namespace Live_Clock_Tile
{
    public partial class FreeClock5 : UserControl
    {
        public FreeClock5()
        {
            InitializeComponent();
            updateUI();
        }

        private void updateUI()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings["clock24"].ToString() == "true")
            {
                hour.Text = DateTime.Now.ToString("HH");
            }
            else
            {
                hour.Text = DateTime.Now.ToString("hh");
            }

            minute.Text = DateTime.Now.ToString("mm");

            var rotateHour = new RotateTransform();
            rotateHour.Angle = 30 * DateTime.Now.Hour;
            var rotateMinute = new RotateTransform();
            rotateMinute.Angle = 6 * DateTime.Now.Minute;

            minuteHand.RenderTransform = rotateMinute;
            hourHand.RenderTransform = rotateHour;
        }
    }
}
