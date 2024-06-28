using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Mail;

using IMailService = My_Transfers.Interfaces.IMailService;


namespace My_Transfers.Class;



public class SMTPMailService : IMailService
{

	private readonly MailConfiguration _config;
	private readonly ILogger<SMTPMailService> _logger;

	public SMTPMailService(IConfiguration config, ILogger<SMTPMailService> logger)
	{
		_logger = logger;
		_config = config.GetSection("MailConfiguration").Get<MailConfiguration>();

	}

	public async Task SendAsync(MailRequest request)
	{



		try
		{
			MailMessage message = new()
			{
				From = new MailAddress(_config.From),
				Subject = request.Subject,
				Body = $"<html><body style=\"font-size: 12px; font-family: Arial; color: black;\">{request.Body}</body></html>",
				IsBodyHtml = true,

			};
			message.To.Add(request.To);


			if (File.Exists(request.attachmentPath))
			{
				var attachment = new Attachment(request.attachmentPath);
				message.Attachments.Add(attachment);
			}

			var smtpClient = new System.Net.Mail.SmtpClient(_config.Host)
			{
				Port = _config.Port,
				Credentials = new NetworkCredential(_config.From, _config.Password),
				EnableSsl = true,

			};

			await smtpClient.SendMailAsync(message);
			message.Dispose();
			smtpClient.Dispose();
			//return new UserManagerResponse
			//{
			//	Message = "Email Send Successfully!",
			//	IsSuccess = true,
			//};
		}
		catch (Exception ex)
		{
			//return new UserManagerResponse
			//{
			//	IsSuccess = false,
			//	Message = ex.Message
			//};
		}
		finally
		{

		}
	}

}
