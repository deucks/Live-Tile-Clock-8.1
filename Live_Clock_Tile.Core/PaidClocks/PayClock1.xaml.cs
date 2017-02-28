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

namespace Live_Clock_Tile
{
    public partial class PayClock1 : UserControl
    {
        public PayClock1()
        {
            InitializeComponent();
            updateUI();
        }

        private void updateUI()
        {
            ampm.Text = DateTime.Now.ToString("tt");

            var rotateHour = new RotateTransform();
            rotateHour.Angle = 30 * DateTime.Now.Hour;
            rotateHour.Angle += 30 * ((double)DateTime.Now.Minute / 60);
            var rotateMinute = new RotateTransform();
            rotateMinute.Angle = 6 * DateTime.Now.Minute;

            minute.RenderTransform = rotateHour;
            hourHand.RenderTransform = rotateMinute;
        }
    }
}
