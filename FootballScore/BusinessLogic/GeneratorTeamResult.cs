namespace FootballScore.BusinessLogic
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using FootballScore.Model;

    public static class GeneratorTeamResult
    {
        public static void Generate(List<Country> countries, List<string> pageContentList)
        {
            countries[0].TeamResult = GetResults(pageContentList[0]);
            countries[1].TeamResult = GetResults(pageContentList[1]);
            countries[2].TeamResult = GetResults(pageContentList[2]);
            countries[3].TeamResult = GetResults(pageContentList[3]);
            countries[4].TeamResult = GetResults(pageContentList[4]);
        }

        private static List<TeamResult> GetResults(string pageContent)
        {
            var sectionContent = Regex.Match(pageContent, @"<div id=""CONT"">(.*?)<div id=""col-droite""", RegexOptions.IgnoreCase);

            var team1List = Regex.Matches(sectionContent.Value, @"<div class=""equipeDom"">(.*?)</div>", RegexOptions.IgnoreCase);
            var team2List = Regex.Matches(sectionContent.Value, @"<div class=""equipeExt"">(.*?)</div>", RegexOptions.IgnoreCase);
            var score = Regex.Matches(sectionContent.Value, @"<div class=""score"">(.*?)</div>", RegexOptions.IgnoreCase);

            var resultList = new List<TeamResult>();

            for (int i = 0; i < score.Count; i++)
            {
                var team1 = team1List[i].Groups[1].ToString();
                var teamName1 = Regex.Match(team1, @"alt=""(.*?)""", RegexOptions.IgnoreCase);
                var image1 = Regex.Match(team1, @"<img src=""(.*?)""", RegexOptions.IgnoreCase);

                var team2 = team2List[i].Groups[1].ToString();
                var teamName2 = Regex.Match(team2, @"alt=""(.*?)""", RegexOptions.IgnoreCase);
                var image2 = Regex.Match(team2, @"<img src=""(.*?)""", RegexOptions.IgnoreCase);

                resultList.Add(new TeamResult
                {
                    TeamName1 = teamName1.Groups[1].ToString(),
                    Image1 = image1.Groups[1].ToString(),
                    TeamName2 = teamName2.Groups[1].ToString(),
                    Image2 = image2.Groups[1].ToString(),
                    Score = score[i].Groups[1].ToString()
                });
            }

            foreach (var item in resultList)
            {
                item.Score = item.Score.Remove(0, item.Score.IndexOf(">") + 1);
                item.Score = item.Score.Remove(item.Score.IndexOf("</a>"));
            }

            return resultList;
        }
    }
}