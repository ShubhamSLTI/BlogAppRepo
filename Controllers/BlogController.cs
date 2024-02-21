using BlogAppAPI.DataAccess.Entity;
using BlogAppAPI.Model;
using BlogAppAPI.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Xml.Linq;

namespace BlogAppAPI.Controllers
{
    //[EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IUserBlogRepository _UserBlogService;
        public BlogController(IUserBlogRepository UserBlogService)
        {
            _UserBlogService = UserBlogService;
        }

        //[Authorize]
        [HttpGet("GetBlogs")]
        public ActionResult GetBlogs()
        {

            var result = _UserBlogService.GetAllBlogs();

            return Ok(result);

        }

        [Authorize]
        [HttpGet("GetBlogsByID")]
        public ActionResult GetBlogsByID(int ID)
        {
           
            var result = _UserBlogService.GetBlogsById(ID);

            return Ok(result);

        }

        [HttpPost("AddBlog")]
        public ActionResult AddBlog(DataAccess.Entity.UserBlogs userBlogs)
        {

            var result = _UserBlogService.AddNewBlog(userBlogs);

            return Ok(result);

        }


        [Authorize]
        [HttpGet("DeleteBlog")]
        public ActionResult DeleteBlog(int ID)
        {
            var handler = new JwtSecurityTokenHandler();
            string token = HttpContext.Request.Headers["Authorization"][0].Substring("Bearer ".Length);
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            string emailID = jsonToken.Claims.Where(x => x.Type == "email").Select(x => x.Value).FirstOrDefault();

            var result = _UserBlogService.DeleteBlog(ID, emailID);

            return Ok(result);

        }

        [HttpPost("AddComment")]
        public ActionResult AddComment(DataAccess.Entity.BlogComments blogComments)
        {

            var result = _UserBlogService.AddComment(blogComments);

            return Ok(result);

        }


        [HttpPost("RegisterUser")]
        public ActionResult RegisterUser(Model.Users user)
        {

            var result = _UserBlogService.RegisterUser(user);

            return Ok(result);

        }

        [Authorize]
        [HttpPost("Login")]
        public ActionResult Login(Model.Users user)
        {

            var result = _UserBlogService.Login(user);

            return Ok(result);

        }

        [HttpGet("TestAPI")]
        public ActionResult TestAPI(int ID)
        {

            return Ok("Working!!");

        }
    }
}
