namespace Library_bvd53jkl.models
{
    public class Video
    {
        public Video(int id,string name, string description, int duration) //конструктор некого видоса
        {
            Id = id;
            Name=name; 
            Description=description;
            Duration = duration;
        }
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration {  get; set; }
    }
}
