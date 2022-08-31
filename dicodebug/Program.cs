
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dico;
using System.IO;
namespace dicodebug
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue sur le système de débogage de l'algorithme du mot le plus long");

            bool res = false;
            int dicoChosi = 0;
            while (res == false)
            {
                Console.WriteLine("\nVeuillez choisir un dictionnaire pour commencer :");
                Console.WriteLine("1 - Pays");
                Console.WriteLine("2 - Objets");
                Console.WriteLine("3 - Pokemon");
                Console.WriteLine("4 - Test");
                Console.Write("Veuillez entre le nombre du dictionnaire choisi : ");
                string saisie = Console.ReadLine();
                res = int.TryParse(saisie, out dicoChosi);
                if (res == false)
                {
                    Console.WriteLine("la saisie n'est pas correcte.");
                }
                else
                {
                    if (dicoChosi > 4 || dicoChosi < 1)
                    {
                        res = false;
                        Console.WriteLine("la saisie ne peut pas être supérieur à 4 ou inférieur à 1.");
                    }
                }
              
            }

            string dicoSelectionne = "";
            switch(dicoChosi)
            {
                case 1:
                    dicoSelectionne = "../../dico/pays.csv";
                    break;
                case 2:
                    dicoSelectionne = "../../dico/objets.csv";
                    break;
                case 3:
                    dicoSelectionne = "../../dico/pokemon.csv";
                    break;
                case 4:
                    dicoSelectionne = "../../dico/test.csv";
                    break;
            }

            Console.Clear();



            int compteurMot = 0;
            var reader = new StreamReader(File.OpenRead(dicoSelectionne));
            string unMot;
            List<char> desLettres = new List<char>();
            Arbre unArbre = new Arbre(); 
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var valeurs = line.Split(';');

                for (int j = 0; j < valeurs.Count(); j++)
                {
                    compteurMot++;
                    unMot = valeurs[j];
                    if (desLettres.Count() != 0)
                    {
                        desLettres.RemoveRange(0, desLettres.Count() - 1);
                    }
                    for (int k = 0; k < unMot.Length; k++)
                    {
                        desLettres.Add(unMot[k]);
                    }
                    unArbre.ajouterMot(desLettres);

                }


            }


            Console.WriteLine("A chaque fois que vous allez appuyer sur n'importe quelle\ntouche du clavier, un mot est tiré aléatoirement du dictionnaire\net le programme va afficher tous les mots du dictionnaire pouvant\nêtre écrit avec les lettres du mot tiré aléatoirement.");
            Console.WriteLine("\nNB : si par exemple on tire un mot qui contient deux fois la\nlettre a, alors tous les mots pouvant être écrit vont contenir\nau maximum deux fois la lettre a.\n");
            Console.Write("Appuyer sur une touche pour trouver un mot aléatoire dans l'arbre : ");
            Console.ReadKey();
            Console.WriteLine("\n");
            for (int j = 0; j  <200     ;j ++) {
                string al = unArbre.getMotAleatoire();
                Console.WriteLine("le mot aléatoire est : " + al);
                List<string> lesMotsPossibles = unArbre.getLesMotsPossibles(al);
                Console.WriteLine("les mots possibles sont :");
                foreach (string mots in lesMotsPossibles)
                {
                    Console.WriteLine(mots);
                }
                Console.WriteLine();
                Console.Write("Appuyer sur une touche pour trouver un mot aléatoire dans l'arbre : ");
                Console.ReadKey();
                Console.WriteLine("\n");
            }
          


        }
    }
}
