using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace WiFiAnalyzer.ViewHolders
{
    public class SsidViewHolder : RecyclerView.ViewHolder
    {
        public SsidViewHolder(View itemView) : base(itemView)
        {
            Name = itemView.FindViewById<TextView>(Resource.Id.WifiItemTextView);
            Channel = itemView.FindViewById<TextView>(Resource.Id.channelTextView);
            Frequency = itemView.FindViewById<TextView>(Resource.Id.frequencyTextView);
            SignalStrength = itemView.FindViewById<TextView>(Resource.Id.signalTextView);
        }

        public TextView Name { get; }
        public TextView Channel { get; }

        public TextView Frequency { get; }

        public TextView SignalStrength { get; }
    }
}