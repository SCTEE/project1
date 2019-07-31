using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.Design.Widget;
using Android.Support.V7.App;

namespace FunMath
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class Game1 : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Game1);
            game();
            Button nextgame = FindViewById<Button>(Resource.Id.nextgame);
            TextView message = FindViewById<TextView>(Resource.Id.message);
            nextgame.Click += delegate 
            {
                nextgame.Visibility = ViewStates.Invisible;
                message.Text = "";
                game();

            };

            Button btn = FindViewById<Button>(Resource.Id.button5);
            btn.Click += delegate { StartActivity(typeof(SecondActivity)); };
            // Create your application here
        }

        public void game()
        {
            Random question1 = new Random();
            Random question2 = new Random();
            Random number1 = new Random();
            Random number2 = new Random();
            Random number3 = new Random();
            Random randomans = new Random();
            int ques1 = question1.Next(1, 10);
            int ques2 = question2.Next(1, 10);
            int no;
            int rndans = randomans.Next(1, 4);
            int ans = ques1 + ques2;

            String question = ques1.ToString() + " + " + ques2.ToString();

            TextView questiontext = FindViewById<TextView>(Resource.Id.Question1);
            questiontext.Text = question;

            Button ans1 = FindViewById<Button>(Resource.Id.answer1);
            Button ans2 = FindViewById<Button>(Resource.Id.answer2);
            Button ans3 = FindViewById<Button>(Resource.Id.answer3);
            Button ans4 = FindViewById<Button>(Resource.Id.answer4);

            if(rndans == 1)
            {
                ans1.Text = ans.ToString();
            }
            if (rndans == 2)
            {
                ans2.Text = ans.ToString();
            }
            if (rndans == 3)
            {
                ans3.Text = ans.ToString();
            }
            if (rndans == 4)
            {
                ans4.Text = ans.ToString();
            }

            for (int a = 1; a <= 4; a++)
            {
                if (a != rndans)
                {
                    do
                    {
                        no = number1.Next(1, 20);
                    } while (ans == no);
                    if(a == 1)
                    {
                        ans1.Text = no.ToString();
                    }
                    if (a == 2)
                    {
                        ans2.Text = no.ToString();
                    }
                    if (a == 3)
                    {
                        ans3.Text = no.ToString();
                    }
                    if (a == 4)
                    {
                        ans4.Text = no.ToString();
                    }
                }
            }

            ans1.Click += delegate { checkans(ans1, ans); };
            ans2.Click += delegate { checkans(ans2, ans); };
            ans3.Click += delegate { checkans(ans3, ans); };
            ans4.Click += delegate { checkans(ans4, ans); };
        }

        public void checkans(Button btn, int ans)
        {
            TextView message = FindViewById<TextView>(Resource.Id.message);
            if (btn.Text == ans.ToString())
            {
                message.Text = "Congratulation!";
                Button nextgame = FindViewById<Button>(Resource.Id.nextgame);
                nextgame.Visibility = ViewStates.Visible;
                
            }
            else
            {
                message.Text = "You guess the wrong answer.";
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
    }
}