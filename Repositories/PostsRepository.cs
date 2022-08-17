using final_api.Migrations;
using final_api.Models;

namespace final_api.Repositories;

public class PostsRepository : IPostsRepository 
{
    private readonly PostsDbContext _context;

    public PostsRepository(PostsDbContext context) {
        _context = context;
    }

    // POST / NEW post
    public Post CreatePost(Post newPost)
    {
        // Do I need to add anything in here that links the User data to the post?
        
        _context.Posts.Add(newPost);
        _context.SaveChanges();
        return newPost;
    }

    // DELETE / delete post by id
    public void DeletePostById(int postId)
    {
        var post = _context.Posts.Find(postId);

        if (post != null) {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

    }

    // PUT / edit post by id
    public Post? EditPost(Post editPost)
    {
        var originalPost = _context.Posts.Find(editPost.PostId);

        if (originalPost != null) {
            originalPost.Title = editPost.Title;
            originalPost.Content = editPost.Content;
            _context.SaveChanges();
        }

        return originalPost;
    }

    // GET / ALL posts
    public IEnumerable<Post> GetAllPosts()
    {
        return _context.Posts.ToList();
    }

    // GET / one post by post id
    public Post? GetPostByPostId(int postId)
    {
        return _context.Posts.SingleOrDefault(p => p.PostId == postId);
    }

    // GET / one post by user id
    // public Post? GetPostByUserId(int userId)
    // {
    //     throw new NotImplementedException();
    // }

    // GET / ALL posts by user id
    public List<Post>? GetPostsByUserId(int userId)
    {
        // How do I use LINQ here to get all posts by user ID & add them to a list of posts?

        var postList = _context.Posts.Where(u => u.UserId == userId).ToList();

        return postList;
    }    
    
}