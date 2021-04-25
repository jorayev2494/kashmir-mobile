﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Kashmir.Droid.Dependencies;
using Kashmir.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(ToastMesage))]
namespace Kashmir.Droid.Dependencies
{
    public sealed class ToastMesage : IToastMessage
    {
        public void LongMessage(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortMessage(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }
}