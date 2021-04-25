using Kashmir.Exceptions;
using Kashmir.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kashmir.Helpers
{
    public class Helpers
    {

        private static ProjectException ProjectException = new ProjectException();

        public static void ShowToastLongMessage(string message)
        {
            ToastMessage.ToastLongMessage(message);
        }

        public static void ShowToastShortMessage(string message)
        {
            ToastMessage.ToastShortMessage(message);
        }

        public async static Task DisplayAleryAsync(string title, string message, string cancel)
        {
            await App.Current.MainPage.DisplayAlert(title: title, message: message, cancel: cancel);
        }

        public async static Task<bool> DisplayAleryAsync(string title, string message, string accept, string cancel)
        {
            return await App.Current.MainPage.DisplayAlert(title: title, message: message, accept: accept, cancel: cancel);
        }

        public async static Task<string> DisplayActionSheetAsync(string title, string cancel, string destruction, params string[] buttons)
        {
            return await App.Current.MainPage.DisplayActionSheet(title: title, cancel: cancel, destruction: destruction, buttons: buttons);
        }

        public async static Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "cancel", string placeholder = null, int maxLength = -1, Xamarin.Forms.Keyboard keyboard = null)
        {
            //return await App.Current.MainPage.DisplayPromptAsync("Title", "Message", accept, cancel, placeholder, maxLength, keyboard);
            ShowToastLongMessage(message);
            return message;
        }

        public async static Task ServerExceptions(HttpResponseMessage httpResponse)
        {
            await ProjectException.ServerExceptions(httpResponse);
        }

    }
}
