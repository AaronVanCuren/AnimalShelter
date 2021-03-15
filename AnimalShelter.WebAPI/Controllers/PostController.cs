using AnimalShelter.Data;
using AnimalShelter.Models;
using AnimalShelter.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AnimalShelter.WebAPI.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        private PostServices CreatePostServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            ApplicationUser user = new UserService(userId).GetUserByType(UserType.company);

            var postService = new PostServices(userId, user.UserType, user.ProfileId);
            return postService;
        }

        public IHttpActionResult Get()
        {
            PostServices postService = CreatePostServices();
            var posts = postService.GetPosts();
            return Ok(posts);
        }

        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostServices();

            if (!service.CreatePost(post))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            PostServices postService = CreatePostServices();
            var post = postService.GetPostById(id);
            return Ok(post);
        }

        public IHttpActionResult Put(PostRUD post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostServices();

            if (!service.UpdatePost(post))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreatePostServices();

            if (!service.DeletePost(id))
                return InternalServerError();

            return Ok();
        }
    }
}