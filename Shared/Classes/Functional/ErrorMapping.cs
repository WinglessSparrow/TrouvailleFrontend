using System.Net.Http;
using System.Collections.Generic;
using System.Net;

namespace TrouvailleFrontend.Shared.Classes.Functional {
    public class ErrorMapping {
        public static Dictionary<HttpStatusCode, string> ErrorsMapped = new Dictionary<HttpStatusCode, string>(){
            {HttpStatusCode.Unauthorized, "You are not authorized for this Action"},
            {HttpStatusCode.BadRequest, "The request couldn't be understood by the server"},
            {HttpStatusCode.ServiceUnavailable, "The server is unavailable, please contact the administration"},
            //this one will only be shown when the standart Object is used!
            {HttpStatusCode.OK, "Somebody forgot to set The Error String"}
        };
    }
}