namespace FootballScore.Model
{
    using System.Collections.Generic;

    public class Country
    {
        public Country(string image)
        {
            Image = image;
        }

        public string Image { get; set; }
        public List<TeamRanking> TeamRanking { get; set; }
        public List<PlayerRanking> PlayerRanking { get; set; }
        public List<TeamResult> TeamResult { get; set; }
    }
}