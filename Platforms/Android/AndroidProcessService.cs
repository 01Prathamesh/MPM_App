using Android.App;
using Android.Content;
using MPM_App.Models;
using MPM_App.Services;
using System.Collections.Generic;

[assembly: Microsoft.Maui.Controls.Dependency(typeof(MPM_App.Droid.AndroidProcessService))]
namespace MPM_App.Droid
{
    public class AndroidProcessService : IProcessService
    {
        public List<MPM_App.Models.Process> GetRunningProcesses()
        {
            var runningProcesses = new List<MPM_App.Models.Process>();

            var activityManager = (ActivityManager)Application.Context.GetSystemService(Context.ActivityService);

            // Check if the method is available based on your API level
            var appProcesses = activityManager.GetRunningAppProcesses();

            if (appProcesses != null)
            {
                foreach (var process in appProcesses)
                {
                    runningProcesses.Add(new MPM_App.Models.Process
                    {
                        PID = process.Pid.ToString(),
                        Name = process.ProcessName,
                        // You may not be able to get MemoryUsage and CPUUsage directly for other apps
                        MemoryUsage = 0, // Placeholder
                        CPUUsage = 0 // Placeholder
                    });
                }
            }

            return runningProcesses;
        }


        public void StopProcess(string pid)
        {
            ActivityManager activityManager = (ActivityManager)Application.Context.GetSystemService(Context.ActivityService);

            try
            {
                var runningApps = activityManager.GetRunningAppProcesses();
                foreach (var app in runningApps)
                {
                    if (app.ProcessName == pid)
                    {
                        Android.OS.Process.KillProcess(Android.OS.Process.MyPid()); // Placeholder for process termination
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to stop process: {ex.Message}");
            }
        }
    }
}
