using Kashmir.Exceptions.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kashmir.Exceptions
{
    public class ProjectException : IException
    {

        public async Task ServerExceptions(HttpResponseMessage httpResponse)
        {
            BadRequestException badRequestException = JsonConvert.DeserializeObject<BadRequestException>(await httpResponse.Content.ReadAsStringAsync()) as BadRequestException;
            if (badRequestException is BadRequestException)
            {
                await this.BabRequestException(badRequestException);
            } 
            else
            {
                await Helpers.Helpers.DisplayActionSheetAsync("Error", string.Format("Error code: {0}", (int)httpResponse.StatusCode), "Ok");
            }
        }

        public async Task BabRequestException(BadRequestException badRequestException)
        {
            for (int i = 0; i < badRequestException.errors.Length; i++)
            {
                Debug.Write(string.Format("{0}", badRequestException.errors[i]), "BadRequestException");
                await Helpers.Helpers.DisplayAleryAsync("Error", badRequestException.errors[i], "Ok");
            }
        }

        

        public async Task ValidationException(ValidationException validationException)
        {
            //for (int i = 0; i < validationException.errors.Length; i++)
            //{
                //Debug.Write(string.Format("{0}", badRequestException.errors[i]), "BadRequestException");
                await Helpers.Helpers.DisplayAleryAsync("Error", validationException.ToString(), "Ok");
            //}
        }
        
    }
}
