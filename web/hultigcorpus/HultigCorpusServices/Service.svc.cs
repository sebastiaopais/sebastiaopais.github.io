using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace HultigCorpusServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {

        public long EstimateResultsGoogle(string query)
        {
            String googleResult = "";
            var doc = new HtmlWeb().Load("http://www.google.com/search?q=" + query.ToString());
            var div = doc.DocumentNode.SelectSingleNode("//div[@id='resultStats']");
            var text = div.InnerText;
            Match matchs = Regex.Match(text, @"\d+");
            while (matchs.Success)
            {
                googleResult = googleResult + matchs.Groups[0].Value;
                matchs = matchs.NextMatch();
            }
            long estimateResult = 0;
            if (googleResult.ToString().Equals("") == false)
                estimateResult = Convert.ToInt64(googleResult);
            return estimateResult;
        }

        public long TotalHosts(string domain)
        {
            DBsConnect con = new DBsConnect("hultigcorpus_hosts_V1");
            return con.TotalHosts(domain);
        }

        public long TotalPages(string domain)
        {
            DBsConnect con = new DBsConnect("hultigcorpus_index_V1");
            return con.TotalPages(domain);
        }

        public long TotalPagesWithTerm(string domain, string term)
        {
            DBsConnect con = new DBsConnect("hultigcorpus_index_V1");
            return con.TotalPagesWithTerm(domain, term);
        }

        public List<string> HostsList()
        {
            DBsConnect con = new DBsConnect("hultigcorpus_hosts_V1");
            return con.HostsList();
        }

        public List<string> HostsListbyDomain(string domain)
        {
            DBsConnect con = new DBsConnect("hultigcorpus_hosts_V1");
            return con.HostsListbyDomain(domain);
        }

    }
}
