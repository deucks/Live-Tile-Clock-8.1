using Live_Clock_Tile.PaidClocks;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Live_Clock_Tile.Core;
using Live_Clock_Tile.FreeClocks;
using Live_Clock_Tile.Core.FreeClocks;
using Live_Clock_Tile.Core.PaidClocks;
using Live_Clock_Tile.Core.PaidClocks;
using Live_Clock_Tile.Core.WideClocks;

namespace Live_Clock_Tile.Core
{
    public class TileOptions
    {
        #region WhatClockFaceToPut 
        public WriteableBitmap getBmp()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            if (!settings.Contains("active"))
            {
                settings.Add("active", "Stars");
            }

            System.Diagnostics.Debug.WriteLine(settings["active"].ToString());

            if (settings["active"].ToString() == "Modern")
            {
                var customTile = new FreeClock1();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Idea")
            {
                var customTile = new FreeClock2();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Glow")
            {
                var customTile = new FreeClock3();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Simple")
            {
                var customTile = new FreeClock4();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Stars")
            {
                var customTile = new FreeClock5();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Cortana")
            {
                var customTile = new FreeClock6();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Bold")
            {
                var customTile = new FreeClock7();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Fly")
            {
                var customTile = new FreeClock8();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Hands")
            {
                var customTile = new FreeClock9();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Spot")
            {
                var customTile = new FreeClock10();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Analog")
            {
                var customTile = new FreeClock11();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Decimal")
            {
                var customTile = new FreeClock12();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Modern 2")
            {
                var customTile = new FreeClock13();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));
                

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Planets")
            {
                var customTile = new FreeClock14();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Breeze") //paid starts here
            {
                var customTile = new PayClock1();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Circles") 
            {
                var customTile = new PayClock2();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Zaag")
            {
                var customTile = new PayClock3();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Sunshine")
            {
                var customTile = new PayClock4();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Grin")
            {
                var customTile = new PayClock5();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Crypt")
            {
                var customTile = new PayClock6();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Domo")
            {
                var customTile = new PayClock7();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Minion")
            {
                var customTile = new PayClock8();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "CMD")
            {
                var customTile = new PayClock9();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Poki")
            {
                var customTile = new PayClock11();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Fade")
            {
                var customTile = new PayClock12();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Digital")
            {
                var customTile = new PayClock13();
                customTile.Measure(new Size(336, 336));
                customTile.Arrange(new Rect(0, 0, 336, 336));

                var bmp = new WriteableBitmap(336, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            return new WriteableBitmap(336, 336);
        }
        #endregion

        #region WideClock 
        public WriteableBitmap getWideBmp()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            if (!settings.Contains("active"))
            {
                settings.Add("active", "Stars");
            }

            if (settings["active"].ToString() == "Glow")
            {
                var customTile = new GlowWide();
                customTile.Measure(new Size(691, 336));
                customTile.Arrange(new Rect(0, 0, 691, 336));

                var bmp = new WriteableBitmap(691, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Modern")
            {
                var customTile = new ModernWide();
                customTile.Measure(new Size(691, 336));
                customTile.Arrange(new Rect(0, 0, 691, 336));

                var bmp = new WriteableBitmap(691, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Modern 2")
            {
                var customTile = new Modern2Wide();
                customTile.Measure(new Size(691, 336));
                customTile.Arrange(new Rect(0, 0, 691, 336));

                var bmp = new WriteableBitmap(691, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Idea")
            {
                var customTile = new IdeaWide();
                customTile.Measure(new Size(691, 336));
                customTile.Arrange(new Rect(0, 0, 691, 336));

                var bmp = new WriteableBitmap(691, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Simple")
            {
                var customTile = new SimpleWide();
                customTile.Measure(new Size(691, 336));
                customTile.Arrange(new Rect(0, 0, 691, 336));

                var bmp = new WriteableBitmap(691, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Analog")
            {
                var customTile = new AnalogWide();
                customTile.Measure(new Size(691, 336));
                customTile.Arrange(new Rect(0, 0, 691, 336));

                var bmp = new WriteableBitmap(691, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Domo")
            {
                var customTile = new DomoWide();
                customTile.Measure(new Size(691, 336));
                customTile.Arrange(new Rect(0, 0, 691, 336));

                var bmp = new WriteableBitmap(691, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Decimal")
            {
                var customTile = new DecimalWide();
                customTile.Measure(new Size(691, 336));
                customTile.Arrange(new Rect(0, 0, 691, 336));

                var bmp = new WriteableBitmap(691, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Sunshine")
            {
                var customTile = new SunshineWide();
                customTile.Measure(new Size(691, 336));
                customTile.Arrange(new Rect(0, 0, 691, 336));

                var bmp = new WriteableBitmap(691, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Zaag")
            {
                var customTile = new ZaagWide();
                customTile.Measure(new Size(691, 336));
                customTile.Arrange(new Rect(0, 0, 691, 336));

                var bmp = new WriteableBitmap(691, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "CMD")
            {
                var customTile = new CmdWide();
                customTile.Measure(new Size(691, 336));
                customTile.Arrange(new Rect(0, 0, 691, 336));

                var bmp = new WriteableBitmap(691, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Poki")
            {
                var customTile = new PokiWide();
                customTile.Measure(new Size(691, 336));
                customTile.Arrange(new Rect(0, 0, 691, 336));

                var bmp = new WriteableBitmap(691, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Fade")
            {
                var customTile = new FadeWide();
                customTile.Measure(new Size(691, 336));
                customTile.Arrange(new Rect(0, 0, 691, 336));

                var bmp = new WriteableBitmap(691, 365);
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else if (settings["active"].ToString() == "Digital")
            {
                var customTile = new DigitalWide();

                customTile.Measure(new Size(691, 336));
                customTile.Arrange(new Rect(0, 0, 691, 336));
  

                var bmp = new WriteableBitmap(691, 365);
                
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
            else
            {
                var customTile = new NoTile();
                customTile.Measure(new Size(691, 336));
                customTile.Arrange(new Rect(0, 0, 691, 336));

                var bmp = new WriteableBitmap(691, 365);
                
                bmp.Render(customTile, null);
                bmp.Invalidate();
                return bmp;
            }
        }
        #endregion

        public void preStartCheck()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains("clock24"))
            {
                settings.Add("clock24", "false");
            }
        }


        public void UpdateTile()
        {


            preStartCheck();

            const string filename = "/Shared/ShellContent/CustomTile.png";
            const string wideFilename = "/Shared/ShellContent/CustomTileWide.png";

            //create small tile
            using (var isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!isf.DirectoryExists("/CustomLiveTiles"))
                {
                    isf.CreateDirectory("/CustomLiveTiles");
                }

                using (var stream = isf.OpenFile(filename, System.IO.FileMode.OpenOrCreate))
                {
                    //bmp.SaveJpeg(stream, 336, 366, 0, 100);
                    getBmp().WritePNG(stream);
                }
                //create large tile
                using (var stream = isf.OpenFile(wideFilename, System.IO.FileMode.OpenOrCreate))
                {
                    getWideBmp().WritePNG(stream);
                }
            }

            //update
            try
            {
                FlipTileData tileData = new FlipTileData
                {
                    BackgroundImage = new Uri("isostore:" + filename, UriKind.Absolute),
                };


                ShellTile tile = ShellTile.ActiveTiles.First();
                if (null != tile)
                {
                    foreach (var sec in ShellTile.ActiveTiles)
                    {
                        FlipTileData data = new FlipTileData();
                        // tile foreground data
                        data.BackgroundImage = new Uri("isostore:" + filename, UriKind.Absolute);
                        data.WideBackgroundImage = new Uri("isostore:" + wideFilename, UriKind.Absolute);
                        // update tile
                        sec.Update(data);
                    }
                    // create a new data for tile

                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
    }
}
