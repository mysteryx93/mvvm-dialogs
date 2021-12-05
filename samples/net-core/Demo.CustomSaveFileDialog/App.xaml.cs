﻿using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using MvvmDialogs.Core;
using MvvmDialogs.Wpf;

namespace Demo.CustomSaveFileDialog
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
