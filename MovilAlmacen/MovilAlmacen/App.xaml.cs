﻿namespace MovilAlmacen;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        // Tamaño personalizado para ventanas desktop
        if (DeviceInfo.Platform != DevicePlatform.Android && DeviceInfo.Platform != DevicePlatform.iOS)
        {
            window.Width = 400;
            window.Height = 800;
        }

        return window;
    }
}