using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATPEmailNotifications
{
    [Route("api/NewNotif")]
    [ApiController]
    public class CreateNotificationController : ControllerBase
    {
        private readonly IConfiguration config;

        public CreateNotificationController(IConfiguration config)
        {
            this.config = config;
        }

        [HttpPost]
        public string Post([FromForm] string recipientName, [FromForm] string recipientEmail, [FromForm] string initiatorName, [FromForm] string initiatorEmail, [FromForm] string message)
        {
            System.Console.WriteLine($"the list of params in controller: {recipientName}, {recipientEmail}, {initiatorName}, {initiatorEmail}, {message}");
            var notification = new EmailNotification(config);
            var msg = notification.NewEmail(recipientName, recipientEmail, initiatorName, initiatorEmail, message);
            string othermsg = "testing";
            return othermsg;
        }
    }
}
