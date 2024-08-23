using Contracts.Interfaces;
using Contracts.Models;
using Engine.Storage.DbContexts;
using Engine.Storage.Entities;
using Microsoft.EntityFrameworkCore;

namespace Engine.Managers;

internal sealed class PostManager : IPostManager
{
    private readonly ApplicationDbContext _context;

    public PostManager(ApplicationDbContext context)
    {
        _context = context;
    }

    ///<inheritdoc/>
    public async Task AddRangePostsAsync(IEnumerable<PostDto> postsDto, CancellationToken cancellationToken)
    {
        var postsDtoArray = postsDto.ToArray();
        var posts = new List<Post>();
        for (var i = 0; i < postsDtoArray.Length; i++)
        {
            var postDto = postsDtoArray[i];
            var alreadyExist = await _context.Posts.AnyAsync(x => x.ExternalId == postDto.ExternalId, cancellationToken);
            var description = postDto.Description?.Length > 200? postDto.Description?.Substring(0, 197) + "..." : postDto.Description;
            if (description?.StartsWith(":") ?? false)
            {
                description = description.Remove(0, 1);
            }
            if (!alreadyExist)
            {
                var newPost = new Post
                {
                    Id = Guid.NewGuid(),
                    Title = postDto.Title,
                    Description = description,
                    Link = postDto.Link,
                    ImageUrl = postDto.ImageUrl,
                    CreatedAt = DateTimeOffset.UtcNow,
                    ExternalId = postDto.ExternalId,
                    Tag = postDto.Tag,
                    Magnit = postDto.Magnet,
                };
                posts.Add(newPost);
            }
        }
        _context.Posts.AddRange(posts);
        await _context.SaveChangesAsync(cancellationToken);
    }

    ///<inheritdoc/>
    public async Task SetPublishedPostAsync(Guid id, PublishResult result, CancellationToken cancellationToken)
    {
        var post = await _context.Posts.FirstAsync(x => x.Id == id, cancellationToken);
        if (result.Success)
        {
            post.PublishedAt = DateTimeOffset.UtcNow;
            post.Status = PostStatus.Published;
        }
        else
        {
            post.Status = PostStatus.Error;
            post.ErrorMessage = result.ErrorMessage;
        }
        
        await _context.SaveChangesAsync(cancellationToken);
    }

    ///<inheritdoc/>
    public async Task AddNewPostAsync(PostDto postDto, CancellationToken cancellationToken)
    {
        var alreadyExist = await _context.Posts.FirstOrDefaultAsync(x => x.ExternalId == postDto.ExternalId, cancellationToken);
        var description = postDto.Description?.Length > 200? postDto.Description?.Substring(0, 197) + "..." : postDto.Description;
        if (description?.StartsWith(":") ?? false)
        {
            description = description.Remove(0, 1);
        }
        if (alreadyExist is null)
        {
            var newPost = new Post
            {
                Id = Guid.NewGuid(),
                Title = postDto.Title,
                Description = description,
                Link = postDto.Link,
                ImageUrl = postDto.ImageUrl,
                CreatedAt = DateTimeOffset.UtcNow,
                ExternalId = postDto.ExternalId,
                Tag = postDto.Tag,
                Magnit = postDto.Magnet,
            };
            await _context.Posts.AddAsync(newPost, cancellationToken);
        }
        else
        {
            alreadyExist.Status = PostStatus.New;
            alreadyExist.PublishedAt = null;
            alreadyExist.ImageUrl = postDto.ImageUrl;
            alreadyExist.Link = postDto.Link;
            alreadyExist.Title = postDto.Title;
        }
        await _context.SaveChangesAsync(cancellationToken);
    }

    ///<inheritdoc/>
    public async Task<NotPublishedPost?> GetNotPublishedPostAsync(CancellationToken cancellationToken)
    {
        var post = await _context.Posts
            .Where(p => p.Status == PostStatus.New)
            .OrderBy(p => p.CreatedAt)
            .FirstOrDefaultAsync(cancellationToken);
        return post is null ? null : new NotPublishedPost(post.Id, post.Title, post.Description, post.ImageUrl, post.Link, post.Tag, post.Magnit);
    }
}