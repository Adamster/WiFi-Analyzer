using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using WiFiAnalyzer.Core.Models;
using WiFiAnalyzer.ViewHolders;

namespace WiFiAnalyzer.Adapters
{
    public class SsidAdapter : BaseRecyclerViewAdapter<SsidModel>
    {
        public SsidAdapter(List<SsidModel> wifiItems) : base(wifiItems)
        {
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.wifi_item_view, parent, false);

            var vh = new SsidViewHolder(itemView);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = holder as SsidViewHolder;
            if (vh == null)
                throw new ArgumentNullException(nameof(vh));

            var item = Items[position];

            vh.Name.Text = item.Name;
            vh.Channel.Text = item.Channel.ToString();
            vh.Frequency.Text = item.Frequency.ToString();
            vh.SignalStrength.Text = item.SignalStrength.ToString();
        }
    }
}