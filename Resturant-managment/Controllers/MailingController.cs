
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;
using Resturant_managment.Models;
using Resturant_managment.Models.Interfaces;
namespace Resturant_managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailingController : ControllerBase
    {
        // GET: api/Mailing
        private readonly string key = "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";
        private MailSetting _mailSettings;
        private IMailService mailService;

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Mailing/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        public MailingController(IMailService mailService)
        {
            this.mailService = mailService;
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
        //[HttpGet("SendTest")]
        //public async Task<ActionResult> SendTest(string To= "mohamadnematpoor@outlook.com")
        //{
        //    var apiKey =key;
        //    var client = new SendGridClient(apiKey);
        //    var from = new EmailAddress("mohamadnematpoor@gmail.com", "Example User");
        //    var subject = "Sending with SendGrid is Fun";
        //    var to = new EmailAddress(To, "Example User");
        //    var plainTextContent = "and easy to do anywhere, even with C#";
        //    var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        //    var response = await client.SendEmailAsync(msg);
            
        //    return Ok();
        //}
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
