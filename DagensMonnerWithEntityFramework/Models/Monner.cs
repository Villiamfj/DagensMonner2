namespace DagensMonnerWithEntityFramework.Models
{
    public class Monner
    {
        public Monner(int id, string name, string imageLink, int timesTaken)
        {
            Id = id;
            Name = name;
            ImageLink = imageLink;
            TimesTaken = timesTaken;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageLink { get; set; }
        public int TimesTaken { get; set; }
    }
}
