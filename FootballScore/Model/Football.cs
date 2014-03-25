namespace FootballScore.Model
{
    using System.Collections.Generic;

    public class Football
    {
        public List<TeamRanking> teamRankingFrance { get; set; }
        public List<TeamRanking> teamRankingEngland { get; set; }
        public List<TeamRanking> teamRankingSpain { get; set; }
        public List<TeamRanking> teamRankingItalia { get; set; }
        public List<TeamRanking> teamRankingGermany { get; set; }

        public List<PlayerRanking> playerRankingFrance { get; set; }
        public List<PlayerRanking> playerRankingEngland { get; set; }
        public List<PlayerRanking> playerRankingSpain { get; set; }
        public List<PlayerRanking> playerRankingItalia { get; set; }
        public List<PlayerRanking> playerRankingGermany { get; set; }

        public List<TeamResult> resultsFrance { get; set; }
        public List<TeamResult> resultsEngland { get; set; }
        public List<TeamResult> resultsSpain { get; set; }
        public List<TeamResult> resultsItalia { get; set; }
        public List<TeamResult> resultsGermany { get; set; }
    }
}