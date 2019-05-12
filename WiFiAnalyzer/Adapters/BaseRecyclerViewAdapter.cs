using System.Collections.Generic;
using Android.Support.V7.Widget;

namespace WiFiAnalyzer.Adapters
{
    public abstract class BaseRecyclerViewAdapter<T> : RecyclerView.Adapter where T : class
    {
        protected readonly List<T> Items;

        protected BaseRecyclerViewAdapter(List<T> items)
        {
            Items = items;
        }

        public override int ItemCount => Items.Count;
    }
}