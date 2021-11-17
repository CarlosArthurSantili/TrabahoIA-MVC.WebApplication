using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabahoIA_MVC.WebApplication.Models
{
    public class IdsData
    {
        public Dictionary<string, string> IdsDictionary { get; set; }
        private List<string> AlphabetForIds { get; set; }

        public IdsData()
        {
            IdsDictionary = new Dictionary<string, string>();
            AlphabetForIds = new List<string>();
        }

        public Dictionary<string, string> GetIdsDictionary() 
        {
            CreateAlphabet();
            PopulateIds();
            return IdsDictionary;
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
                    IdsDictionary.Add(id, id);
                }
            }
        }

        public List<string> GetShelvesIds() 
        {
            List<string> shelvesIds = new List<string>();
            shelvesIds.Add("A1");
            shelvesIds.Add("A2");
            shelvesIds.Add("A3");
            shelvesIds.Add("A4");
            shelvesIds.Add("A5");
            shelvesIds.Add("A6");
            shelvesIds.Add("A7");
            shelvesIds.Add("A8");
            shelvesIds.Add("A9");
            shelvesIds.Add("A10");
            shelvesIds.Add("C1");
            shelvesIds.Add("C2");
            shelvesIds.Add("C3");
            shelvesIds.Add("C4");
            shelvesIds.Add("C5");
            shelvesIds.Add("C6");
            shelvesIds.Add("C7");
            shelvesIds.Add("C8");
            shelvesIds.Add("C9");
            shelvesIds.Add("C10");
            shelvesIds.Add("D1");
            shelvesIds.Add("D2");
            shelvesIds.Add("D3");
            shelvesIds.Add("D4");
            shelvesIds.Add("D5");
            shelvesIds.Add("D6");
            shelvesIds.Add("D7");
            shelvesIds.Add("D8");
            shelvesIds.Add("D9");
            shelvesIds.Add("D10");
            shelvesIds.Add("F1");
            shelvesIds.Add("F2");
            shelvesIds.Add("F3");
            shelvesIds.Add("F4");
            shelvesIds.Add("F5");
            shelvesIds.Add("F6");
            shelvesIds.Add("F7");
            shelvesIds.Add("F8");
            shelvesIds.Add("F9");
            shelvesIds.Add("F10");
            shelvesIds.Add("G1");
            shelvesIds.Add("G2");
            shelvesIds.Add("G3");
            shelvesIds.Add("G4");
            shelvesIds.Add("G5");
            shelvesIds.Add("G6");
            shelvesIds.Add("G7");
            shelvesIds.Add("G8");
            shelvesIds.Add("G9");
            shelvesIds.Add("G10");
            shelvesIds.Add("I1");
            shelvesIds.Add("I2");
            shelvesIds.Add("I3");
            shelvesIds.Add("I4");
            shelvesIds.Add("I5");
            shelvesIds.Add("I6");
            shelvesIds.Add("I7");
            shelvesIds.Add("I8");
            shelvesIds.Add("I9");
            shelvesIds.Add("I10");
            shelvesIds.Add("J1");
            shelvesIds.Add("J2");
            shelvesIds.Add("J3");
            shelvesIds.Add("J4");
            shelvesIds.Add("J5");
            shelvesIds.Add("J6");
            shelvesIds.Add("J7");
            shelvesIds.Add("J8");
            shelvesIds.Add("J9");
            shelvesIds.Add("J10");
            shelvesIds.Add("L1");
            shelvesIds.Add("L2");
            shelvesIds.Add("L3");
            shelvesIds.Add("L4");
            shelvesIds.Add("L5");
            shelvesIds.Add("L6");
            shelvesIds.Add("L7");
            shelvesIds.Add("L8");
            shelvesIds.Add("L9");
            shelvesIds.Add("L10");
            shelvesIds.Add("M1");
            shelvesIds.Add("M2");
            shelvesIds.Add("M3");
            shelvesIds.Add("M4");
            shelvesIds.Add("M5");
            shelvesIds.Add("M6");
            shelvesIds.Add("M7");
            shelvesIds.Add("M8");
            shelvesIds.Add("M9");
            shelvesIds.Add("M10");
            shelvesIds.Add("O1");
            shelvesIds.Add("O2");
            shelvesIds.Add("O3");
            shelvesIds.Add("O4");
            shelvesIds.Add("O5");
            shelvesIds.Add("O6");
            shelvesIds.Add("O7");
            shelvesIds.Add("O8");
            shelvesIds.Add("O9");
            shelvesIds.Add("O10");
            return shelvesIds;
        }

        public List<string> GetRobotInitialPlaces() 
        {
            List<string> robotIds = new List<string>();
            robotIds.Add("A12");
            robotIds.Add("B12");
            robotIds.Add("C12");
            robotIds.Add("D12");
            robotIds.Add("E12");
            return robotIds;
        }

        public List<string> GetUnreachableIds() 
        {
            List<string> unreachbleIds = new List<string>();
            unreachbleIds.Add("F12");
            unreachbleIds.Add("G12");
            unreachbleIds.Add("H12");
            unreachbleIds.Add("I12");
            unreachbleIds.Add("J12");
            unreachbleIds.Add("K12");
            unreachbleIds.Add("L12");
            unreachbleIds.Add("M12");
            unreachbleIds.Add("N12");
            unreachbleIds.Add("O12");
            return unreachbleIds;
        }
    }
}
