using System;
using System.ComponentModel;
using MvvmDialogs.DialogTypeLocators;

namespace Demo.CustomDialogTypeLocator
{
    // This class is used as an example in the wiki. For more information see
    // https://github.com/FantasticFiasco/mvvm-dialogs/wiki/Custom-dialog-type-locators.
    public class MyCustomDialogTypeLocator : IDialogTypeLocator
    {
        public Type Locate(INotifyPropertyChanged viewModel)
        {
            var viewModelType = viewModel.GetType();
            var viewModelTypeName = viewModelType.FullName;

            // Get dialog type name by removing the 'VM' suffix
            var dialogTypeName = viewModelTypeName.Substring(
                0,
                viewModelTypeName.Length - "VM".Length);

            return viewModelType.Assembly.GetType(dialogTypeName);
        }
    }
}
