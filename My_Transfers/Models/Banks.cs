namespace My_Transfers.Models;

public class Banks
{
    public int ID { get; set; } 
    public string? BANK_NAME { get; set; } = "";
    public string? ACC_NAME { get; set; } = "";
    public string? ACC_TYPE { get; set; } = "";
	public string? BRANCH { get; set; } = "";
    public decimal? ACC_NUM { get; set; } = 0;
	public string? EMAIL { get; set; } = "";
    public decimal? BALANCE { get; set; } = 0;


}
