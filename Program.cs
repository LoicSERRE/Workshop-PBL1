using GestionBibliotheque;

class Program
{
    /// <summary>
    /// Clear la console
    /// </summary>
    public static void ClearConsole()
    {
        Console.Clear();
    }

    /// <summary>
    /// Point d'entrée principal de l'application.
    /// </summary>
    static void Main()
    {
        Bibliotheque bibliotheque = new();
        bool continuer = true;

        while (continuer)
        {
            Console.WriteLine("\n+----------------------------------------------------------+");
            Console.WriteLine("|                          Menu                            |");
            Console.WriteLine("+----------------------------------------------------------+");
            Console.WriteLine("| 1. Ajouter un livre                                      |");
            Console.WriteLine("| 2. Supprimer un livre                                    |");
            Console.WriteLine("| 3. Rechercher un livre                                   |");
            Console.WriteLine("| 4. Emprunter un livre                                    |");
            Console.WriteLine("| 5. Retourner un livre                                    |");
            Console.WriteLine("| 6. Afficher tous les livres                              |");
            Console.WriteLine("| 7. Quitter l'application                                 |");
            Console.WriteLine("+----------------------------------------------------------+\n");

            Console.Write("Choisissez une option: ");
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    Console.Write("Entrez le titre du livre: ");
                    string titreAjout = Console.ReadLine();

                    Console.Write("Entrez l'auteur du livre: ");
                    string auteurAjout = Console.ReadLine();

                    ClearConsole();

                    bibliotheque.AjouterLivre(new Livre(titreAjout, auteurAjout));
                    break;

                case "2":
                    Console.Write("Entrez le titre du livre à supprimer: ");
                    string titreSuppression = Console.ReadLine();

                    ClearConsole();

                    bibliotheque.SupprimerLivre(titreSuppression);

                    break;

                case "3":
                    Console.Write("Entrez le titre du livre à rechercher: ");
                    string titreRecherche = Console.ReadLine();

                    Livre livreTrouve = bibliotheque.RechercherLivre(titreRecherche);

                    ClearConsole();

                    if (livreTrouve != null)
                    {
                        Console.WriteLine($"Livre trouvé: {livreTrouve}");
                    }
                    else
                    {
                        Console.WriteLine("Livre non trouvé.");
                    }

                    break;

                case "4":
                    Console.Write("Entrez le titre du livre à emprunter: ");
                    string titreEmprunt = Console.ReadLine();

                    Console.Write("Entrez le nom de l'emprunteur: ");
                    string emprunteur = Console.ReadLine();

                    ClearConsole();

                    bibliotheque.EmprunterLivre(titreEmprunt, emprunteur);
                    
                    break;

                case "5":
                    Console.Write("Entrez le titre du livre à retourner: ");
                    string titreRetour = Console.ReadLine();

                    ClearConsole();

                    bibliotheque.RetournerLivre(titreRetour);

                    break;

                case "6":
                    Console.WriteLine("Liste des livres:");
                    bibliotheque.AfficherLivres();

                    break;

                case "7":
                    continuer = false;
                    Console.WriteLine("Au revoir!");

                    break;

                default:
                    Console.WriteLine("Option invalide. Veuillez réessayer.");
                    break;
            }
        }
    }
}
