namespace NZWalks.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
       public double Description { get; set; }  
        public string WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }

        public Guid RegionId { get; set; }

        // Navigation Property
        //These properties tells the EntityFrameWork that class Walk has Difficulty and Region.

        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }  
    }
}
