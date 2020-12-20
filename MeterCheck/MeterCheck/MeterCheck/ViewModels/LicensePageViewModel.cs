﻿using MeterCheck.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;

namespace MeterCheck.ViewModels
{
    public class LicensePageViewModel : ViewModelBase, IDisposable
    {
        public ReactiveProperty<List<string>> LibNameList { get; } = new ReactiveProperty<List<string>>();
        public ReactiveProperty<string> SelectedLibName { get; } = new ReactiveProperty<string>();

        private CompositeDisposable Disposable { get; } = new CompositeDisposable();

        public LicensePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "License Page";

            LibNameList.Value = new List<string>
            {
                Common.NETStandardLibrary,
                Common.PrismUnityForms,
                Common.ReactiveProperty,
                Common.SqliteNetPcl,
                Common.XamarinEssentialsInterfaces,
                Common.XamarinForms,
            };

            SelectedLibName.Subscribe(async libName =>
            {
                if (!string.IsNullOrEmpty(libName))
                {
                    var navigationParameters = new NavigationParameters()
                    {
                        //{ "キー", 値 },
                        { "LibName", libName },
                    };
                    await this.NavigationService.NavigateAsync("LicenseDetailPage", navigationParameters);
                }
            }).AddTo(this.Disposable);
        }

        public void Dispose()
        {
            this.Disposable.Dispose();
        }
    }
}
