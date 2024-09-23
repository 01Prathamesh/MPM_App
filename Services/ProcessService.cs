using MPM_App.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace MPM_App.Services
{
    public class ProcessService : IProcessService
    {
        public List<Process> GetRunningProcesses()
        {
            // Simulating fetching running processes
            return new List<Process>
            {
                new Process { PID = "1234", Name = "Process 1", MemoryUsage = 150, CPUUsage = 10 },
                new Process { PID = "5678", Name = "Process 2", MemoryUsage = 200, CPUUsage = 25 },
                new Process { PID = "91011", Name = "Process 3", MemoryUsage = 300, CPUUsage = 5 }
            };
        }

        public void StopProcess(string pid)
        {
            // Implement logic to stop the process by PID
            // This is a placeholder; replace with actual implementation
            Debug.WriteLine($"Stopping process with PID: {pid}");
        }
    }
}
