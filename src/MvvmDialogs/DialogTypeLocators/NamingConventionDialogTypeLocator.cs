using System;
using System.ComponentModel;
using System.Reflection;

namespace MvvmDialogs.DialogTypeLocators
{
    /// <summary>
    /// Dialog type locator responsible for locating dialog types for specified view models based
    /// on a naming convention used in a multitude of articles and code samples regarding the MVVM
    /// pattern.
    /// <para/>
    /// The convention states that if the name of the view model is
    /// 'MyNamespace.ViewModels.MyDialogViewModel' then the name of the dialog is
    /// 'MyNamespace.Views.MyDialog'.
    /// </summary>
    public class NamingConventionDialogTypeLocator : IDialogTypeLocator
    {
        /// <summary>
        /// Gets or sets the folder where View Models are stored. Default is 'ViewModels'.
        /// </summary>
        public string ViewModelFolder { get; set; } = "ViewModels";

        /// <summary>
        /// Gets or sets the suffix of View Model classes. Default is 'ViewModel'.
        /// </summary>
        public string ViewModelSuffix { get; set; } = "ViewModel";

        /// <summary>
        /// Gets or sets the folder where Views are stored. Default is 'Views'.
        /// </summary>
        public string ViewFolder { get; set; } = "Views";

        /// <summary>
        /// Gets or sets the suffix of View classes. Default is ''.
        /// </summary>
        public string ViewSuffix { get; set; } = "";
        /// <summary>
        /// Internal cache.
        /// </summary>
        public static readonly DialogTypeLocatorCache Cache = new DialogTypeLocatorCache();

        /// <inheritdoc />
        public Type Locate(INotifyPropertyChanged viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            var viewModelType = viewModel.GetType();
            var dialogType = Cache.Get(viewModelType);
            if (dialogType != null)
            {
                return dialogType;
            }

            string dialogName = GetDialogName(viewModelType) + ViewSuffix;

            dialogType = GetAssemblyFromType(viewModelType).GetType(dialogName);
            if (dialogType == null) throw new TypeLoadException(AppendInfoAboutDialogTypeLocators($"Dialog with name '{dialogName}' is missing."));

            Cache.Add(viewModelType, dialogType);

            return dialogType;
        }

        private string GetDialogName(Type viewModelType)
        {
            if (viewModelType.FullName != null)
            {
                string dialogName = viewModelType.FullName.Replace($".{ViewModelFolder}.", $".{ViewFolder}.");

                if (dialogName.EndsWith(ViewModelSuffix, StringComparison.Ordinal))
                {
                    return dialogName.Substring(
                        0,
                        dialogName.Length - ViewModelSuffix.Length);
                }
            }

            throw new TypeLoadException(
                AppendInfoAboutDialogTypeLocators($"View model of type '{viewModelType}' doesn't follow naming convention since it isn't suffixed with '{ViewModelSuffix}'."));
        }

        private static Assembly GetAssemblyFromType(Type type) => type.Assembly;

        private static string AppendInfoAboutDialogTypeLocators(string errorMessage) =>
            errorMessage + Environment.NewLine +
            "If your project structure doesn't conform to the default convention of MVVM " +
            "Dialogs you can always define a new convention by implementing your own dialog " +
            "type locator. For more information on how to do that, please read the GitHub " +
            "wiki or ask the author.";
    }
}
