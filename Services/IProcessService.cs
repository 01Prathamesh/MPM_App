using MPM_App.Models;
using System.Collections.Generic;

namespace MPM_App.Services
{
    public interface IProcessService
    {
        List<Process> GetRunningProcesses();
        void StopProcess(string pid);
    }
}
