namespace BlogAppAPI.Model
{
    public class UserBlogs
    {
        public int ID { get; set; }
        public int? AuthorID { get; set; }
        public string? Title { get; set; }

        public string? Content { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public string? PostDate { get; set; }

        public Users? Users { get; set; }

        public List<BlogComments>? BlogComments { get; set; }
    }
}
