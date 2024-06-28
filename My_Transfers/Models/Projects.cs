namespace My_Transfers.Models
{
    public class Projects
    {
        public int ID { get; set; }

        public int? PROJECT_ID { get; set; } = 0;
        public string? PROJECT_NAME { get; set; } = "";   
        public bool? STATUS { get; set; }=false;

    }
}
