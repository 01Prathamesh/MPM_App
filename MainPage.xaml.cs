using MPM_App.Models;
using MPM_App.Services;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace MPM_App
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Process> Processes { get; set; }

        public MainPage()
        {
            InitializeComponent();
            
            // Initialize the ObservableCollection
            Processes = new ObservableCollection<Process>();
            
            // Access the process service using DependencyService
            var processService = DependencyService.Get<IProcessService>();
            
            // Retrieve running processes
            var runningProcesses = processService.GetRunningProcesses();
            
            // Populate the ObservableCollection with the retrieved processes
            foreach (var process in runningProcesses)
            {
                Processes.Add(process);
            }

            // Set the ItemsSource of the CollectionView
            processListView.ItemsSource = Processes;
        }

        private async void OnStopButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var process = button.BindingContext as Process;

            if (process != null)
            {
                bool confirm = await DisplayAlert("Confirm", $"Are you sure you want to stop {process.Name}?", "Yes", "No");
                
                if (confirm)
                {
                    Processes.Remove(process);
                    var processService = DependencyService.Get<IProcessService>();
                    processService.StopProcess(process.PID);
                }
            }
        }
        
        private async void LoadProcesses()
        {
            loadingIndicator.IsVisible = true;
            loadingIndicator.IsRunning = true;

            var processService = DependencyService.Get<IProcessService>();
            var runningProcesses = await Task.Run(() => processService.GetRunningProcesses());

            Processes.Clear();
            foreach (var process in runningProcesses)
            {
                Processes.Add(process);
            }

            loadingIndicator.IsRunning = false;
            loadingIndicator.IsVisible = false;
        }
    }
}
