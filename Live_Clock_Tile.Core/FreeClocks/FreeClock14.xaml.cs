using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.Windows.Media;

namespace Live_Clock_Tile.Core.FreeClocks
{
    public partial class FreeClock14 : UserControl
    {
        public FreeClock14()
        {
            InitializeComponent();
            updateUI();
        }

        private void updateUI()
        {/**
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings["clock24"].ToString() == "true")
            {
                hour.Text = DateTime.Now.ToString("HHmm");
            }
            else
            {
                hour.Text = DateTime.Now.ToString("hhmm");
            }

            var rotateMinute = new RotateTransform();
            rotateMinute.Angle = (6 * DateTime.Now.Minute) - 90;
            if (rotateMinute.Angle > 90 && rotateMinute.Angle < 270)
            {
                rotateMinute.CenterX = 180;
                rotateMinute.CenterY = 180;
            }
            else
            {
                rotateMinute.CenterX = 0;
                rotateMinute.CenterY = 0;
            }

            hour.RenderTransform = rotateMinute;
          */
        }
    }
}
