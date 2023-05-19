using Android.Content;
using Android.Util;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppWearOsPicking.Messages;

namespace MauiAppWearOsPicking.Platforms.Android.Utilities
{
    [BroadcastReceiver]
    public class ScanReceiver : BroadcastReceiver
    {

        static readonly string TAG = "X:" + typeof(ScanReceiver).Name;

        // This intent string contains the source of the data as a string  
        private static readonly string SOURCE_TAG = "com.motorolasolutions.emdk.datawedge.source";
        // This intent string contains the barcode symbology as a string  
        private static readonly string LABEL_TYPE_TAG = "com.motorolasolutions.emdk.datawedge.label_type";
        // This intent string contains the captured data as a string  
        // (in the case of MSR this data string contains a concatenation of the track data)  
        private static string DATA_STRING_TAG = "com.motorolasolutions.emdk.datawedge.data_string";
        // Intent Action for our operation
        public const string ACTION_SCANNER_STATE_INTENT = "com.proglove.api.SCANNER_STATE";
        public const string ACTION_BARCODE_INTENT = "com.proglove.api.BARCODE";
        public const string ACTION_BARCODE_VIA_START_ACTIVITY_INTENT = "com.proglove.api.BARCODE_START_ACTIVITY";
        public const string EXTRA_SCANNER_STATE = "com.proglove.api.extra.SCANNER_STATE";
        public const string EXTRA_DATA_STRING = "com.symbol.datawedge.data_string";
        public const string EXTRA_SYMBOLOGY_STRING = "com.symbol.datawedge.label_type";

        public override void OnReceive(Context context, Intent i)
        {
            if(i != null)
            {
                string action = i.Action;
                if (action != null)
                {
                    switch (action)
                    {
                        case ACTION_BARCODE_INTENT:
                        case ACTION_BARCODE_VIA_START_ACTIVITY_INTENT:
                            HandleScannedBarcode(i);
                            break;
                        case ACTION_SCANNER_STATE_INTENT:
                            string scannerStateString = i.GetStringExtra(EXTRA_SCANNER_STATE);
                            break;
                        default: break;
                    }
                }
                else if (i.HasExtra(EXTRA_DATA_STRING) ||
                    i.HasExtra(EXTRA_SYMBOLOGY_STRING))
                    HandleScannedBarcode(i);
            }
           

        }

        private void HandleScannedBarcode(Intent i)
        {
            string barcodeContentString = i.GetStringExtra(EXTRA_DATA_STRING);
            string symbologyString = i.GetStringExtra(EXTRA_SYMBOLOGY_STRING);

            System.Diagnostics.Debug.WriteLine("HandleScannedBarcode barcodeContentString = " + barcodeContentString, "ScanReceiver");
            WeakReferenceMessenger.Default.Send(new ScannerMessage(barcodeContentString));
        }
      
    }
}
