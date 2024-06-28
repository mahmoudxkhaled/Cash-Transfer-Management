namespace My_Transfers.Models;

public class Transfers
{
	public int ID { get; set; } = 0;
	public int? TRANSFER_CODE { get; set; } = 0;
	public int? PROJECT_ID { get; set; } = 0;
	public string? DESCRIPTION { get; set; } = "";
    public decimal? AMOUNT { get; set; } = 0;
	public DateTime? DUE_DATE { get; set; } = DateTime.Now.Date;
	public bool? APPROVAL { get; set; } = false;


	public int? BANK { get; set; } = 0;


	public string? CREDITOR_NAME { get; set; } = "";
	public string? TRANSC_PURPOSE { get; set; } = "";
	public string? PURPOSE_REMITTANCE_INFORMATION { get; set; } = "";
	public string? CREDITOR_ACC_TYPE { get; set; } = "";
	public decimal? CREDITOR_ACC_NUM { get; set; } = 0;
	public bool? SENT_EMAIL { get; set; } = false;

}
