using MAM_App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MAM_App.Services
{
    public class ProcessService
    {
        public Task<List<ProcessModel>> GetProcessesAsync()
        {
            // Simulate fetching process data
            var processes = new List<ProcessModel>
            {
                new ProcessModel { ProcessName = "Process 1", Status = "Running" },
                new ProcessModel { ProcessName = "Process 2", Status = "Stopped" },
                new ProcessModel { ProcessName = "Process 3", Status = "Running" }
            };

            return Task.FromResult(processes);
        }
    }
}
