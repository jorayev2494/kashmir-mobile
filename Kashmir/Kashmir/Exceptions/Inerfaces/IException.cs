using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kashmir.Exceptions.Interfaces
{
    public interface IException
    {
        Task ServerExceptions(HttpResponseMessage httpResponse);
        Task BabRequestException(BadRequestException babRequestException);
        Task ValidationException(ValidationException validationException);
    }
}
