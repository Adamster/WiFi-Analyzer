using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using WiFiAnalyzer.Core;

namespace WiFiAnalyzer.Adapters
{
    public class SSIDAdapter : BaseRecyclerViewAdapter<SSIDModel>
    {
        public SSIDAdapter(List<SSIDModel> wifiItems) : base(wifiItems)
        {
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.wifi_item_view, parent, false);

            SSIDViewHolder vh = new SSIDViewHolder(itemView);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = holder as SSIDViewHolder;
            var item = Items[position];

            vh.Name.Text = item.Name;
            vh.Channel.Text = item.Channel.ToString();
            vh.Frequency.Text = item.Frequency.ToString();
            vh.SignalStrenght.Text = item.SignalStrenght.ToString();
        }
    }


}