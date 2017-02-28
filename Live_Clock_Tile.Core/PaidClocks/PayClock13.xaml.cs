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
    public partial class PayClock13 : UserControl
    {
        public PayClock13()
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
            month.Text = DateTime.Now.DayOfWeek.ToString().Substring(0, 3) + ". " + DateTime.Now.ToString("dd");
            ampm.Text = DateTime.Now.ToString("tt");
        }
    }
}
