using CommunityToolkit.Mvvm.ComponentModel;
using MvvmDialogs;

namespace Demo.CustomDialogTypeLocator.ComponentA
{
    public class MyDialogVM : ObservableObject
    {
        private bool? dialogResult;

        public bool? DialogResult
        {
            get => dialogResult;
            private set => SetProperty(ref dialogResult, value);
        }
    }
}
