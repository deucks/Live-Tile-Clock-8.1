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

namespace Live_Clock_Tile.Core.FreeClocks
{
    public partial class FreeClock12 : UserControl
    {
        public FreeClock12()
        {
            InitializeComponent();
            updateUI();
        }

        private void updateUI()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings["clock24"].ToString() == "true")
            {
                time.Text = DateTime.Now.ToString("HH:mm");
            }
            else
            {
                time.Text = DateTime.Now.ToString("hh:mm");
            }
            month.Text = DateTime.Now.ToString("MMMM dd");
            ampm.Text = DateTime.Now.ToString("tt");
        }
    }
}
