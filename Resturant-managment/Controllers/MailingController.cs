using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Utils;
using SendGrid;
using SendGrid.Helpers.Mail;
namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailingController : ControllerBase
    {
        // GET: api/Mailing
        private readonly string key = "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";
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Mailing/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mailing
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Mailing/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Mailing/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        public async Task<ActionResult> SendTest(string To)
        {
            var apiKey =key;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("mohamadnematpoor@outlook.com", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("mohamadnematpoor@outlook.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            
            return Ok();
        }
    }
}
