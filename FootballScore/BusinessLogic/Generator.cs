namespace FootballScore.BusinessLogic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FootballScore.Model;

    public static class Generator
    {
        public static List<Country> Generate()
        {
            const string ImageSource = "../../Images/";
            List<string> pageContentList = GetPageContentList();

            var countries = new List<Country>
                                {
                                    new Country(ImageSource + "fr.jpg"),
                                    new Country(ImageSource + "eng.jpg"),
                                    new Country(ImageSource + "sp.jpg"),
                                    new Country(ImageSource + "it.jpg"),
                                    new Country(ImageSource + "ger.jpg")
                                };

            GeneratorTeamResult.Generate(countries, pageContentList);
            GeneratorTeamRanking.Generate(countries, pageContentList);
            GeneratorPlayerRanking.Generate(countries, pageContentList);

            return countries;
        }

        private static List<string> GetPageContentList()
        {
            using (var client = new HttpClient())
            {
                var pageTaskList = new[]
                                   {
                                       // Team result
                                       client.GetStringAsync("http://www.lequipe.fr/Football/ligue-1-resultats.html"),
                                       client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-angleterre-resultats.html"),
                                       client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-espagne-resultats.html"),
                                       client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-italie-resultats.html"),
                                       client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-allemagne-resultats.html"),

                                       // Team ranking
                                       client.GetStringAsync("http://www.lequipe.fr/Football/ligue-1-classement.html"),
                                       client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-angleterre-classement.html"),
                                       client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-espagne-classement.html"),
                                       client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-italie-classement.html"),
                                       client.GetStringAsync("http://www.lequipe.fr/Football/championnat-d-allemagne-classement.html"),

                                       // Player ranking
                                       client.GetStringAsync("http://www.lequipe.fr/Football/FootballClassementChampionnat1914_BUT_1.html"),
                                       client.GetStringAsync("http://www.lequipe.fr/Football/FootballClassementChampionnat1909_BUT_1.html.html"),
                                       client.GetStringAsync("http://www.lequipe.fr/Football/FootballClassementChampionnat1907_BUT_1.html.html"),
                                       client.GetStringAsync("http://www.lequipe.fr/Football/FootballClassementChampionnat1905_BUT_1.html"),
                                       client.GetStringAsync("http://www.lequipe.fr/Football/FootballClassementChampionnat1911_BUT_1.html")
                                   };

                Task.WaitAll(pageTaskList);
                return pageTaskList.Select(t => t.Result).ToList();
            }
        }
    }
}