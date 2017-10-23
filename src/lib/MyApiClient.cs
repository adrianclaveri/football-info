using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyApi
{
    public class Self
    {
        public string href { get; set; }
    }

    public class Team
    {
        public string href { get; set; }
    }

    public class Fixtures
    {
        public string href { get; set; }
    }

    public class LeagueTable
    {
        public string href { get; set; }
    }

    public class Links
    {
        public Self self { get; set; }
        public Team teams { get; set; }
        public Fixtures fixtures { get; set; }
        public LeagueTable leagueTable { get; set; }
    }

    public class Competition
    {
        public string href { get; set; }
    }

    public class LinksLeague
    {
        public Self self { get; set; }
        public Competition competition { get; set; }
    }

    public class Links2
    {
        public Team team { get; set; }
    }

    public class Home
    {
        public int goals { get; set; }
        public int goalsAgainst { get; set; }
        public int wins { get; set; }
        public int draws { get; set; }
        public int losses { get; set; }
    }

    public class Away
    {
        public int goals { get; set; }
        public int goalsAgainst { get; set; }
        public int wins { get; set; }
        public int draws { get; set; }
        public int losses { get; set; }
    }

    public class Standing
    {
        public Links2 _links { get; set; }
        public int position { get; set; }
        public string teamName { get; set; }
        public string crestURI { get; set; }
        public int playedGames { get; set; }
        public int points { get; set; }
        public int goals { get; set; }
        public int goalsAgainst { get; set; }
        public int goalDifference { get; set; }
        public int wins { get; set; }
        public int draws { get; set; }
        public int losses { get; set; }
        public Home home { get; set; }
        public Away away { get; set; }
    }

    public class LeagueResult
    {
        public LinksLeague _links { get; set; }
        public string leagueCaption { get; set; }
        public int matchday { get; set; }
        public List<Standing> standing { get; set; }
    }

    public class ApiResult
    {
        public Links _links { get; set; }
        public int id { get; set; }
        public string caption { get; set; }
        public string league { get; set; }
        public string year { get; set; }
        public int currentMatchday { get; set; }
        public int numberOfMatchdays { get; set; }
        public int numberOfTeams { get; set; }
        public int numberOfGames { get; set; }
        public DateTime lastUpdated { get; set; }
    }

    public class NetFootballDataClient
    {
        public string ApiUrl { get; set; } = "http://www.football-data.org/v1/competitions";

        public async Task<ApiResult[]> GetCompetitions()
        {
            ApiResult[] result = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                var response = await client.GetAsync(ApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ApiResult[]>(json);
                }
            }

            return result;
        }

        public async Task<LeagueResult> GetLeagueTable(string parameter)
        {
            var result = new LeagueResult();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                var response = await client.GetAsync(ApiUrl + "/" + parameter + "/leagueTable");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<LeagueResult>(json);
                }
            }

            return result;
        }
    }
}