using System;
using System.Collections.Generic;
using System.Linq;
namespace TPMoyennes;
class Eleve
{   // Propriétés pour le prénom et le nom de l'élève
    public string prenom { get; private set; }
    public string nom { get; private set; }

    // Liste pour stocker les notes de l'élève
    private List<Note> notes;

    // Constructeur de la classe Eleve
    public Eleve(string Prenom, string Nom)
    {
        prenom = Prenom;
        nom = Nom;
        notes = new List<Note>();

    }
    // Méthode pour ajouter une note à l'élève
    public void ajouterNote(Note note)
    {
        if (notes.Count < 200)
        {
            notes.Add(note);
        }
        else
        {
            Console.WriteLine("L'élève a reçu déjà 200 notes, impossible d'en rajouter une de plus!");
        }
    }
    // Méthode pour calculer la moyenne d'un élève dans une matière spécifique
    public float moyenneMatiere(int matiere)
    {
        float somme = 0;
        int count = 0;
        // Parcours de toutes les notes de l'élève
        foreach (var note in notes)
        {
            // Vérification si la note correspond à la matière spécifiée
            if (note.matiere == matiere)
            {
                somme += note.note; // Ajout de la note à la somme
                count++; // Incrémentation du compteur
            }
        }
        // Calcul de la moyenne arrondie à deux chiffres après la virgule
        if (count > 0)
        {
            return (float)Math.Round(somme / count, 2);
        }
        else
        {
            return 0;
        }
    }
    // Méthode pour calculer la moyenne générale de l'élève
    public float moyenneGeneral()
    {
        float sommeMoyennesMatieres = 0;
        int count = 0;

        // Parcours de toutes les matières pour l'élève 
        foreach (var matiere in notes.Select(note => note.matiere))
        {
            float moyenneMatieres = moyenneMatiere(matiere);  // Appel de la méthode moyenneMatiere

            sommeMoyennesMatieres += moyenneMatieres;  // Ajout de la moyenne de la matière à la somme
            count++;  // Incrémentation du compteur
        }

        // Calcul de la moyenne générale en arrondissant à deux chiffres après la virgule
        if (count > 0)
        {
            return (float)Math.Round(sommeMoyennesMatieres / count, 2);  // Retourne la moyenne arrondie
        }
        else
        {
            return 0;  // Si aucune matière, retourne 0 pour éviter une division par zéro
        }
    }


}

class Classe
{
    // Propriété pour le nom de la classe
    public string nomClasse { get; private set; }
    // Liste d'élèves dans la classe
    public List<Eleve> eleves;
    // Liste des matières enseignées dans la classe
    public List<string> matieres;
    // Constructeur de la classe, initialise le nom de la classe et les listes d'élèves et de matières
    public Classe(string NomClasse)
    {
        nomClasse = NomClasse;
        eleves = new List<Eleve>();
        matieres = new List<string>();
    }
    // Méthode pour ajouter un élève à la classe
    public void ajouterEleve(string prenom, string nom)
    {
        if (eleves.Count < 30)
        {
            eleves.Add(new Eleve(prenom, nom));
        }
        else
        {
            Console.WriteLine("La classe est pleine, impossible d'ajouter un élève supplémentaire.");

        }

    }
    // Méthode pour ajouter une matière à la liste des matières enseignées dans la classe
    public void ajouterMatiere(string matiere)
    {
        if (matieres.Count < 10)
        {
            matieres.Add(matiere);
        }
        else
        {
            Console.WriteLine("Le nombre maximum de matières autorisé est atteint!");
        }
    }
    // Méthode pour calculer la moyenne de la classe dans une matière spécifique
    public float moyenneMatiere(int matiere)
    {
        float somme = 0;
        int count = 0;
        // Parcours de tous les élèves de la classe
        foreach (var eleve in eleves)
        {
            // Ajout de la moyenne de l'élève dans la matière à la somme
            somme += eleve.moyenneMatiere(matiere);
            count++;

        }
        // Calcul de la moyenne en arrondissant à deux chiffres après la virgule
        if (count > 0)
        {
            return (float)Math.Round(somme / count, 2);
        }
        else
        {
            return 0;
        }
    }
    // Méthode pour calculer la moyenne générale de la classe
    public float moyenneGeneral()
    {
        float somme = 0;
        int count = 0;
        // Parcours de tous les élèves de la classe
        foreach (var eleve in eleves)
        {
            // Ajout de la moyenne générale de l'élève à la somme
            somme += eleve.moyenneGeneral();
            count++;

        }
        // Calcul de la moyenne en arrondissant à deux chiffres après la virgule
        if (count > 0)
        {
            return (float)Math.Round(somme / count, 2);
        }
        else
        {
            return 0;
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Création d'une classe
        Classe sixiemeA = new Classe("6eme A");
        // Ajout des élèves à la classe
        sixiemeA.ajouterEleve("Jean", "RAGE");
        sixiemeA.ajouterEleve("Paul", "HAAR");
        sixiemeA.ajouterEleve("Sibylle", "BOQUET");
        sixiemeA.ajouterEleve("Annie", "CROCHE");
        sixiemeA.ajouterEleve("Alain", "PROVISTE");
        sixiemeA.ajouterEleve("Justin", "TYDERNIER");
        sixiemeA.ajouterEleve("Sacha", "TOUILLE");
        sixiemeA.ajouterEleve("Cesar", "TICHO");
        sixiemeA.ajouterEleve("Guy", "DON");
        // Ajout de matières étudiées par la classe
        sixiemeA.ajouterMatiere("Francais");
        sixiemeA.ajouterMatiere("Anglais");
        sixiemeA.ajouterMatiere("Physique/Chimie");
        sixiemeA.ajouterMatiere("Histoire");
        Random random = new Random();
        // Ajout de 5 notes à chaque élève et dans chaque matière
        for (int ieleve = 0; ieleve < sixiemeA.eleves.Count; ieleve++)
        {
            for (int matiere = 0; matiere < sixiemeA.matieres.Count; matiere++)
            {
                for (int i = 0; i < 5; i++)
                {
                    sixiemeA.eleves[ieleve].ajouterNote(new Note(matiere, (float)((6.5 +
                   random.NextDouble() * 34)) / 2.0f));
                    // Note minimale = 3
                }
            }
        }

        Eleve eleve = sixiemeA.eleves[6];
        // Afficher la moyenne d'un élève dans une matière
        Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne en " + sixiemeA.matieres[1] + " : " +
        eleve.moyenneMatiere(1) + "\n");
        // Afficher la moyenne générale du même élève
        Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne Generale : " + eleve.moyenneGeneral() + "\n");
        // Afficher la moyenne de la classe dans une matière
        Console.Write("Classe de " + sixiemeA.nomClasse + ", Moyenne en " + sixiemeA.matieres[1] + " : " +
        sixiemeA.moyenneMatiere(1) + "\n");
        // Afficher la moyenne générale de la classe
        Console.Write("Classe de " + sixiemeA.nomClasse + ", Moyenne Generale : " + sixiemeA.moyenneGeneral() + "\n");
        Console.Read();
    }
}






