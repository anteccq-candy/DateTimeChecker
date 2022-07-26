﻿using System.Windows;
using DateTimeChecker.ViewModels;

namespace DateTimeChecker.Views.Windows;

/// <summary>
/// MainWindow.xaml の相互作用ロジック
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        this.DataContext = viewModel;
    }
}