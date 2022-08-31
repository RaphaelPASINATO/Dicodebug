using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dico
{
    public class Arbre
    {
        Noeud root;

        public Arbre()
        {
            root = new Noeud('!', true);
        }

        public void ajouterMot(List<char> leMot)
        {
            Noeud nd = root;
            Noeud temp;
            //cela ajoute une lettre dans l'arbe et supprime la première lettre du mot et retourne le noeud avec la derniere lettre
              while (leMot.Count() != 0)
            {
                if (leMot.Count() == 1)
                {
                    temp = nd.ajouterNoeud(leMot[0],true) ;
                    nd = temp;
                    leMot.RemoveAt(0);

                }
                else
                {
                    temp = nd.ajouterNoeud(leMot[0]);
                    nd = temp;
                    leMot.RemoveAt(0);
                }

            }
        }

        public string getMotAleatoire()
        {
            return root.getMotAleatoire("");
        }

        public List<string> getLesMotsPossibles(string mot)
        {
            List<char> lesLettres = new List<char>();
            for (int i =0; i < mot.Length;i++)
            {
                lesLettres.Add(mot[i]);
            }

            List<string> lesMots = new List<string>();
            root.getLesMotsPossibles("", lesLettres, lesMots);
            return lesMots;
        }
    }
}
