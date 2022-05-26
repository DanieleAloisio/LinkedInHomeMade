using Microsoft.AspNetCore.Mvc;

namespace LinkedInHomeMade.Models
{
    public static class AjaxResponse
    {
        public static JsonResult ErrorJsonResult(string message)
        {
            return new JsonResult(new { message = message, error = "true" });
        }

        public static JsonResult DoneJsonResult(string message)
        {
            return new JsonResult(new { message = message,  error = "false" });
        }
    }
}
