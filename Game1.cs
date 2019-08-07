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
        int ans, point;
        String question, strans1, strans2, strans3, strans4, msg;
        bool vis = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Game1);
            Button nextgame = FindViewById<Button>(Resource.Id.nextgame);
            TextView message = FindViewById<TextView>(Resource.Id.message);
            TextView pointtext = FindViewById<TextView>(Resource.Id.point1);
            String pointtxt = "You get " + point.ToString() + " points.";
            if (savedInstanceState != null)
            {
                ans = savedInstanceState.GetInt("ans", 0);
                point = savedInstanceState.GetInt("point", 0);
                question = savedInstanceState.GetString("question");
                strans1 = savedInstanceState.GetString("strans1");
                strans2 = savedInstanceState.GetString("strans2");
                strans3 = savedInstanceState.GetString("strans3");
                strans4 = savedInstanceState.GetString("strans4");
                msg = savedInstanceState.GetString("msg");
                vis = savedInstanceState.GetBoolean("vis", false);
                TextView questiontext = FindViewById<TextView>(Resource.Id.Question1);
                questiontext.Text = question;
                pointtxt = "You get " + point.ToString() + " points.";
                pointtext.Text = pointtxt;
                message.Text = msg;
                Button ans1 = FindViewById<Button>(Resource.Id.answer1);
                Button ans2 = FindViewById<Button>(Resource.Id.answer2);
                Button ans3 = FindViewById<Button>(Resource.Id.answer3);
                Button ans4 = FindViewById<Button>(Resource.Id.answer4);
                ans1.Text = strans1.ToString();
                ans2.Text = strans2.ToString();
                ans3.Text = strans3.ToString();
                ans4.Text = strans4.ToString();

                if (vis == true)
                {
                    nextgame.Visibility = ViewStates.Visible;
                }

                ans1.Click += delegate { checkans(ans1, ans); };
                ans2.Click += delegate { checkans(ans2, ans); };
                ans3.Click += delegate { checkans(ans3, ans); };
                ans4.Click += delegate { checkans(ans4, ans); };
            }
            else
            {
                game();
            }



            nextgame.Click += delegate 
            {
                nextgame.Visibility = ViewStates.Invisible;
                message.Text = "";
                vis = false;
                msg = "";
                point = point + 1;
                game();

            };

            Button btn = FindViewById<Button>(Resource.Id.button5);
            btn.Click += delegate { StartActivity(typeof(SecondActivity)); };
            // Create your application here
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("ans", ans);
            outState.PutInt("point", point);
            outState.PutString("question", question);
            outState.PutString("strans1", strans1);
            outState.PutString("strans2", strans2);
            outState.PutString("strans3", strans3);
            outState.PutString("strans4", strans4);
            outState.PutString("msg", msg);
            outState.PutBoolean("vis", vis);
            base.OnSaveInstanceState(outState);
        }

        public void game()
        {
            Random question1 = new Random();
            Random question2 = new Random();
            Random number1 = new Random();
            Random number2 = new Random();
            Random number3 = new Random();
            Random randomans = new Random();
            TextView pointtext = FindViewById<TextView>(Resource.Id.point1);
            String pointtxt = "You get " + point.ToString() + " points.";
            pointtext.Text = pointtxt;
            int ques1 = question1.Next(1, 10);
            int ques2;
            do
            {
                ques2 = question2.Next(1, 10);
            } while (ques1 == ques2);
            
            int no;
            int rndans = randomans.Next(1, 5);
            ans = ques1 + ques2;

            question = ques1.ToString() + " + " + ques2.ToString();

            TextView questiontext = FindViewById<TextView>(Resource.Id.Question1);
            questiontext.Text = question;

            Button ans1 = FindViewById<Button>(Resource.Id.answer1);
            Button ans2 = FindViewById<Button>(Resource.Id.answer2);
            Button ans3 = FindViewById<Button>(Resource.Id.answer3);
            Button ans4 = FindViewById<Button>(Resource.Id.answer4);

            if(rndans == 1)
            {
                ans1.Text = ans.ToString();
                strans1 = ans.ToString();
            }
            if (rndans == 2)
            {
                ans2.Text = ans.ToString();
                strans2 = ans.ToString();
            }
            if (rndans == 3)
            {
                ans3.Text = ans.ToString();
                strans3 = ans.ToString();
            }
            if (rndans == 4)
            {
                ans4.Text = ans.ToString();
                strans4 = ans.ToString();
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
                        strans1 = no.ToString();
                    }
                    if (a == 2)
                    {
                        ans2.Text = no.ToString();
                        strans2 = no.ToString();
                    }
                    if (a == 3)
                    {
                        ans3.Text = no.ToString();
                        strans3 = no.ToString();
                    }
                    if (a == 4)
                    {
                        ans4.Text = no.ToString();
                        strans4 = no.ToString();
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
                msg = "Congratulation!";
                Button nextgame = FindViewById<Button>(Resource.Id.nextgame);
                nextgame.Visibility = ViewStates.Visible;
                vis = true;
            }
            else
            {
                message.Text = "You guess the wrong answer.";
                msg = "You guess the wrong answer.";
                Button nextgame = FindViewById<Button>(Resource.Id.nextgame);
                nextgame.Visibility = ViewStates.Invisible;
                vis = false;
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