namespace FootballScore.BusinessLogic
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using FootballScore.Model;

    public static class GeneratorPlayerRanking
    {
        public static void Generate(Football football, List<string> pageContentList)
        {
            football.playerRankingFrance = GetPlayerRanking(pageContentList[10]);
            football.playerRankingEngland = GetPlayerRanking(pageContentList[11]);
            football.playerRankingSpain = GetPlayerRanking(pageContentList[12]);
            football.playerRankingItalia = GetPlayerRanking(pageContentList[13]);
            football.playerRankingGermany = GetPlayerRanking(pageContentList[14]);
        }

        private static List<PlayerRanking> GetPlayerRanking(string pageContent)
        {
            var sectionContent = Regex.Match(pageContent, @"<div id=""cont"">(.*?)<div class=""clear"">", RegexOptions.IgnoreCase);

            var playerList = Regex.Matches(sectionContent.Value, @"html""><strong>(.*?)</strong>", RegexOptions.IgnoreCase);
            var imageList = Regex.Matches(sectionContent.Value, @"<img(.*?)/>", RegexOptions.IgnoreCase);
            var pointList = Regex.Matches(sectionContent.Value, @"<div class=""points"">(.*?)</div>", RegexOptions.IgnoreCase);

            var playerRankingList = new List<PlayerRanking>();

            for (int i = 0; i < 20; i++)
            {
                playerRankingList.Add(new PlayerRanking
                {
                    PlayerName = playerList[i].Groups[1].ToString(),
                    Image = imageList[i].Groups[1].ToString(),
                    Goal = pointList[i * 2].Groups[1].ToString(),
                    Match = pointList[i * 2 + 1].Groups[1].ToString()
                });
            }

            foreach (var item in playerRankingList)
            {
                if (item.Goal.IndexOf("(") != -1)
                    item.Goal = item.Goal.Remove(item.Goal.IndexOf("("));
            }

            return playerRankingList;
        }
    }
}