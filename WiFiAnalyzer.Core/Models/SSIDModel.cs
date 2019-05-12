namespace WiFiAnalyzer.Core.Models
{
    public class SsidModel
    {
        public string Name { get; set; }

        public int Channel { get; set; }

        public int Frequency { get; set; }
        public int SignalStrength { get; set; }
    }
}