﻿namespace FootballScore.BusinessLogic
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using FootballScore.Model;

    public static class GeneratorTeamRanking
    {
        public static void Generate(List<Country> countries, List<string> pageContentList)
        {
            countries[0].TeamRanking = GetTeamRanking(pageContentList[5]);
            countries[1].TeamRanking = GetTeamRanking(pageContentList[6]);
            countries[2].TeamRanking = GetTeamRanking(pageContentList[7]);
            countries[3].TeamRanking = GetTeamRanking(pageContentList[8]);
            countries[4].TeamRanking = GetTeamRanking(pageContentList[9]);
        }

        private static List<TeamRanking> GetTeamRanking(string pageContent)
        {
            var sectionContent = Regex.Match(pageContent, @"<div id=""CONT"">(.*?)</section>", RegexOptions.IgnoreCase);

            var teamList = Regex.Matches(sectionContent.Value, @"<strong>(.*?)</strong></a>", RegexOptions.IgnoreCase);
            var imageList = Regex.Matches(sectionContent.Value, @"<img src=""(.*?)"" alt", RegexOptions.IgnoreCase);
            var pointList = Regex.Matches(sectionContent.Value, @"<div class=""points"">(.*?)</div>", RegexOptions.IgnoreCase);
            var dayList = Regex.Matches(sectionContent.Value, @"<div class=""j"">(.*?)</div>", RegexOptions.IgnoreCase);
            var differenceList = Regex.Matches(sectionContent.Value, @"<div class=""diff"">(.*?)</div>", RegexOptions.IgnoreCase);

            var teamRankingList = new List<TeamRanking>();

            for (int i = 0; i < teamList.Count; i++)
            {
                teamRankingList.Add(new TeamRanking
                {
                    TeamName = teamList[i].Groups[1].ToString(),
                    Image = imageList[i].Groups[1].ToString(),
                    Point = pointList[i].Groups[1].ToString(),
                    Day = dayList[i].Groups[1].ToString(),
                    Difference = differenceList[i].Groups[1].ToString()
                });
            }

            foreach (var item in teamRankingList)
            {
                item.TeamName = item.TeamName.Remove(0, item.TeamName.IndexOf("<strong>") + 8);
            }

            return teamRankingList;
        }
    }
}