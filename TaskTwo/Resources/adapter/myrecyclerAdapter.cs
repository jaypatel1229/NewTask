
using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using TaskTwo.Resources.dataHelper;


namespace TaskTwo.Resources.adapter
{
    public class myrecyclerAdapter : RecyclerView.Adapter
    {
        public event EventHandler<myrecyclerAdapterClickEventArgs> ItemClick;
        public event EventHandler<myrecyclerAdapterClickEventArgs> ItemLongClick;
        List<dataModel> list;
        Context context;

        public myrecyclerAdapter(List<dataModel> data,Context context)
        {
            list = data;
            this.context = context; 
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = null;
            var id = Resource.Layout.myRecyclerOne;
            itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            var vh = new myrecyclerAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = list[position];
            
            // Replace the contents of the view with that element
            var holder = viewHolder as myrecyclerAdapterViewHolder;
            //holder.TextView.Text = items[position];
            holder.textViewOne.Text = item.Name;
            holder.textViewTwo.Text = item.Price;
            holder.textViewThree.Text = item.Time;
            holder.image.SetImageResource(item.Image);

        }

        public override int ItemCount => list.Count;

        void OnClick(myrecyclerAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(myrecyclerAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class myrecyclerAdapterViewHolder : RecyclerView.ViewHolder
    {
        //public TextView TextView { get; set; }
        public TextView textViewOne,textViewTwo,textViewThree;
        public ImageView image;

        public myrecyclerAdapterViewHolder(View itemView, Action<myrecyclerAdapterClickEventArgs> clickListener,
                            Action<myrecyclerAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            textViewOne = itemView.FindViewById<TextView>(Resource.Id.textViewName);
            textViewTwo = itemView.FindViewById<TextView>(Resource.Id.textViewPrice);
            textViewThree = itemView.FindViewById<TextView>(Resource.Id.textViewTime);

            image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            //TextView = v;
            itemView.Click += (sender, e) => clickListener(new myrecyclerAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new myrecyclerAdapterClickEventArgs { View = itemView, Position = AdapterPosition });

           
        }
    }

    public class myrecyclerAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}