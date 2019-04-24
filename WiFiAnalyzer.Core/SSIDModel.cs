using System;

namespace WiFiAnalyzer.Core
{
    public class SSIDModel
    {
        public string Name { get; set; }

        public int Channel { get; set; }

        public int Frequency { get; set; }
        public int SignalStrenght { get; set; }
    }
}
