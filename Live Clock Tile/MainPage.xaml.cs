using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Live_Clock_Tile.Resources;
using System.IO.IsolatedStorage;
using System.Windows.Media.Imaging;
using Live_Clock_Tile.FreeClocks;
using Live_Clock_Tile.PaidClocks;
using ImageTools.IO.Png;
using Microsoft.Phone.Tasks;
using Live_Clock_Tile.Core;
using Microsoft.Phone.Scheduler;
using System.Diagnostics;
using Windows.ApplicationModel.Store;

namespace Live_Clock_Tile
{

    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor

        LibraryList library = new LibraryList();
        string nameTemp;
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

        private string periodicTaskName = "LiveTilePeriodicAgent";
        private PeriodicTask periodicTask;

        TileOptions to = new TileOptions();
        int buyAllCount = 0;

        public MainPage()
        {
            InitializeComponent();

            FillListBox();
            startClear.Begin();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            to.preStartCheck();
            //to.UpdateTile();
            StartPeriodicAgent();
            changeUI();

        }

        private void changeUI()
        {
            if (settings["clock24"].ToString() == "true")
            {
                mode24.Text = "disable 24h mode";
            }
        }
        

        private void FillListBox()
        {
            listBox1.ItemsSource = library.getList();
            listBox2.ItemsSource = new FreeList();
            listBox3.ItemsSource = new PayList();

            int i = 0;
            foreach (LibraryFace l in library.justGetList())
            {
                i++;
            }
            if (i == 0)
                MessageBox.Show("It seems like you have no themes in your library, swipe to the left to get some! ", "Welcome!", MessageBoxButton.OK);
        }

