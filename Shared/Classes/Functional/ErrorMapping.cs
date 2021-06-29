using System.Net.Http;
using System.Collections.Generic;
using System.Net;

namespace TrouvailleFrontend.Shared.Classes.Functional {
    public class ErrorMapping {
        public static Dictionary<HttpStatusCode, string> ErrorsMapped = new Dictionary<HttpStatusCode, string>(){
            {HttpStatusCode.Unauthorized, "401, The Password and or Login is incorrect"},
            {HttpStatusCode.BadRequest, "400, The request couldn't be understood by the server"},
            {HttpStatusCode.ServiceUnavailable, "503, The server is unavailable, please contact the administration"},
            //this one will only be shown when the standart Object is used!
            {HttpStatusCode.OK, "200, Somebody forgot to set The Error String"},
            {HttpStatusCode.NotFound, "404, oooff"},
            {HttpStatusCode.Forbidden, "403: Oops, You cannot do that"},
            {HttpStatusCode.Conflict, "409"}
        };
    }
}