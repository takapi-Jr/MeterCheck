using MeterCheck.Data;
using MeterCheck.ViewModels;
using MeterCheck.Views;
using Prism;
using Prism.Ioc;
using System;
using System.IO;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace MeterCheck
{
    public partial class App
    {
        #region Database

        private static MachineDatabase _machineDatabase;
        public static MachineDatabase MachineDatabase
        {
            get 
            {
                if (_machineDatabase == null)
                {
                    var dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    _machineDatabase = new MachineDatabase(Path.Combine(dir, "Machine.db3"));
                }
                return _machineDatabase;
            }
        }

        private static MeterDatabase _meterDatabase;
        public static MeterDatabase MeterDatabase
        {
            get
            {
                if (_meterDatabase == null)
                {
                    var dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    _meterDatabase = new MeterDatabase(Path.Combine(dir, "Meter.db3"));
                }
                return _meterDatabase;
            }
        }

        private static PrizeReplaceDatabase _prizeReplaceDatabase;
        public static PrizeReplaceDatabase PrizeReplaceDatabase
        {
            get
            {
                if (_prizeReplaceDatabase == null)
                {
                    var dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    _prizeReplaceDatabase = new PrizeReplaceDatabase(Path.Combine(dir, "PrizeReplace.db3"));
                }
                return _prizeReplaceDatabase;
            }
        }

        #endregion



        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingPage, SettingPageViewModel>();
            containerRegistry.RegisterForNavigation<LicensePage, LicensePageViewModel>();
            containerRegistry.RegisterForNavigation<LicenseDetailPage, LicenseDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<AddMachinePage, AddMachinePageViewModel>();
        }
    }
}
