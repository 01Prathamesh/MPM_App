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
        public List<Process> GetRunningProcesses()
        {
            ActivityManager activityManager = (ActivityManager)Android.App.Application.Context.GetSystemService(Context.ActivityService);
            var runningApps = activityManager.GetRunningAppProcesses();
            var processes = new List<Process>();

            foreach (var service in runningServices)
            {
                processes.Add(new Process
                {
                    PID = service.Process,
                    Name = service.Service.PackageName, // Get the package name for the process
                    MemoryUsage = 100, // Placeholder
                    CPUUsage = 10 // Placeholder
                });
            }
            return processes;
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
