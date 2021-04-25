using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Kashmir.Interfaces
{
    public interface IToastMessage
    {
        void ShortMessage(string message);
        void LongMessage(string message);
    }
}
