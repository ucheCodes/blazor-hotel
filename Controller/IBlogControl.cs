using AppModels;

namespace AppController
{
    public interface IBlogControl
    {
        Task<bool> Create(BlogData blog);
        Task<bool> Delete(string key);
        Task<BlogData> Read(string key);
        Task<List<BlogData>> ReadAll();
        Task<bool> DeleteComments(string key);
        Task<List<BlogComment>> ReadAllComments();
        Task<bool> AddBlogComment(BlogComment comment);
    }
}