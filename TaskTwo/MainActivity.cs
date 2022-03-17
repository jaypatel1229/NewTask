using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.App;
using Google.Android.Material.BottomNavigation;
using static Google.Android.Material.BottomNavigation.BottomNavigationView;

namespace TaskTwo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnNavigationItemSelectedListener
    {
        BottomNavigationView bottomNavigationView;
        homefragment home;
        likefragment like;
        locationfragment location;
        profilefragment profilefragment;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.frameLayoutFile);

            bottomNavigationView = FindViewById<BottomNavigationView>(Resource.Id.bottomUserid);
            bottomNavigationView.SetOnNavigationItemSelectedListener(this);

            home = new homefragment();
            like = new likefragment();
            location = new locationfragment();
            profilefragment = new profilefragment();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public bool OnNavigationItemSelected(IMenuItem menuItem)
        {
            switch (menuItem.ItemId)
            {
                case Resource.Id.home_menu:
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, home).Commit();

                    return true;

                case Resource.Id.heart_menu:
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, like).Commit();
                    return true;

                case Resource.Id.location_menu:
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, location).Commit();
                    return true;

                case Resource.Id.person_menu:
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, profilefragment).Commit();
                    return true;
            }
            return false;
        }
    }
}
