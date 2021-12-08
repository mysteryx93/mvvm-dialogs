
namespace MvvmDialogs.Wpf.FrameworkDialogs.Api
{
    public class SaveFileApiSettings : FileApiSettings
    {
        public bool CreatePrompt { get; set; }
        public bool OverwritePrompt { get; set; }

        internal void ApplyTo(System.Windows.Forms.SaveFileDialog d)
        {
            base.ApplyTo(d);
            d.CreatePrompt = CreatePrompt;
            d.OverwritePrompt = OverwritePrompt;
        }

        internal void ResultsFrom(System.Windows.Forms.SaveFileDialog d) => FileName = d.FileName;
    }
}
