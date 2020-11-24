using Microsoft.Extensions.DependencyInjection;

using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    public class ViewModelLocator
    {
        public UserViewModel UserViewModel
        {
            get
            {
                return GetUserViewModel().GetAwaiter().GetResult();
            }
        }

        public static Task<UserViewModel> GetUserViewModel()
        {
            UserViewModel vm = App.ServiceProvider.GetRequiredService<UserViewModel>();
            //await vm.RefreshPatientsAsync();
            return Task.FromResult(vm);
        }
    }
}