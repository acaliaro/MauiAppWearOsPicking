using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppWearOsPicking.Messages
{
    public class ScannerMessage : ValueChangedMessage<string>
    {
        public ScannerMessage(string barcode) : base(barcode)
        {
        }
    }
}
