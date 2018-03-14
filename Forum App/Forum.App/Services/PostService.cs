using System;
using System.Collections.Generic;
using System.Linq;
using Forum.App.UserInterface.ViewModels;
using Forum.Data;
using Forum.Models;

namespace Forum.App.Services
{
    public class PostService
    {
        internal static Category GetCategory(int categoryId)
        {
            ForumData forumData = new ForumData();

            Category category = forumData.Categories.Find(c => c.Id == categoryId);

            return category;
        }

        internal static IList<ReplyViewModel> GetPostReplies(int postId)
        {
            ForumData forumData = new ForumData();

            Post post = forumData.Posts.Find(p => p.Id == postId);

            IList<ReplyViewModel> replies = new List<ReplyViewModel>();

            foreach (int replyId in post.ReplyIds)
            {
                Reply reply = forumData.Replies.Find(r => r.Id == replyId);

                replies.Add(new ReplyViewModel(reply));
            }

            return replies;
        }

        internal static string[] GetAllCategoryNames()
        {
            ForumData forumData = new ForumData();

            string[] allCategories = forumData.Categories.Select(c => c.Name).ToArray();

            return allCategories;
        }

        public static IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            ForumData forumData = new ForumData();

            var postIds = forumData.Categories.First(c => c.Id == categoryId).PostIDs;

            IEnumerable<Post> posts = forumData.Posts.Where(p => postIds.Contains(p.Id));

            return posts;
        }

        public static PostViewModel GetPostViewModel(int postId)
        {
            ForumData forumData = new ForumData();

            Post post = forumData.Posts.Find(p => p.Id == postId);

            PostViewModel pvm = new PostViewModel(post);

            return pvm;
        }

        private static Category EnsureCategory(PostViewModel postView, ForumData forumData)
        {
            var categoryName = postView.Category;
            Category category = forumData.Categories.FirstOrDefault(c => c.Name == categoryName);

            if (category == null)
            {
                var categories = forumData.Categories;
                int categoryId = categories.Any() ? categories.Last().Id + 1 : 1;
                category = new Category(categoryId, categoryName, new List<int>());
                forumData.Categories.Add(category);
            }

            return category;
        }

        public static bool TrySavePost(PostViewModel postViewModel)
        {
            bool emptyCategory = String.IsNullOrWhiteSpace(postViewModel.Category);
            bool emptyTitle = String.IsNullOrWhiteSpace(postViewModel.Title);
            bool emptyContent = !postViewModel.Content.Any();

            if (emptyCategory || emptyTitle || emptyContent)
            {
                return false;
            }

            ForumData forumData = new ForumData();

            Category category = EnsureCategory(postViewModel, forumData);

            int postId = forumData.Posts.Any() ? forumData.Posts.Last().Id + 1 : 1;

            User author = UserService.GetUser(postViewModel.Author);

            int authorId = author.Id;
            string content = string.Join("", postViewModel.Content);

            Post post = new Post(postId, postViewModel.Title, content, category.Id, authorId, new List<int>());

            forumData.Posts.Add(post);
            author.PostIDs.Add(post.Id);
            category.PostIDs.Add(post.Id);
            forumData.SaveChanges();

            postViewModel.PostId = postId;

            return true;
        }

        public static bool TrySaveReply(ReplyViewModel replyViewModel, int postId)
        {
            if (!replyViewModel.Content.Any())
            {
                return false;
            }

            ForumData forumData = new ForumData();

            User author = UserService.GetUser(replyViewModel.Author, forumData);
            int authorId = author.Id;

            Post post = forumData.Posts.Single(p => p.Id == postId);

            int replyId = forumData.Replies.LastOrDefault()?.Id + 1 ?? 1;
            string content = string.Join("", replyViewModel.Content);
            Reply reply = new Reply(replyId, content, authorId, postId);

            forumData.Replies.Add(reply);

            var tempReplyIds = post.ReplyIds.ToList();
            tempReplyIds.Add(replyId);
            post.ReplyIds = tempReplyIds;

            forumData.SaveChanges();

            return true;
        }
    }
}
