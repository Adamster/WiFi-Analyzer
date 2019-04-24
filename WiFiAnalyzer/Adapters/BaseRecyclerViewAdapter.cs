using Android.Support.V7.Widget;
using Android.Views;
using System.Collections.Generic;
using WiFiAnalyzer.Core;

namespace WiFiAnalyzer
{
    public abstract class BaseRecyclerViewAdapter<T> : RecyclerView.Adapter where T : class
    {
        protected readonly List<T> Items;

        public BaseRecyclerViewAdapter(List<T> items)
        {
            Items = items;
        }

        public override int ItemCount => Items.Count;
    }
}