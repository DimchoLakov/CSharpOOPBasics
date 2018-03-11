using System.Collections.Generic;

namespace Forum.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<int> PostIDs { get; set; }

        public Category(int id, string name, ICollection<int> posts)
        {
            this.Id = id;
            this.Name = name;
            this.PostIDs = new List<int>(posts);
        }
    }
}