        //tile updating
        private void PinTile()
        {
            try
            {
                ShellTile TileToFind = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("Flip".ToString()));
                TileToFind.Delete();

                FlipTileData tileData = new FlipTileData
                {
                    BackgroundImage = new Uri("Icons/runNew.png", UriKind.RelativeOrAbsolute),
                    WideBackgroundImage = new Uri("Icons/wideRun.png", UriKind.RelativeOrAbsolute)
                };

                ShellTile.Create(new Uri("/MainPage.xaml?Flip", UriKind.Relative), tileData, true);
            }
            catch (Exception e)
            {
                FlipTileData tileData = new FlipTileData
                {
                    BackgroundImage = new Uri("Icons/runNew.png", UriKind.RelativeOrAbsolute),
                    WideBackgroundImage = new Uri("Icons/wideRun.png", UriKind.RelativeOrAbsolute)
                };

                ShellTile.Create(new Uri("/MainPage.xaml?Flip", UriKind.Relative), tileData, true);
            }
        }



        //selection events 
        async private void listBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                PayFace selectedBook = (listBox3.SelectedItems[0]) as PayFace;
                if (selectedBook.Price.Contains("Rate"))
                {
                    listBox1.ItemsSource = null;
                    library.add(selectedBook.Name, selectedBook.Img, selectedBook.Wide);
                    listBox1.ItemsSource = library.getList();

                    MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
                    marketplaceReviewTask.Show();

                }
                else if (selectedBook.Name.Contains("Buy"))
                {
                    MessageBoxResult m = MessageBox.Show("Would you like to add all premium faces to library?", "Purchase all Clock Faces", MessageBoxButton.OKCancel);
                    if (m == MessageBoxResult.OK)
                    {
                        var listing = await CurrentApp.LoadListingInformationAsync();
                        var superweapon =
                        listing.ProductListings.FirstOrDefault(p => p.Value.ProductId == selectedBook.Buycode && p.Value.ProductType == ProductType.Durable);
                        try
                        {
                            if (CurrentApp.LicenseInformation.ProductLicenses[superweapon.Value.ProductId].IsActive)
                            {
                                PayList pl = new PayList();
                                foreach (PayFace l in pl)
                                {
                                    if (!l.Name.ToString().Contains("Buy All"))
                                    {
                                        listBox1.ItemsSource = null;
                                        library.justAdd(l.Name.ToString(), l.Img.ToString(), l.Wide.ToString());
                                    }
                                }
                                library.justSave();
                                listBox1.ItemsSource = library.getList();
                                MessageBox.Show("Library has been updated", "Restored", MessageBoxButton.OK);
                            }
                            else
                            {
                                var receipt = await CurrentApp.RequestProductPurchaseAsync(superweapon.Value.ProductId, true);

                                PayList pl = new PayList();
                                foreach (PayFace l in pl)
                                {
                                    if (!l.Name.ToString().Contains("Buy All"))
                                    {
                                        listBox1.ItemsSource = null;
                                        library.justAdd(l.Name.ToString(), l.Img.ToString(), l.Wide.ToString());
                                    }
                                }
                                library.justSave();
                                listBox1.ItemsSource = library.getList();
                                MessageBox.Show("Thank you for purchasing the premium clock faces. It has been added to your library. You can restore / update your purchase library by clicking on the 'Buy All' button.", "Awesome", MessageBoxButton.OK);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Cannot purchase at the moment.");
                        }
                    }
                }
                else
                {
                    MessageBoxResult m = MessageBox.Show("Would you like to add this to your library?", "Purchase " + selectedBook.Name.ToString() + " Clock Face", MessageBoxButton.OKCancel);
                    if (m == MessageBoxResult.OK)
                    {
                        var listing = await CurrentApp.LoadListingInformationAsync();
                        var superweapon =
                        listing.ProductListings.FirstOrDefault(p => p.Value.ProductId == selectedBook.Buycode && p.Value.ProductType == ProductType.Durable);
                        try
                        {
                            if (CurrentApp.LicenseInformation.ProductLicenses[superweapon.Value.ProductId].IsActive)
                            {
                                listBox1.ItemsSource = null;
                                library.add(selectedBook.Name, selectedBook.Img, selectedBook.Wide);
                                listBox1.ItemsSource = library.getList();

                                MessageBox.Show("You already own this clock face, the purchase has been restored to your library", "Restored", MessageBoxButton.OK);
                            }
                            else
                            {
                                string receipt = await CurrentApp.RequestProductPurchaseAsync(superweapon.Value.ProductId, true);

                                listBox1.ItemsSource = null;
                                library.add(selectedBook.Name, selectedBook.Img, selectedBook.Wide);
                                listBox1.ItemsSource = library.getList();

                                MessageBox.Show("Thank you for purchasing the clock face. It has been added to your library.", "Awesome", MessageBoxButton.OK);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Cannot purchase at the moment.");
                        }
                    }
                }                
                listBox3.SelectedIndex = -1;
            }
            catch
            {

            }
        }

        private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                FreeFace selectedBook = (listBox2.SelectedItems[0]) as FreeFace;
                MessageBoxResult m = MessageBox.Show(AppResources.AddToLibrary.ToString(), selectedBook.Name.ToString() + " Clock Face", MessageBoxButton.OKCancel);
                if (m == MessageBoxResult.OK)
                {
                    listBox1.ItemsSource = null;
                    library.add(selectedBook.Name, selectedBook.Img, selectedBook.Wide);
                    listBox1.ItemsSource = library.getList();
                    MessageBox.Show("Swipe right to access and activate the clock face.", "Clock face added!", MessageBoxButton.OK);
                }
                listBox2.SelectedIndex = -1;
            }
            catch
            {
 
            }
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            try
            {
                activeShow.Begin();
                LibraryFace selectedBook = (listBox1.SelectedItems[0]) as LibraryFace;
                activate.Text = "activate " + selectedBook.Name.ToString() + " ?";
                nameTemp = selectedBook.Name.ToString();
                listBox1.SelectedIndex = -1;
            }
            catch
            {
 
            }
            

        }

        private void StartPeriodicAgent()
        {
            try
            {
                periodicTask = ScheduledActionService.Find(periodicTaskName) as PeriodicTask;
                if (periodicTask != null)
                {
                    try
                    {
                        ScheduledActionService.Remove(periodicTaskName);
                    }
                    catch (Exception)
                    {
                    }
                }
                // create a new task
                periodicTask = new PeriodicTask(periodicTaskName);
                // load description from localized strings
                periodicTask.Description = "This is LiveTile application update agent.";
                // set expiration days
                periodicTask.ExpirationTime = DateTime.Now.AddDays(14);
                try
                {
                    // add thas to scheduled action service
                    ScheduledActionService.Add(periodicTask);
                    // debug, so run in every 30 secs
                    //#if DEBUG_AGENT
                    //                
                    //                ScheduledActionService.LaunchForTest(periodicTaskName, TimeSpan.FromSeconds(10));
                    //                System.Diagnostics.Debug.WriteLine("Periodic task is started: " + periodicTaskName);
                    //#endif
                    if (Debugger.IsAttached)
                    {
                        //ScheduledActionService.LaunchForTest(periodicTaskName, TimeSpan.FromSeconds(30));
                        System.Diagnostics.Debug.WriteLine("Periodic task is started: " + periodicTaskName);
                    }

                    ScheduledActionService.LaunchForTest(periodicTaskName, TimeSpan.FromSeconds(61));

                }
                catch (InvalidOperationException exception)
                {
                    if (exception.Message.Contains("BNS Error: The action is disabled"))
                    {
                        // load error text from localized strings
                        MessageBox.Show("Background agents for this application have been disabled by the user.");
                    }
                    if (exception.Message.Contains("BNS Error: The maximum number of ScheduledActions of this type have already been added."))
                    {
                        // No user action required. The system prompts the user when the hard limit of periodic tasks has been reached.
                    }
                }
                catch (SchedulerServiceException)
                {
                    // No user action required.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("You have too many background tasks running, cannot add this app to update percentage on live tile. Remove some background apps from setting and return here");

            }
            // is old task running, remove it

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            library.deleteData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            activeEnd.Begin();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            activate.Text = "ok!";
            if (!settings.Contains("active"))
            {
                settings.Add("active", nameTemp);
            }
            else
            {
                settings["active"] = nameTemp;
            }
            settings.Save();
            activeEnd.Begin();
            PinTile();
        }

        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.Subject = "Live Tile Clock";
            emailComposeTask.To = "cskdev@hotmail.com";
            emailComposeTask.Show();
        }

        private void TextBlock_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }

        private void TextBlock_Tap_2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Windows.System.Launcher.LaunchUriAsync(new Uri("fb:pages?id=293494454188542"));
        }

        private void _24check_Click(object sender, RoutedEventArgs e)
        {


        }

        private void TextBlock_Tap_3(object sender, System.Windows.Input.GestureEventArgs e)
        {
            to.UpdateTile();
        }

        private void TextBlock_Tap_4(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (mode24.Text == "enable 24h mode")
            {
                settings["clock24"] = "true";
                mode24.Text = "disable 24h mode";
            }
            else if (mode24.Text == "disable 24h mode")
            {
                settings["clock24"] = "false";
                mode24.Text = "enable 24h mode";
            }
            settings.Save();
        }

        private void TextBlock_Tap_5(object sender, System.Windows.Input.GestureEventArgs e)
        {
            StartPeriodicAgent();
        }

        private void TextBlock_Tap_6(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("To restore clocks just click on the clocks you have bought and they will automatically restore for you.", "How to restore purchase", MessageBoxButton.OK);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_Tap_7(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (buyAllCount == 9)
            {
                PayList pl = new PayList();
                foreach (PayFace l in pl)
                {
                    if (!l.Name.ToString().Contains("Buy All"))
                    {
                        listBox1.ItemsSource = null;
                        library.justAdd(l.Name.ToString(), l.Img.ToString(), l.Wide.ToString());
                    }
                }
                library.justSave();
                listBox1.ItemsSource = library.getList();

                MessageBox.Show("Purchase Restored");
            }
            buyAllCount++;
            
        }

        private void TextBlock_Tap_8(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("Tips to make clock update:" + Environment.NewLine + Environment.NewLine + "- Open Batter Saver and disable background tasks in apps you dont use often" + Environment.NewLine + "- SOFT RESTART your phone and opening Live Tile Clock 8.1 by holding down Volume Down + Power for 10 seconds" , "Clock doesn't update?", MessageBoxButton.OK);
        }

        private void TextBlock_Tap_9(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("Bogdan Yemchuk - Ukranian" + Environment.NewLine + "Edgar Omar Vázquez Muñiz - Spanish", "Translation Credits", MessageBoxButton.OK);
        }

        private void TextBlock_Tap_10(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();

            webBrowserTask.Uri = new Uri("http://deucks.com", UriKind.Absolute);

            webBrowserTask.Show();
        }

    }
}