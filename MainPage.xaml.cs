using MPM_App.Models;
using System.Collections.ObjectModel;

namespace MPM_App
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Process> Processes { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Processes = new ObservableCollection<Process>
            {
                new Process { PID = "1", Name = "Process 1", MemoryUsage = 100, CPUUsage = 10 },
                new Process { PID = "2", Name = "Process 2", MemoryUsage = 200, CPUUsage = 20 },
                new Process { PID = "3", Name = "Process 3", MemoryUsage = 150, CPUUsage = 15 }
            };

            processListView.ItemsSource = Processes;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var process = button.BindingContext as Process;

            if (process != null)
            {
                Processes.Remove(process);
                // Logic to stop the process would go here.
            }
        }
    }

}
