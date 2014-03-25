namespace FootballScore.BusinessLogic
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using FootballScore.Model;

    public static class GeneratorTeamResult
    {
        public static void Generate(Football football, List<string> pageContentList)
        {
            football.resultsFrance = GetResults(pageContentList[0]);
            football.resultsEngland = GetResults(pageContentList[1]);
            football.resultsSpain = GetResults(pageContentList[2]);
            football.resultsItalia = GetResults(pageContentList[3]);
            football.resultsGermany = GetResults(pageContentList[4]);
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
                resultList.Add(new TeamResult
                {
                    TeamName1 = team1List[i].Groups[1].ToString(),
                    TeamName2 = team2List[i].Groups[1].ToString(),
                    Score = score[i].Groups[1].ToString()
                });
            }

            foreach (var item in resultList)
            {
                item.TeamName1 = item.TeamName1.Remove(item.TeamName1.IndexOf("</a>"));
                int team1IndexOfLink = item.TeamName1.IndexOf("<a");
                int team1IndexOfClass = item.TeamName1.IndexOf("class=\"\">") != -1 ? item.TeamName1.IndexOf("class=\"\">") + 9 : item.TeamName1.IndexOf("class=\"gagne\">") + 14;
                item.TeamName1 = item.TeamName1.Remove(team1IndexOfLink, team1IndexOfClass - team1IndexOfLink);

                item.TeamName2 = item.TeamName2.Remove(item.TeamName2.IndexOf("</a>"));
                int team2IndexOfLink = item.TeamName2.IndexOf("<a");
                int team2IndexOfClass = item.TeamName2.IndexOf("class=\"\">") != -1 ? item.TeamName2.IndexOf("class=\"\">") + 9 : item.TeamName2.IndexOf("class=\"gagne\">") + 14;
                item.TeamName2 = item.TeamName2.Remove(team2IndexOfLink, team2IndexOfClass - team2IndexOfLink);

                item.Score = item.Score.Remove(0, item.Score.IndexOf(">") + 1);
                item.Score = item.Score.Remove(item.Score.IndexOf("</a>"));
            }

            return resultList;
        }
    }
}