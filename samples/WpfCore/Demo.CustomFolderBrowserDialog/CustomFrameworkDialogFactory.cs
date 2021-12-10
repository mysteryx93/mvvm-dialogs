﻿using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf;
using MvvmDialogs.Wpf.FrameworkDialogs;

namespace Demo.CustomFolderBrowserDialog
{
    public class CustomFrameworkDialogFactory : FrameworkDialogFactory
    {
        public override IFrameworkDialog<TResult> Create<TSettings, TResult>(TSettings settings, AppDialogSettingsBase appSettings)
        {
            var s2 = (AppDialogSettings)appSettings;
            return settings switch
            {
                OpenFolderDialogSettings s => (IFrameworkDialog<TResult>)new CustomOpenFolderDialog(s, s2),
                _ => base.Create<TSettings, TResult>(settings, appSettings)
            };
        }
    }
}
