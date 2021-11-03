using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabahoIA_MVC.WebApplication.Models
{
    public class IdsData
    {
        public List<string> IdsList { get; set; }
        private List<string> AlphabetForIds { get; set; }

        public IdsData()
        {
            IdsList = new List<string>();
            AlphabetForIds = new List<string>();
        }

        public List<string> GetIdsList() 
        {
            CreateAlphabet();
            PopulateIds();
            return IdsList;
        }

        public void CreateAlphabet()
        {
            AlphabetForIds.Add("A");
            AlphabetForIds.Add("B");
            AlphabetForIds.Add("C");
            AlphabetForIds.Add("D");
            AlphabetForIds.Add("E");
            AlphabetForIds.Add("F");
            AlphabetForIds.Add("G");
            AlphabetForIds.Add("H");
            AlphabetForIds.Add("I");
            AlphabetForIds.Add("J");
            AlphabetForIds.Add("K");
            AlphabetForIds.Add("L");
            AlphabetForIds.Add("M");
            AlphabetForIds.Add("N");
            AlphabetForIds.Add("O");
        }

        public void PopulateIds()
        {
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    string id = AlphabetForIds[j] + i.ToString();
                    IdsList.Add(id);
                }
            }
        }
    }
}
