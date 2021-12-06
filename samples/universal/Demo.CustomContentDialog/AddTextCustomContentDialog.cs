using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace Demo.CustomContentDialog
{
    public class AddTextCustomContentDialog : IContentDialog
    {
        private readonly AddTextContentDialog dialog;

        public AddTextCustomContentDialog()
        {
            dialog = new AddTextContentDialog();
        }

        object IContentDialog.DataContext
        {
            get => dialog.DataContext;
            set => dialog.DataContext = value;
        }

        IAsyncOperation<ContentDialogResult> IContentDialog.ShowAsync()
        {
            return dialog.ShowAsync();
        }
    }
}
