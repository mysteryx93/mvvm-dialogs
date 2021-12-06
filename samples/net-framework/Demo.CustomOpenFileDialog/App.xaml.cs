﻿using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using MvvmDialogs.Core;

namespace Demo.CustomOpenFileDialog
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SimpleIoc.Default.Register<IDialogService>(
                () => new WpfDialogService(frameworkDialogFactory: new CustomFrameworkDialogFactory()));
        }
    }
}
