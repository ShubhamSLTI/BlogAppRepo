namespace BlogAppAPI.Model
{
    public class Users
    {
        public int? ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailID { get; set; }
        public string? ContactNo { get; set; }
        public string? Password { get; set; }
        public string? Gender { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }
    }
}
