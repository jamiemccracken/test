using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Contracts
{

    public class ContractQuery
    {

        const string MusicContractFile = "MusicContracts.txt";
        const string PartnerContractFile = "PartnerContracts.txt";
        const string Header = "Artist|Title|Usages|StartDate|EndDate";

        private List<MusicContracts> MusicContractList;
        private List<PartnerContract> PartnerContractList;

        public List<string> ResultList;

        public DateTime ParseDate(string date)
        {

            if (string.IsNullOrEmpty(date))
                return DateTime.MaxValue;

            string[] dateparts = date.Split(' ');

            return ParseDate(dateparts[0], dateparts[1], dateparts[2]);

        }


        public DateTime ParseDate(string day, string month, string year)
        {
            char[] charsToTrim = {'t', 'T', 'h', 'H', 's',
                               'S', 't', 'T'};

            string date = day.Trim(charsToTrim) + " " + month + " " + year;

            return DateTime.Parse(date);

        }


        private bool LoadMusicContracts()
        {
            string[] readText = File.ReadAllLines(MusicContractFile);
            bool firstline = true;
            foreach (string s in readText)
            {
                if (firstline)
                {
                    firstline = false;
                    continue;
                }

                var contract = new MusicContracts();


                string[] array = s.Split('|');

                if (array.Length > 3)
                {
                    contract.Artist = array[0];
                    contract.Title = array[1];

                    contract.Usages = array[2].Split(',');

                    contract.StartDate = array[3];

                    if (array.Length == 5)
                        contract.EndDate = array[4];
                    else
                        contract.EndDate = "";

                    MusicContractList.Add(contract);

                }

            }

            return true;
        }

        private void LoadPartnerContracts()
        {
            string[] readText = File.ReadAllLines(PartnerContractFile);
            bool firstline = true;
            foreach (string s in readText)
            {
                if (firstline)
                {
                    firstline = false;
                    continue;
                }

                var contract = new PartnerContract();


                string[] array = s.Split('|');

                if (array.Length == 2)
                {
                    contract.Partner = array[0];
                    contract.Usage = array[1];

                    PartnerContractList.Add(contract);

                }
            }
        }

        private string GetUsageFromPartner (string Partner)
        {
            foreach (PartnerContract p in PartnerContractList)
                if (p.Partner.Trim() == Partner)
                    return p.Usage;

            return "";
        }


        public ContractQuery(string Partner, string day, string month, string year)
        {
            DateTime qdate = ParseDate(day, month, year);
            
            MusicContractList = new List<MusicContracts>();
            PartnerContractList = new List<PartnerContract>();
            ResultList = new List<string>();

            LoadMusicContracts();
            LoadPartnerContracts();

            var usage = GetUsageFromPartner(Partner);

            ResultList.Add(Header);

            foreach (MusicContracts c in MusicContractList)
            {

                foreach (string s in c.Usages)
                    if (s.Trim() == usage)
                    {
                        DateTime start = ParseDate(c.StartDate);
                        DateTime end = ParseDate(c.EndDate);

                        if (qdate >= start && qdate <= end)
                        {
                            


                            if (end == DateTime.MaxValue)
                            {
                                string output = string.Format("{0}|{1}|{2}|{3}|", c.Artist, c.Title, usage, c.StartDate);
                                ResultList.Add(output);

                            }
                            
                            else
                            {
                                string output = string.Format("{0}|{1}|{2}|{3}|{4}", c.Artist, c.Title, usage, c.StartDate, c.EndDate);
                                ResultList.Add(output);
                            }

                           
 
                        }


                    }


            }
        }


    }
}
