
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTwo.Resources.adapter;
using TaskTwo.Resources.dataHelper;

namespace TaskTwo
{
    public class homefragment : Fragment
    {
        RecyclerView myRecyclerView;
        List<dataModel> mydataModel;
        myrecyclerAdapter myAdapter;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
         
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
             View view = inflater.Inflate(Resource.Layout.homefragment, container, false);

            myRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            addingData();
            myRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity)); 
            myAdapter = new myrecyclerAdapter(mydataModel, Activity);
            myRecyclerView.SetAdapter(myAdapter);
            return view;    
        }

        private void addingData()
        {
            mydataModel = new List<dataModel>
            {
                new dataModel{Name ="Jay" ,Price = "$100",Time = "Today",Image = Resource.Drawable.ic_bank },
                new dataModel{Name ="Manish" ,Price = "$100",Time = "Today",Image = Resource.Drawable.ic_Hotel },
                new dataModel{Name ="Sagar" ,Price = "$100",Time = "Today",Image = Resource.Drawable.ic_Dress},
                new dataModel{Name ="Devance" ,Price = "$100",Time = "Today",Image = Resource.Drawable.ic_gym},
                new dataModel{Name ="Hinal" ,Price = "$100",Time = "Today",Image = Resource.Drawable.ic_home },
                new dataModel{Name ="Mit" ,Price = "$100",Time = "Today",Image = Resource.Drawable.ic_bike },
                new dataModel{Name ="Priyank" ,Price = "$100",Time = "Today",Image = Resource.Drawable.ic_bank }
            };
        }
    }
}