using BlogAppAPI.DataAccess.Entity;

namespace BlogAppAPI.Repository.Interface
{
    public interface IUserBlogRepository
    {
        List<Model.UserBlogs> GetAllBlogs();
        List<Model.UserBlogs> GetBlogsById(int id);
        bool AddNewBlog(UserBlogs userBlogs);
        bool DeleteBlog(int ID,string emailID);
        bool AddComment(BlogComments blogComments);

        bool RegisterUser(Model.Users users);
        Model.Users Login(Model.Users users);
    }
}
