using System.Diagnostics;
using System.Windows;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;
using Live_Clock_Tile.Core;
using Live_Clock_Tile.FreeClocks;
using Live_Clock_Tile.PaidClocks;
using System;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;

using Microsoft.Phone.Info;
using System.Collections.Generic;
using System.Linq;

namespace LiveClockAgent
{
    public class ScheduledAgent : ScheduledTaskAgent
    {
        /// <remarks>
        /// ScheduledAgent constructor, initializes the UnhandledException handler
        /// </remarks>
        static ScheduledAgent()
        {
            // Subscribe to the managed exception handler
            Deployment.Current.Dispatcher.BeginInvoke(delegate
            {
                Application.Current.UnhandledException += UnhandledException;
            });
        }

        /// Code to execute on Unhandled Exceptions
        private static void UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                Debugger.Break();
            }
        }

        /// <summary>
        /// Agent that runs a scheduled task
        /// </summary>
        /// <param name="task">
        /// The invoked task
        /// </param>
        /// <remarks>
        /// This method is called when a periodic or resource intensive task is invoked
        /// </remarks>

        protected override void OnInvoke(ScheduledTask task)
        {
            //TODO: Add code to perform your task in background

            ScheduledActionService.LaunchForTest(task.Name, TimeSpan.FromSeconds(61));

            System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() => {
                TileOptions to = new TileOptions();
                to.UpdateTile();
            });

            NotifyComplete();
        }

      
    }
}