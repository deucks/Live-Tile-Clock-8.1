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

namespace Live_Clock_Tile.Core.PaidClocks
{
    public partial class PayClock12 : UserControl
    {
        public PayClock12()
        {
            InitializeComponent();
            updateUI();
        }

        private void updateUI()
        {
            time.Text = DateTime.Now.ToString("HH:mm");

            var rotateHour = new RotateTransform();
            rotateHour.Angle = 30 * DateTime.Now.Hour;
            rotateHour.Angle += 30 * ((double)DateTime.Now.Minute / 60);
            var rotateMinute = new RotateTransform();
            rotateMinute.Angle = 6 * DateTime.Now.Minute;

            hour.RenderTransform = rotateHour;
            minute.RenderTransform = rotateMinute;

        }
    }
}
