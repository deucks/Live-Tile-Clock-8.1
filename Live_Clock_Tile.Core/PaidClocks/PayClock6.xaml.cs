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
    public partial class PayClock6 : UserControl
    {
        public PayClock6()
        {
            InitializeComponent();
            updateUI();
        }

        private void updateUI()
        {
            

            Random rnd = new Random();
            int number1 = rnd.Next(56147, 99999);
            int number2 = rnd.Next(56147, 99999);

            rnd1.Text = number1.ToString() + number2.ToString();
            rnd2.Text = number2.ToString() + number1.ToString();
            rnd3.Text = number1.ToString() + number2.ToString();
            rnd4.Text = number1.ToString() + number2.ToString();
            rnd5.Text = number2.ToString() + number1.ToString();
            rnd6.Text = number1.ToString() + number2.ToString();
            rnd7.Text = number2.ToString() + number1.ToString();
            rnd8.Text = number1.ToString() + number2.ToString();

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
