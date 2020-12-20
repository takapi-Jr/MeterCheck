using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;

namespace MeterCheck.ViewModels
{
    public class AddMachinePageViewModel : ViewModelBase, IDisposable
    {
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();

        public AddMachinePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Add Machine Page";
        }

        public void Dispose()
        {
            this.Disposable.Dispose();
        }
    }
}
