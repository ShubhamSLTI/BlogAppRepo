namespace BlogAppAPI.Model
{
    public class BlogComments
    {
        public int? ID { get; set; }
        public int? BlogID { get; set; }
        public string? Comment { get; set; }
        public int? CommenterID { get; set; }

        public string CommenterName { get; set; }
        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public string? CommentDate { get; set; }
    }
}
