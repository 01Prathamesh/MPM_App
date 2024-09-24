using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPM_App.Models
{
    public class Process
    {
        public required string PID { get; set; } // Process ID
        public required string Name { get; set; } // Process Name
        public int MemoryUsage { get; set; } // Memory Usage in MB
        public int CPUUsage { get; set; } // CPU Usage in %
    }
}
