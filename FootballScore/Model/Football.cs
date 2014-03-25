namespace FootballScore.Model
{
    using System.Collections.Generic;

    public class Football
    {
        public List<TeamRanking> TeamRankingFrance { get; set; }
        public List<TeamRanking> TeamRankingEngland { get; set; }
        public List<TeamRanking> TeamRankingSpain { get; set; }
        public List<TeamRanking> TeamRankingItalia { get; set; }
        public List<TeamRanking> TeamRankingGermany { get; set; }

        public List<PlayerRanking> PlayerRankingFrance { get; set; }
        public List<PlayerRanking> PlayerRankingEngland { get; set; }
        public List<PlayerRanking> PlayerRankingSpain { get; set; }
        public List<PlayerRanking> PlayerRankingItalia { get; set; }
        public List<PlayerRanking> PlayerRankingGermany { get; set; }

        public List<TeamResult> ResultsFrance { get; set; }
        public List<TeamResult> ResultsEngland { get; set; }
        public List<TeamResult> ResultsSpain { get; set; }
        public List<TeamResult> ResultsItalia { get; set; }
        public List<TeamResult> ResultsGermany { get; set; }
    }
}