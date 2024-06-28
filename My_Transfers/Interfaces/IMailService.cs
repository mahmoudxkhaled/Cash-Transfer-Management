using My_Transfers.Class;

namespace My_Transfers.Interfaces
{
	public interface IMailService
	{
		Task SendAsync(MailRequest request);
	}
}
