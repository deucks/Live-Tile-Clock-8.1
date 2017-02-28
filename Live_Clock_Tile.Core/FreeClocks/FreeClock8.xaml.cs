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

namespace Live_Clock_Tile.FreeClocks
{
    public partial class FreeClock8 : UserControl
    {
        public FreeClock8()
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
        }
    }
}
