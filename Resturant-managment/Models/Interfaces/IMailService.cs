using System;
namespace Resturant_managment.Models.Interfaces
{
	public interface IMailService
	{
		Task SendEmailAsync(MailRequest mailRequest);
	}
}

