using System.Collections.Generic;

namespace MPM_App.Models
{
    public interface IProcessService
    {
        List<Process> GetRunningProcesses();
        void StopProcess(string pid);
    }
}
