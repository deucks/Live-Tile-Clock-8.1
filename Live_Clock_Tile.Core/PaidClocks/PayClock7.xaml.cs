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

namespace Live_Clock_Tile.Core.PaidClocks
{
    public partial class PayClock7 : UserControl
    {
        public PayClock7()
        {
            InitializeComponent();
            updateUI();
        }

        private void updateUI()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            if (settings["clock24"].ToString() == "true")
            {
                hour.Text = DateTime.Now.ToString("HH:mm");
            }
            else
            {
                hour.Text = DateTime.Now.ToString("hh:mm");
            }
        }
    }
}
