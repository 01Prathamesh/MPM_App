using Android.App;
using Android.Content;
using MPM_App.Models;
using System.Collections.Generic;

[assembly: Xamarin.Forms.Dependency(typeof(MPM_App.Droid.AndroidProcessService))]
namespace MPM_App.Droid
{
    public class AndroidProcessService : IProcessService
    {
        public List<Process> GetRunningProcesses()
        {
            // This method needs permissions to access running processes.
            ActivityManager activityManager = (ActivityManager)Application.Context.GetSystemService(Context.ActivityService);
            var runningApps = activityManager.GetRunningAppProcesses();
            var processes = new List<Process>();

            foreach (var app in runningApps)
            {
                processes.Add(new Process
                {
                    PID = app.ProcessName, // Use a unique identifier
                    Name = app.ProcessName,
                    MemoryUsage = 100, // Placeholder value
                    CPUUsage = 10 // Placeholder value
                });
            }
            return processes;
        }

        public void StopProcess(string pid)
        {
            // Warning: Stopping processes can be risky and should be done with caution.
            ActivityManager activityManager = (ActivityManager)Application.Context.GetSystemService(Context.ActivityService);

            try
            {
                // Attempt to kill the process using the process name (PID is not used correctly here)
                var runningApps = activityManager.GetRunningAppProcesses();
                foreach (var app in runningApps)
                {
                    if (app.ProcessName == pid)
                    {
                        // Killing the process by name (not directly by PID, as this is not recommended)
                        Android.OS.Process.KillProcess(Android.OS.Process.MyPid()); // Placeholder, implement correctly for your needs
                        // Note: You'll need root permissions or special handling to kill certain processes
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process termination
                System.Diagnostics.Debug.WriteLine($"Failed to stop process: {ex.Message}");
            }
        }
    }
}
