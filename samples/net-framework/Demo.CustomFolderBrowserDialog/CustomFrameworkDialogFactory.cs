﻿using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.Wpf.FrameworkDialogs;

namespace Demo.CustomFolderBrowserDialog
{
    public class CustomFrameworkDialogFactory : FrameworkDialogFactory
    {
        public override IFrameworkDialog Create<T>(T settings) =>
            settings switch
            {
                FolderBrowserDialogSettings s => new CustomFolderBrowserDialog(s),
                _ => base.Create(settings)
            };
    }
}
