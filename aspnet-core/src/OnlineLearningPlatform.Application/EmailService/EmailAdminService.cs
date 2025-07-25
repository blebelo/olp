using Abp.Domain.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using DotNetEnv;

namespace OnlineLearningPlatform.EmailService;

public class EmailAdminService : DomainService
{
	public async Task SendEmail(string subject, string toEmail, string username, string message)
	{
		// Load .env file (only needs to be done once per app lifetime, but safe here for testing)
		Env.Load();
		var apiKey = Environment.GetEnvironmentVariable("Email_Admin_Api_Key");
		var senderEmail = Environment.GetEnvironmentVariable("EmailAdminUser");
		if (string.IsNullOrWhiteSpace(apiKey))
		{
			throw new InvalidOperationException("Email_Admin_Api_Key environment variable is not set or empty.");
		}
		if (string.IsNullOrWhiteSpace(senderEmail))
		{
			throw new InvalidOperationException("EmailAdminUser environment variable is not set or empty.");
		}
		var client = new SendGridClient(apiKey);
		var from = new EmailAddress("nathanielmvana@gmail.com", "EmailAdmin");
		var to = new EmailAddress(toEmail, username);
		var plainTextContent = message;
		var htmlContent = $@"
		<html>
		<head>
			<style>
				body {{ font-family: 'Segoe UI', Arial, sans-serif; background: #f7f7f7; margin: 0; padding: 0; }}
				.container {{ max-width: 600px; margin: 40px auto; background: #fff; border-radius: 8px; box-shadow: 0 2px 8px rgba(0,0,0,0.05); padding: 32px; }}
				.header {{ text-align: center; padding-bottom: 16px; }}
				.header h1 {{ color: #2d7ff9; margin: 0; font-size: 2em; }}
				.content {{ font-size: 1.1em; color: #333; line-height: 1.7; }}
				.footer {{ text-align: center; color: #888; font-size: 0.95em; margin-top: 32px; }}
			</style>
		</head>
		<body>
			<div class='container'>
				<div class='header'>
					<h1>Welcome to Online Learning Platform!</h1>
				</div>
				<div class='content'>
					<p>Hey <strong>{username}</strong>!</p>
					<p>{message}</p>
				</div>
				<div class='footer'>
					<p>Stay inspired, stay innovative!<br/>The OLP Team</p>
				</div>
			</div>
		</body>
		</html>";
		var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
		var response = await client.SendEmailAsync(msg);
		// Log response status and body for debugging
		Console.WriteLine($"SendGrid Response Status: {response.StatusCode}");
		var responseBody = await response.Body.ReadAsStringAsync();
		Console.WriteLine($"SendGrid Response Body: {responseBody}");
	}
}