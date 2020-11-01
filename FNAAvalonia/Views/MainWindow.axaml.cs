﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using ExampleFNA;
using Avalonia.Threading;

namespace FNAAvalonia.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void LoadGame()
        {
            using (GameBase game = new GameBase())
                game.Run();
        }


        public void Window_Loaded(object sender, EventArgs e)
        {
            Dispatcher.UIThread.Post(LoadGame);
        }

        public void Window_Closed(object sender, EventArgs e)
        {
        }
    }
}
