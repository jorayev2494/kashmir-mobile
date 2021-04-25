using Kashmir.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kashmir.Services
{
    public sealed class ToastMessage
    {
        private static IToastMessage toastMessage = DependencyService.Get<IToastMessage>();

        public static void ToastLongMessage(string message)
        {
            toastMessage.LongMessage(message);
        }

        public static void ToastShortMessage(string message)
        {
            toastMessage.ShortMessage(message);
        }
    }
}
