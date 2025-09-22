﻿namespace M.A.G.U.S.Assistant
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            UserAppTheme = AppTheme.Dark;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}