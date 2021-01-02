using Acr.UserDialogs;
using MeterCheck.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using Xamarin.Essentials;

namespace MeterCheck.ViewModels
{
    public class AddMachinePageViewModel : ViewModelBase, IDisposable
    {
        public ReactiveProperty<bool> ShowAddConfirmDialog { get; } = new ReactiveProperty<bool>(true);

        public AsyncReactiveCommand AddMachineCommand { get; } = new AsyncReactiveCommand();

        private CompositeDisposable Disposable { get; } = new CompositeDisposable();

        public AddMachinePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Add Machine Page";

            AddMachineCommand.Subscribe(async () =>
            {
                var ret = true;
                if (ShowAddConfirmDialog.Value)
                {
                    var confirmConfig = new ConfirmConfig()
                    {
                        OkText = "Ok",
                        CancelText = "Cancel",
                        Title = $"{AppInfo.Name}",
                        Message = "Do you want to add this data?",
                    };
                    ret = await UserDialogs.Instance.ConfirmAsync(confirmConfig);
                }

                if (ret)
                {
                    var machine = new Machine()
                    {
                        MachineName = "test",
                        ControlId = "10",
                        CurrentPrizeName = "ねそべり",
                    };
                    var navigationParameters = new NavigationParameters()
                    {
                        { "AddMachine", machine },
                    };
                    await this.NavigationService.GoBackAsync(navigationParameters);
                }
            });
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            ShowAddConfirmDialog.Value = Preferences.Get("ShowAddConfirmDialog", true);
        }

        public void Dispose()
        {
            this.Disposable.Dispose();
        }
    }
}
