using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionistPortal.Content.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Send([FromBody] Models.Message message)
        {
            var sessionInfo = JsonConvert.SerializeObject(Request.Headers);
            //Data.Portal.SaveMessage(sessionInfo, message.name, message.email, message.phone, message.message);
            EmailHelper.Send(message.name, message.email, message.phone, message.message);
            return Ok();
        }
    }
}
