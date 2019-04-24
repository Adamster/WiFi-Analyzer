using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace WiFiAnalyzer
{
    public class SSIDViewHolder : RecyclerView.ViewHolder
    {
        public TextView Name { get; private set; }
        public TextView Channel { get; private set; }

        public TextView Frequency { get; private set; }

        public TextView SignalStrenght { get; private set; }



        public SSIDViewHolder(View itemView) : base(itemView)
        {
            Name = itemView.FindViewById<TextView>(Resource.Id.WifiItemTextView);
            Channel = itemView.FindViewById<TextView>(Resource.Id.channelTextView);
            Frequency = itemView.FindViewById<TextView>(Resource.Id.frequencyTextView);
            SignalStrenght = itemView.FindViewById<TextView>(Resource.Id.signalTextView);
        }
    }
}