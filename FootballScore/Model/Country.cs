namespace FootballScore.Model
{
    using System.Collections.Generic;

    public class Country
    {
        public List<TeamRanking> TeamRanking { get; set; }
        public List<PlayerRanking> PlayerRanking { get; set; }
        public List<TeamResult> Results { get; set; }
    }
}