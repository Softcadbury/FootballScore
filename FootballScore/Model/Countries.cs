namespace FootballScore.Model
{
    public class Countries
    {
        public Countries()
        {
            France = new Country();
            England = new Country();
            Spain = new Country();
            Italia = new Country();
            Germany = new Country();
        }

        public Country France { get; set; }
        public Country England { get; set; }
        public Country Spain { get; set; }
        public Country Italia { get; set; }
        public Country Germany { get; set; }
    }
}