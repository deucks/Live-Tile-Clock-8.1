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

namespace Live_Clock_Tile.Core.WideClocks
{
    public partial class IdeaWide : UserControl
    {
        public IdeaWide()
        {
            InitializeComponent();
            updateUI();
        }

        private void updateUI()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings["clock24"].ToString() == "true")
            {
                hour.Text = DateTime.Now.ToString("H:mm");
            }
            else
            {
                hour.Text = DateTime.Now.ToString("h:mm");
            }

            date.Text = DateTime.Now.DayOfWeek.ToString();

            ampm.Text = DateTime.Now.ToString("tt");
        }
    }
}
