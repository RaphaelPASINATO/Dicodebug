using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dico
{
    class Noeud
    {
        char lettre;
        List<Noeud> enfants;
        bool racine;
        bool finDeMot;
        public Noeud(char laLettre, bool laRacine)
        {
            lettre = laLettre;
            enfants = new List<Noeud>();
            racine = laRacine;
            finDeMot = false;
        }

        public char getLettre()
        {
            return lettre;
        }

        public bool estRacine()
        {
            return racine;
        }

        public void setFinDeMot(bool res)
        {
            finDeMot = res;
        }
        public bool getFinDeMot()
        {
            return finDeMot;
        }
        public List<Noeud> getLesEnfants()
        {
            return enfants;
        }

        public Noeud ajouterNoeud(char laLettre)
        {
            bool ext = false;
            foreach (Noeud n in enfants)
            {
                if (n.getLettre() == laLettre)
                {
                    ext = true;
                    return n;
                }
            }
            if (ext == false)
            {
                Noeud unNoeud = new Noeud(laLettre, false);
                enfants.Add(unNoeud);
                return unNoeud;
            }
            else
            {
                return null;
            }
        }

        public Noeud ajouterNoeud(char laLettre, bool fin)
        {
            bool ext = false;
            foreach (Noeud n in enfants)
            {
                if (n.getLettre() == laLettre)
                {
                    ext = true;
                    n.setFinDeMot(fin);
                    return n;
                }
            }
            if (ext == false)
            {
                Noeud unNoeud = new Noeud(laLettre, false);
                unNoeud.setFinDeMot(fin);
                enfants.Add(unNoeud);
                return unNoeud;
            }
            else
            {
                return null;
            }
        }

        //le paramètre doit être une chaine vide à l'appel
        Random rng = new Random(DateTime.Now.Millisecond);
        public string getMotAleatoire(string mot)
        {

            if (enfants.Count() != 0)
            {                
                 int unNombre = rng.Next(0, enfants.Count());
                mot = mot + enfants[unNombre].getLettre();
                 return (enfants[unNombre].getMotAleatoire(mot));

            }
            return mot;
        }

        //fonction inutilisé servant à parcourir l'intégralité de l'arbre
        public void parcourirArbre(string mot)
        {
            foreach(Noeud N in getLesEnfants())
            {
                if (N.getLesEnfants().Count()!= 0)
                {

                    N.parcourirArbre(mot+N.getLettre());
                }
                else
                {
                    mot = mot + N.getLettre();
                    Console.Write(mot);
                    Console.WriteLine("");
                }
            }
        }


        public void getLesMotsPossibles(string mot, List<char> lesLettres, List<string> lesMots)
        {  
            foreach (Noeud N in getLesEnfants())
            {
                if (N.getLesEnfants().Count() != 0)
                {
                    if (lesLettres.Contains(N.getLettre()) == true)
                    {
                        string leMot = mot + N.getLettre();
                        int nbLettres = 0;
                        foreach( char i in lesLettres)
                        {
                            if (i == N.getLettre())
                            {
                                nbLettres++;
                            }
                        }
                        for(int i =0; i < leMot.Length;i++)
                        {
                            if (leMot[i] == N.getLettre())
                            {
                                nbLettres--;
                            }
                        }
                        if ( nbLettres >= 0)
                        {
                            if (N.getFinDeMot() == true)
                            {
                                lesMots.Add(leMot);
                            }
                            N.getLesMotsPossibles(leMot, lesLettres, lesMots);
                        }
                    }

                }
                else
                {
                    if (lesLettres.Contains(N.getLettre()) == true)
                    {
                        string leMot = mot + N.getLettre();
                        int nbLettres = 0;
                        foreach (char i in lesLettres)
                        {
                            if (i == N.getLettre())
                            {
                                nbLettres++;
                            }
                        }
                        for (int i = 0; i < leMot.Length; i++)
                        {
                            if (leMot[i] == N.getLettre())
                            {
                                nbLettres--;
                            }
                        }
                        if (nbLettres >= 0)
                        {
                            lesMots.Add(leMot);
                        }
                       
                    }


                }
               
            }


        }

    }
}
