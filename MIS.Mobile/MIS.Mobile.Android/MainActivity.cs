using Android.App;
using Android.Content.PM;
using Android.OS;
using MIS.Mobile.Helpers;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;

namespace MIS.Mobile.Droid
{
    [Activity(Label = "MIS.Mobile", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            DependencyService.Register<FileHelper>();
            LoadApplication(new App(new AndroidInitializer()));
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            // Register any platform specific implementations
        }
    }
    public class FileHelper : IFileHelper
    {
        public string GetPath()
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)
                return path;
        }
    }
}

