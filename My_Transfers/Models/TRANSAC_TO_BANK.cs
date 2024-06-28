namespace My_Transfers.Models
{
	public class TRANSAC_TO_BANK
	{

		public int ID { get; set; } = 0;

		public int? TRANSFER_CODE { get; set; } = 0;
		public string? CREDITOR_NAME { get; set; } = "";
		public decimal? CREDITOR_ACC_NUM { get; set; } = 0;
		public string CREDITOR_ACC_TYPE { get; set; } = "";
		public string? BANK_NAME { get; set; } = "";
		public string? BRANCH { get; set; } = "";
		public string? ACC_NAME { get; set; } = "";
		public decimal? ACC_NUM { get; set; } 
		public string? ACC_TYPE { get; set; } = "";
		public decimal? AMOUNT { get; set; } = 0;
		public string? TRANSC_PURPOSE { get; set; } = "";
		public string? PURPOSE_REMITTANCE_INFORMATION { get; set; } = "";
		public DateTime? DUE_DATE { get; set; } = DateTime.Now.Date;
		public bool? APPROVAL { get; set; } = false;
		public bool? EMAIL_SENT { get; set; } = false;


	}
}
