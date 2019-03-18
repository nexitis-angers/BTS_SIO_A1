using System;
using System.Collections.Generic;

namespace MyHome.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne personne1 = new Personne() { Nom = "DANIEL", Prenom = "Cedric" };
            Personne personne2 = new Personne() { Nom = "DANIEL", Prenom = "Cedric" };

            bool personne1EqualsPersonne2 = personne1.Equals(personne2);

            ICollection<Personne> personnesSansDoublons = new HashSet<Personne>();
            personnesSansDoublons.Add(personne1);
            personnesSansDoublons.Add(personne2);

            ICollection<Personne> personnesAvecDoublons = new List<Personne>();
            personnesAvecDoublons.Add(personne1);
            personnesAvecDoublons.Add(personne2);
        }
    }

    public class Personne
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public override int GetHashCode()
        {
            return (Nom + "_" + Prenom).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return GetHashCode().Equals(obj.GetHashCode());
        }
    }
}
