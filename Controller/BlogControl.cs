using AppDatabase;
using AppModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController
{
    public class BlogControl : IBlogControl
    {
        private readonly IDatabase database;
        public BlogControl(IDatabase database)
        {
            this.database = database;
        }
        public async Task<bool> AddBlogComment(BlogComment comment)
        {
            string id = JsonConvert.SerializeObject(comment.Id);
            string value = JsonConvert.SerializeObject(comment);
            var isCreated = await database.Create("Comment", id, value);
            return isCreated;
        }
        public async Task<List<BlogComment>> ReadAllComments()
        {
            List<BlogComment> blogComments = new();
            var data = await database.ReadAll("Comment");
            if (data.Count() > 0)
            {
                foreach (var d in data)
                {
                    var comment = JsonConvert.DeserializeObject<BlogComment>(d.Value);
                    if (comment != null)
                    {
                        blogComments.Add(comment);
                    }
                }
            }
            return blogComments;
        }

        public async Task<bool> Create(BlogData blog)
        {
            string id = JsonConvert.SerializeObject(blog.Id);
            string value = JsonConvert.SerializeObject(blog);
            var isCreated = await database.Create("Blog", id, value);
            return isCreated;
        }
        public async Task<BlogData> Read(string key)
        {
            string id = JsonConvert.SerializeObject(key);
            var data = await database.Read("Blog", id);
            if (data.Value != "")
            {
                var blog = JsonConvert.DeserializeObject<BlogData>(data.Value);
                return blog ?? new BlogData();
            }
            return new BlogData();
        }
        public async Task<List<BlogData>> ReadAll()
        {
            List<BlogData> blogList = new();
            var data = await database.ReadAll("Blog");
            if (data.Count() > 0)
            {
                foreach (var d in data)
                {
                    var blog = JsonConvert.DeserializeObject<BlogData>(d.Value);
                    if (blog != null)
                    {
                        blogList.Add(blog);
                    }
                }
            }
            return blogList;
        }
        public async Task<bool> DeleteComments(string key)
        {
            string id = JsonConvert.SerializeObject(key);
            var isDeleted = await database.Delete("Comment", id);
            return isDeleted;
        }
        public async Task<bool> Delete(string key)
        {
            string id = JsonConvert.SerializeObject(key);
            var isDeleted = await database.Delete("Blog", id);
            return isDeleted;
        }
    }
}
