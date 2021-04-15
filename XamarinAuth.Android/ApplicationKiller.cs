using Xamarin.Forms;
using XamarinAuth.Droid;

[assembly: Dependency(typeof(ApplicationKiller))]
namespace XamarinAuth.Droid
{
    public class ApplicationKiller : IApplicationKiller
    {
        public void CloseApplication()
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}