namespace FootballScore.BusinessLogic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FootballScore.Model;

    public static class Generator
    {
        public static Football Generate()
        {
            List<string> pageContentList = GetPageContentList();

            var football = new Football();

            GeneratorTeamResult.Generate(football, pageContentList);
            GeneratorTeamRanking.Generate(football, pageContentList);
            GeneratorPlayerRanking.Generate(football, pageContentList);

            return football;
        }

        private static List<string> GetPageContentList()
        {
            using (HttpClient client = new HttpClient())
            {
                var pageTaskList = new List<Task<string>>();

                // Team result
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/ligue-1-resultats.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-angleterre-resultats.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-espagne-resultats.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-italie-resultats.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-allemagne-resultats.html"));

                // Team ranking
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/ligue-1-classement.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-angleterre-classement.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-espagne-classement.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-italie-classement.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-allemagne-classement.html"));

                // Player ranking
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/FootballClassementChampionnat1914_BUT_1.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/FootballClassementChampionnat1909_BUT_1.html.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/FootballClassementChampionnat1907_BUT_1.html.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/FootballClassementChampionnat1905_BUT_1.html"));
                pageTaskList.Add(client.GetStringAsync("http://www.lequipe.fr/Football/FootballClassementChampionnat1911_BUT_1.html"));

                Task.WaitAll(pageTaskList.ToArray());
                return pageTaskList.Select(t => t.Result).ToList();
            }
        }
    }
}