using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using MauiAppWearOsPicking.Platforms.Android.Utilities;

namespace MauiAppWearOsPicking;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    ScanReceiver _scanReceiver;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        System.Diagnostics.Debug.WriteLine("OnCreate", "MainActivity");

        _scanReceiver = new ScanReceiver();
    }

    protected override void OnResume()
    {
        base.OnResume();

        // Register the broadcast receiver
        IntentFilter filterScan = new IntentFilter();
        filterScan.AddAction(ScanReceiver.ACTION_BARCODE_INTENT);
        filterScan.AddAction(ScanReceiver.ACTION_SCANNER_STATE_INTENT);
        filterScan.AddCategory(Intent.CategoryDefault);
        RegisterReceiver(_scanReceiver, filterScan);
    }

    protected override void OnPause()
    {
        base.OnPause();
        UnregisterReceiver(_scanReceiver);
    }
}
