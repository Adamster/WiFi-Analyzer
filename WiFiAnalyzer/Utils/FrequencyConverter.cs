namespace WiFiAnalyzer.Utils
{
    public static class FrequencyConverter
    {
        public static int FrequencyToChannel(this int freq)
        {
            if (freq == 2484)
                return 14;

            if (freq < 2484)
                return (freq - 2407) / 5;

            return freq / 5 - 1000;
        }
    }
}