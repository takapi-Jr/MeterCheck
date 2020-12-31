﻿using MeterCheck.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeterCheck.ViewModels
{
    public class LicenseDetailPageViewModel : ViewModelBase
    {
        public ReactiveProperty<string> LibCopyright { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> LibLicense { get; } = new ReactiveProperty<string>();

        public LicenseDetailPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            var libName = parameters.GetValue<string>("LibName");
            this.Title = libName;

            // コピーライト文、ライセンス文を設定
            LibCopyright.Value = string.Empty;
            LibLicense.Value = string.Empty;

            if (libName.Equals(Common.NETStandardLibrary))
            {
                LibCopyright.Value = this.NETStandardLibrary_LicenseText;
                LibLicense.Value = this.MITLicenseText;
            }
            else if (libName.Equals(Common.PrismUnityForms))
            {
                LibCopyright.Value = this.PrismUnityForms_LicenseText;
                LibLicense.Value = this.MITLicenseText;
            }
            else if (libName.Equals(Common.ReactiveProperty))
            {
                LibCopyright.Value = this.ReactiveProperty_LicenseText;
                LibLicense.Value = this.MITLicenseText;
            }
            else if (libName.Equals(Common.SqliteNetPcl))
            {
                LibCopyright.Value = this.SqliteNetPcl_LicenseText;
                LibLicense.Value = this.MITLicenseText;
            }
            else if (libName.Equals(Common.XamarinEssentialsInterfaces))
            {
                LibCopyright.Value = this.XamarinEssentialsInterfaces_LicenseText;
                LibLicense.Value = this.MITLicenseText;
            }
            else if (libName.Equals(Common.XamarinForms))
            {
                LibCopyright.Value = this.XamarinForms_LicenseText;
                LibLicense.Value = this.MITLicenseText;
            }
            else if (libName.Equals(Common.XamarinFormsPancakeView))
            {
                LibCopyright.Value = this.XamarinFormsPancakeView_LicenseText;
                LibLicense.Value = this.MITLicenseText;
            }
        }

        /// <summary>
        /// MITライセンス
        /// </summary>
        public string MITLicenseText { get; } = @"
The MIT License (MIT)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the ""Software""), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.


--------------------------------";

        public string NETStandardLibrary_LicenseText { get; } = @"
■[NETStandard.Library]
The MIT License (MIT)
Copyright (c) .NET Foundation and Contributors
All rights reserved.


--------------------------------";

        public string PrismUnityForms_LicenseText { get; } = @"
■[Prism.Unity.Forms]
The MIT License (MIT)
Copyright (c) .NET Foundation


--------------------------------";

        public string ReactiveProperty_LicenseText { get; } = @"
■[ReactiveProperty]
The MIT License (MIT)
Copyright (c) 2018 neuecc, xin9le, okazuki


--------------------------------";

        public string SqliteNetPcl_LicenseText { get; } = @"
■[sqlite-net-pcl]
The MIT License (MIT)
Copyright (c) Krueger Systems, Inc.


--------------------------------";

        public string XamarinEssentialsInterfaces_LicenseText { get; } = @"
■[Xamarin.Essentials.Interfaces]
The MIT License (MIT)
Copyright (c) 2018 Ryan Davis


--------------------------------";

        public string XamarinForms_LicenseText { get; } = @"
■[Xamarin.Forms]
The MIT License (MIT)
Copyright (c) .NET Foundation Contributors
All rights reserved.


--------------------------------";

        public string XamarinFormsPancakeView_LicenseText { get; } = @"
■[Xamarin.Forms.PancakeView]
The MIT License (MIT)
Copyright (c) 2019 Steven Thewissen


--------------------------------";

    }
}
