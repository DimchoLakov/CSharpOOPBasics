using System.Collections.Generic;

namespace Forum.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<int> PostIDs { get; set; }

        public User(int id, string username, string password, ICollection<int> postIDs)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.PostIDs = new List<int>(postIDs);
        }
    }
}