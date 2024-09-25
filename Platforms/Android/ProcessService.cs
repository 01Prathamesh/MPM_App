using Android.App;
using Android.Content;
using Android.Util;
using MPM_App.Models; 
using MPM_App.Services;
using System.Collections.Generic;

namespace MPM_App.Platforms.Android
{
    public class ProcessService : IProcessService
    {
        public List<MPM_App.Models.Process> GetRunningProcesses()
        {
            // Simulating fetching running processes
            return new List<MPM_App.Models.Process>
            {
                new MPM_App.Models.Process { PID = "1234", Name = "Process 1", MemoryUsage = 150, CPUUsage = 10 },
                new MPM_App.Models.Process { PID = "5678", Name = "Process 2", MemoryUsage = 200, CPUUsage = 25 },
                new MPM_App.Models.Process { PID = "91011", Name = "Process 3", MemoryUsage = 300, CPUUsage = 5 }
            };
        }

        public void StopProcess(string pid)
        {
            try
            {
                // Use Android's Application
                var activityManager = (ActivityManager)Android.App.Application.Context.GetSystemService(Context.ActivityService);

                // This requires the appropriate permissions in the Android manifest
                activityManager.KillBackgroundProcesses(pid);
                Log.Debug("ProcessService", $"Stopped process with PID: {pid}");
            }
            catch (System.Exception ex)
            {
                Log.Error("ProcessService", $"Error stopping process: {ex.Message}");
            }
        }
    }
}
