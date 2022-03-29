using Microsoft.AspNetCore.Mvc;

namespace LinkedInHomeMade.Models
{
    public static class AjaxErrorResponse
    {
        public static JsonResult ErrorJsonResult(string message, string consoleLog)
        {
           return new JsonResult(new { message = message, log = consoleLog, error = "true" });
        }
    }

}
