using Prism;
using Prism.Ioc;
using MIS.Mobile.ViewModels;
using MIS.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MIS.Mobile
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<CoursePage>();
            containerRegistry.RegisterForNavigation<CourseDetailPage>();
            containerRegistry.RegisterForNavigation<LoginPage>();
            containerRegistry.RegisterForNavigation<SignupPage>();
            containerRegistry.RegisterForNavigation<SignupDetailPage>();
            containerRegistry.RegisterForNavigation<PrismMasterDetailPage1>();
            containerRegistry.RegisterForNavigation<MyProfilePage>();
            containerRegistry.RegisterForNavigation<EventPage>();
            containerRegistry.RegisterForNavigation<EvaluationPage>();
            containerRegistry.RegisterForNavigation<LiabilitiesPage>();
            containerRegistry.RegisterForNavigation<AttendancePage>();
        }
    }
}
