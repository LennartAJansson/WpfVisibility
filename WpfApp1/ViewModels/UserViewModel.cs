using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public string ToggleBothEnabled
        {
            get { return toggleBothEnabled; }
            set { Set(nameof(ToggleBothEnabled), ref toggleBothEnabled, value, true); }
        }

        private string toggleBothEnabled;

        public string WindowTitle
        {
            get { return windowTitle; }
            set { Set(nameof(WindowTitle), ref windowTitle, value, true); }
        }

        private string windowTitle;

        public string ShowUC1
        {
            get
            {
                return showUC1;
            }
            set
            {
                Set(nameof(ShowUC1), ref showUC1, value);
            }
        }

        private string showUC1 = "Collapsed";

        public string ShowUC2
        {
            get
            {
                return showUC2;
            }
            set
            {
                Set(nameof(ShowUC2), ref showUC2, value);
            }
        }

        private string showUC2 = "Visible";

        private bool UC1Visible
        {
            get
            {
                return uC1Visible;
            }
            set
            {
                if (value)
                    ShowUC1 = "Visible";
                else
                    ShowUC1 = "Collapsed";
                uC1Visible = value;
            }
        }

        private bool uC1Visible;

        private bool UC2Visible
        {
            get
            {
                return uC2Visible;
            }
            set
            {
                if (value)
                    ShowUC2 = "Visible";
                else
                    ShowUC2 = "Collapsed";
                uC2Visible = value;
            }
        }

        private bool uC2Visible;

        public RelayCommand ShowUC1Command { get; }
        public RelayCommand ShowUC2Command { get; }
        public RelayCommand ShowToggledCommand { get; }

        public UserViewModel()
        {
            ShowUC1Command = new RelayCommand(async () => await ShowUC1Async());
            ShowUC2Command = new RelayCommand(async () => await ShowUC2Async());
            ShowToggledCommand = new RelayCommand(async () => await ToggleBothAsync());
            UC1Visible = true;
            UC2Visible = false;
            GetToggleBothEnabled();
        }

        private void GetToggleBothEnabled()
        {
            //(SelectedPatient == null), ingen SelectedPatient
            //(SelectedPatient != null && SelectedPatient.Id == 0), skapar en ny patient
            //(SelectedPatient != null && SelectedPatient.Id > 0), redigerar befintlig patient

            if (UC1Visible != UC2Visible)
            {
                ToggleBothEnabled = "True";
            }
            else
            {
                ToggleBothEnabled = "False";
            }
        }

        private Task ShowUC1Async()
        {
            UC1Visible = !UC1Visible;
            GetToggleBothEnabled();
            return Task.CompletedTask;
        }

        private Task ShowUC2Async()
        {
            UC2Visible = !UC2Visible;
            GetToggleBothEnabled();
            return Task.CompletedTask;
        }

        private Task ToggleBothAsync()
        {
            UC1Visible = !UC1Visible;
            UC2Visible = !UC2Visible;
            GetToggleBothEnabled();
            return Task.CompletedTask;
        }
    }
}