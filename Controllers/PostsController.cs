using final_api.Models;
using final_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace final_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly ILogger<PostsController> _logger;

    private readonly IPostsRepository _postRepository;

    public PostsController(ILogger<PostsController> logger, IPostsRepository repository)
    {
        _logger = logger;
        _postRepository = repository;
    }

    // POST / create new post
    [HttpPost]
    public ActionResult<Post> CreateNewPost(Post createPost)
    {
        if (!ModelState.IsValid || createPost == null) {
            return BadRequest();
        }

        var newPost = _postRepository.CreatePost(createPost);
        return Created(nameof(GetPostById), newPost);
    }
    
    // GET one post by post id
    [HttpGet]
    [Route("{postId:int}")]
    public ActionResult<Post> GetPostById(int postId)
    {
        var post = _postRepository.GetPostByPostId(postId);

        if (post == null) {
            return NotFound();
        }

        return Ok(post);
    }

    // GET ALL posts 
    [HttpGet]
    public ActionResult<IEnumerable<Post>> GetAllPosts() 
    {
        return Ok(_postRepository.GetAllPosts());
    }

    // GET ALL posts by user id
    [HttpGet]
    [Route("user/{userId:int}")]
    public ActionResult<IEnumerable<Post>> GetPostsByUserId(int userId)
    {
        var userPosts = _postRepository.GetPostsByUserId(userId);

        if (userPosts == null) {
            return NotFound();
        }
        
        return Ok(userPosts);
    }

    // PUT / edit post by post id
    [HttpPut]
    [Route("{postId:int}")]
    public ActionResult<Post> EditPost(Post editPost)
    {
        if (!ModelState.IsValid || editPost == null) {
            return BadRequest();
        }

        return Ok(_postRepository.EditPost(editPost));
    }

    // DELETE / post by post id
    [HttpDelete]
    [Route("{postId:int}")]
    public ActionResult DeletePost(int postId)
    {
        _postRepository.DeletePostById(postId);
        return NoContent();
    }


}