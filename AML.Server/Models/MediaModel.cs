namespace AML.Server.Models
{
    public class MediaModel
    {
        public int MediaId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public bool Available { get; set; }
        public MediaType MediaType { get; set; }
        public string Description { get; set; }

        public MediaModel(int mediaId, string name, float price, bool available, MediaType mediaType, string description)
        {
            MediaType = mediaType;
            Name = name;
            Price = price;
            Available = available;
            MediaType = mediaType;
            Description = description;
        }
    }
}
