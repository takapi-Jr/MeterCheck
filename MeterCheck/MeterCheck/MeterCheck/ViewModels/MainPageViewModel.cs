using Acr.UserDialogs;
using MeterCheck.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MeterCheck.ViewModels
{
    public class MainPageViewModel : ViewModelBase, IDisposable
    {
        public ReactiveProperty<ObservableCollection<Machine>> MachineList { get; } = new ReactiveProperty<ObservableCollection<Machine>>();
        public ReactiveProperty<ObservableCollection<Meter>> MeterList { get; } = new ReactiveProperty<ObservableCollection<Meter>>();
        public ReactiveProperty<ObservableCollection<PrizeReplace>> PrizeReplaceList { get; } = new ReactiveProperty<ObservableCollection<PrizeReplace>>();
        public ReactiveProperty<bool> IsVisibleCarouselView { get; } = new ReactiveProperty<bool>(true);
        public ReactiveProperty<bool> IsVisibleCollectionView { get; } = new ReactiveProperty<bool>(false);
        public ReactiveProperty<bool> ShowDeleteConfirmDialog { get; } = new ReactiveProperty<bool>(true);

        public AsyncReactiveCommand SettingCommand { get; } = new AsyncReactiveCommand();
        public AsyncReactiveCommand AddMachineCommand { get; } = new AsyncReactiveCommand();
        public ReactiveCommand ChangeViewCommand { get; } = new ReactiveCommand();
        public AsyncReactiveCommand<Machine> DeleteMachineCommand { get; } = new AsyncReactiveCommand<Machine>();
        public AsyncReactiveCommand<Machine> MachineDetailCommand { get; } = new AsyncReactiveCommand<Machine>();

        private CompositeDisposable Disposable { get; } = new CompositeDisposable();

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";

            SettingCommand.Subscribe(async () =>
            {
                await this.NavigationService.NavigateAsync("SettingPage");
            }).AddTo(this.Disposable);

            AddMachineCommand.Subscribe(async () =>
            {
                //await this.NavigationService.NavigateAsync("AddMachinePage");

                // テストデータ
                var machine = new Machine()
                {
                    MachineName = "test",
                    ControlId = "10",
                    CurrentPrizeName = "ねそべり",
                };
                var ret = await App.MachineDatabase.SaveMachineAsync(machine);
                Console.WriteLine($"Number of records inserted: {ret}");
                MachineList.Value.Add(machine);
            }).AddTo(this.Disposable);

            ChangeViewCommand.Subscribe(() =>
            {
                IsVisibleCarouselView.Value = !IsVisibleCarouselView.Value;
                IsVisibleCollectionView.Value = !IsVisibleCollectionView.Value;
            }).AddTo(this.Disposable);

            DeleteMachineCommand.Subscribe(async (machine) =>
            {
                var ret = true;
                if (ShowDeleteConfirmDialog.Value)
                {
                    var confirmConfig = new ConfirmConfig()
                    {
                        OkText = "Delete",
                        CancelText = "Cancel",
                        Title = $"{AppInfo.Name}",
                        Message = "Do you want to delete this data?",
                    };
                    ret = await UserDialogs.Instance.ConfirmAsync(confirmConfig);
                }

                if (ret)
                {
                    await DeleteMachineAsync(machine);
                }
            }).AddTo(this.Disposable);

            MachineDetailCommand.Subscribe(async (machine) =>
            {
                //await this.NavigationService.NavigateAsync("MachineDetailPage");
            }).AddTo(this.Disposable);
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            var machineList = await App.MachineDatabase.GetMachineListAsync();
            MachineList.Value = new ObservableCollection<Machine>(machineList);

            ShowDeleteConfirmDialog.Value = Preferences.Get("ShowDeleteConfirmDialog", true);
        }

        private async Task DeleteMachineAsync(Machine machine)
        {
            var ret = await App.MachineDatabase.DeleteMachineAsync(machine);
            Console.WriteLine($"Number of records deleted: {ret}");
            MachineList.Value.Remove(machine);
        }

        public void Dispose()
        {
            this.Disposable.Dispose();
        }
    }
}
