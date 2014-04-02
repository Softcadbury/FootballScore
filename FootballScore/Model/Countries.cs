namespace FootballScore.Model
{
    public class Countries
    {
        public Countries()
        {
            France = new Country("fr.jpg");
            England = new Country("eng.jpg");
            Spain = new Country("sp.jpg");
            Italia = new Country("it.jpg");
            Germany = new Country("ger.jpg");
        }

        public Country France { get; set; }
        public Country England { get; set; }
        public Country Spain { get; set; }
        public Country Italia { get; set; }
        public Country Germany { get; set; }
    }
}