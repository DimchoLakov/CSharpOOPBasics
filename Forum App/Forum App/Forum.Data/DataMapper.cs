using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Forum.Models;

namespace Forum.Data
{
    public class DataMapper
    {
        private const string DATA_PATH = "../../../../data/";
        private const string CONFIG_PATH = "config.ini"; 

        private const string DEFAULT_CONFIG =
            "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";

        private static readonly Dictionary<string, string> config;

        static DataMapper()
        {
            Directory.CreateDirectory(DATA_PATH);
            config = LoadConfig(DATA_PATH + CONFIG_PATH);
        }

        public static void EnsureConfigFile(string configPath)
        {
            if (!File.Exists(configPath))
            {
                File.WriteAllText(configPath, DEFAULT_CONFIG);
            }
        }
        
        public static void EnsureFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }
        
        public static Dictionary<string, string> LoadConfig(string configPath)
        {
            EnsureConfigFile(configPath);

            string[] contents = ReadLines(configPath);

            Dictionary<string, string> config = contents
                .Select(l => l.Split('='))
                .ToDictionary(t => t[0], t => DATA_PATH + t[1]);

            return config;
        }
        
        public static string[] ReadLines(string path)
        {
            EnsureFile(path);
            string[] lines = File.ReadAllLines(path);
            return lines;
        }
        
        public static void WriteLines(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }
        
        public static List<Category> LoadCategories()
        {
            List<Category> categories = new List<Category>();
            string[] dataLines = ReadLines(config["categories"]);

            foreach (string line in dataLines)
            {
                string[] tokens = line.Split(";");
                int id = int.Parse(tokens[0]);
                string name = tokens[1];
                int[] postIds = tokens[2].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                Category category = new Category(id, name, postIds);
                categories.Add(category);
            }

            return categories;
        }
        
        public static void SaveCategories(List<Category> categories)
        {
            List<string> lines = new List<string>();

            foreach (Category category in categories)
            {
                string line = $"{category.Id};{category.Name};{string.Join(",", category.PostIDs)}";
                lines.Add(line);
            }

            WriteLines(config["categories"], lines.ToArray());
        }
        
        public static List<User> LoadUsers()
        {
            List<User> users = new List<User>();
            string[] dataLines = ReadLines(config["users"]);

            foreach (string line in dataLines)
            {
                string[] tokens = line.Split(";");
                int id = int.Parse(tokens[0]);
                string username = tokens[1];
                string password = tokens[2];
                int[] postIds = tokens[3].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                User user = new User(id,username, password, postIds);
                users.Add(user);
            }

            return users;
        }
        
        public static void SaveUsers(List<User> users)
        {
            List<string> lines = new List<string>();

            foreach (User user in users)
            {
                string line = $"{user.Id};{user.Username};{user.Password};{string.Join(",", user.PostIDs)}";
                lines.Add(line);
            }

            WriteLines(config["users"], lines.ToArray());
        }
        
        public static List<Post> LoadPosts()
        {
            List<Post> posts = new List<Post>();
            string[] dataLines = ReadLines(config["posts"]);

            foreach (string line in dataLines)
            {
                string[] tokens = line.Split(";");
                int id = int.Parse(tokens[0]);
                string title = tokens[1];
                string content = tokens[2];
                int categoryId = int.Parse(tokens[3]);
                int authorId = int.Parse(tokens[4]);
                int[] replyIds = tokens[5].Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                Post category = new Post(id, title, content, categoryId, authorId, replyIds);
                posts.Add(category);
            }

            return posts;
        }
        
        public static void SavePosts(List<Post> posts)
        {
            List<string> lines = new List<string>();

            foreach (Post post in posts)
            {
                string line = $"{post.Id};{post.Title};{post.Content};{post.CategoryId};{post.AuthorId};{string.Join(",", post.ReplyIds)}";
                lines.Add(line);
            }

            WriteLines(config["posts"], lines.ToArray());
        }
        
        public static List<Reply> LoadReplies()
        {
            List<Reply> replies = new List<Reply>();
            string[] dataLines = ReadLines(config["replies"]);

            foreach (string line in dataLines)
            {
                string[] tokens = line.Split(";");
                int id = int.Parse(tokens[0]);
                string content = tokens[1];
                int authorId = int.Parse(tokens[2]);
                int postId = int.Parse(tokens[3]);

                Reply category = new Reply(id, content, authorId, postId);
                replies.Add(category);
            }

            return replies;
        }
        
        public static void SaveReplies(List<Reply> replies)
        {
            List<string> lines = new List<string>();

            foreach (Reply reply in replies)
            {
                string line = $"{reply.Id};{reply.Content};{reply.AuthorId};{reply.PostId}";
                lines.Add(line);
            }

            WriteLines(config["replies"], lines.ToArray());
        }
    }
}
