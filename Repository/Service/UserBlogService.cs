using BlogAppAPI.DataAccess.Entity;
using BlogAppAPI.Repository.Interface;

namespace BlogAppAPI.Repository.Service
{
    public class UserBlogService : IUserBlogRepository
    {
        public UserBlogService()
        {

        }

        public List<Model.UserBlogs> GetAllBlogs()
        {
            using (var context = new AppDbContext())
            {
                // Query data
                var result = context.UserBlogs.Select(x => new Model.UserBlogs { 
                    ID = x.ID,
                    AuthorID = x.AuthorID,
                    Content = x.Content,
                    Title = x.Title,
                    CreatedBy = x.CreatedBy,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedDate = x.ModifiedDate,
                    CreatedDate = x.CreatedDate,
                    PostDate= x.CreatedDate.Value.ToString("dd MMM"),
                    Users= context.Users.Where(z=>z.ID==x.AuthorID).Select(z => new Model.Users { 
                           FirstName=z.FirstName+" "+z.LastName,
                    }).FirstOrDefault(),
                    BlogComments = context.BlogComments.Where(y => y.BlogID == x.ID).Select(y => new Model.BlogComments
                    {
                        ID = y.ID,
                        CommenterID = y.CommenterID,
                        CommenterName=context.Users.Where(a=>a.ID==y.CommenterID).Select(a=>a.FirstName).FirstOrDefault()??"",
                        Comment = y.Comment,
                        CreatedDate=y.CreatedDate,
                        CommentDate=y.CreatedDate.Value.ToString("dd MMM"),
                    }).OrderByDescending(y => y.CreatedDate).ToList()
                }
                ).OrderByDescending(x=>x.CreatedDate).ToList();


                return result;
            }
        }
        public List<Model.UserBlogs> GetBlogsById(int id)
        {
            using (var context = new AppDbContext())
            {
                var result = context.UserBlogs.Where(x=>x.AuthorID==id).Select(x => new Model.UserBlogs
                {
                    ID = x.ID,
                    AuthorID = x.AuthorID,
                    Content = x.Content,
                    Title = x.Title,
                    CreatedBy = x.CreatedBy,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedDate = x.ModifiedDate,
                    CreatedDate = x.CreatedDate,
                    PostDate = x.CreatedDate.Value.ToString("dd MMM"),
                    Users = context.Users.Where(z => z.ID == x.AuthorID).Select(z => new Model.Users
                    {
                        FirstName = z.FirstName + " " + z.LastName,
                    }).FirstOrDefault(),
                    BlogComments = context.BlogComments.Where(y => y.BlogID == x.ID).Select(y => new Model.BlogComments
                    {
                        ID = y.ID,
                        CommenterID = y.CommenterID,
                        CommenterName = context.Users.Where(a => a.ID == y.CommenterID).Select(a => a.FirstName).FirstOrDefault() ?? "",
                        Comment = y.Comment,
                        CreatedDate = y.CreatedDate,
                        CommentDate = y.CreatedDate.Value.ToString("dd MMM"),
                    }).OrderByDescending(y => y.CreatedDate).ToList()
                }
                ).OrderByDescending(x => x.CreatedDate).ToList();


                return result;
            }
        }
        public bool AddNewBlog(UserBlogs userBlogs)
        {
            using (var context = new AppDbContext())
            {
                var obj = new UserBlogs
                {
                    AuthorID = userBlogs.AuthorID,
                    Title = userBlogs.Title,
                    Content = userBlogs.Content,
                    CreatedBy = userBlogs.AuthorID,
                    CreatedDate = DateTime.Now,
                };

                context.UserBlogs.Add(obj);
                context.SaveChanges();

                return true;

            }
        }

        public bool DeleteBlog(int ID)
        {
            using (var context = new AppDbContext())
            {
                var obj = context.UserBlogs.Where(x => x.ID == ID).FirstOrDefault();

                context.UserBlogs.Remove(obj);
                context.SaveChanges();

                return true;

            }
        }


        public bool AddComment(BlogComments blogComments)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var blogObj = new BlogComments
                    {
                        CommenterID = blogComments.CommenterID,
                        Comment = blogComments.Comment,
                        BlogID = blogComments.BlogID,
                        CreatedDate = DateTime.Now,
                        CreatedBy = 1,
                    };

                    context.BlogComments.Add(blogObj);
                    context.SaveChanges();

                    return true;

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool RegisterUser(Model.Users user)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var obj = new Users
                    {
                        FirstName = user.FirstName,
                        LastName= user.LastName,
                        EmailID = user.EmailID,
                        IsActive= true,
                        ContactNo = user.ContactNo,
                        Gender = user.Gender,
                        Password = user.Password,
                        CreatedDate = DateTime.Now,
                        CreatedBy = 1,
                    };

                    context.Users.Add(obj);
                    context.SaveChanges();

                    return true;

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Model.Users Login(Model.Users user)
        {
            try
            {

                using (var context = new AppDbContext())
                {

                   var result = context.Users.Where(x => x.EmailID == user.EmailID && x.Password == user.Password).Select(x=> new Model.Users
                    { 
                       ID=x.ID,
                       FirstName=x.FirstName,
                       LastName=x.LastName,
                       EmailID=x.EmailID
                    }).FirstOrDefault();
                   
                    return result;

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
