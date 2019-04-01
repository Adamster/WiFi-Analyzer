using System;
using System.Collections.Generic;
using System.Text;

namespace WifiAnalyzer.Core.Models
{
   public class NetworkInfoModel
    {
        public string SSID { get; set; }

        public int Channel { get; set; }

        public bool IsProtected { get; set; }

        public int Frequency { get; set; }
    }
}
