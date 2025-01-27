namespace GestionBibliotheque
{
    internal class Bibliotheque
    {
        private readonly List<Livre> Livres = [];

        /// <summary>
        /// Ajoute un livre à la bibliothèque.
        /// </summary>
        /// <param name="livre">Le livre à ajouter.</param>
        public void AjouterLivre(Livre livre)
        {
            Livres.Add(livre);
            Console.WriteLine("Livre ajouté avec succès");
        }

        /// <summary>
        /// Supprime un livre de la bibliothèque.
        /// </summary>
        /// <param name="livre">Le titre du livre à supprimer.</param>
        public void SupprimerLivre(string livre)
        {
            Livre? livreASupprimer = RechercherLivre(livre);
            if (livreASupprimer != null)
            {
                Livres.Remove(livreASupprimer);

                Console.WriteLine("Livre supprimé avec succès !");
            }
            else
            {
                Console.WriteLine("Le livre n'existe pas");
            }
        }

        /// <summary>
        /// Recherche un livre par son titre.
        /// </summary>
        /// <param name="titre">Le titre du livre à rechercher.</param>
        /// <returns>Le livre trouvé ou null si aucun livre ne correspond.</returns>
        public Livre? RechercherLivre(string titre)
        {
            return Livres.Find(livre => livre.titre.Equals(titre, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Emprunte un livre de la bibliothèque.
        /// </summary>
        /// <param name="titre">Le titre du livre à emprunter.</param>
        /// <param name="nomEmprunteur">Le nom de l'emprunteur.</param>
        public void EmprunterLivre(string titre, string nomEmprunteur)
        {
            Livre? livre = RechercherLivre(titre);
            if (livre != null)
            {
                if (livre.EstDisponible)
                {
                    livre.EstDisponible = false;
                    livre.NomEmprunteur = nomEmprunteur;
                    livre.DateEmprunt = DateTime.Now;
                    livre.DateRetour = DateTime.Now.AddDays(30);

                    Console.WriteLine("Livre emprunté avec succès.");
                }
                else
                {
                    Console.WriteLine("Le livre n'est pas disponible");
                }
            }
            else
            {
                Console.WriteLine("Le livre n'existe pas !");
            }
        }

        /// <summary>
        /// Retourne un livre emprunté à la bibliothèque.
        /// </summary>
        /// <param name="titre">Le titre du livre à retourner.</param>
        public void RetournerLivre(string titre)
        {
            Livre? livre = RechercherLivre(titre);
            try
            {
                if (!livre.EstDisponible)
                {
                    livre.EstDisponible = true;
                    livre.NomEmprunteur = null;
                    livre.DateEmprunt = null;
                    livre.DateRetour = DateTime.Now;

                    Console.WriteLine("Livre retourné avec succès.");
                }
                else
                {
                    Console.WriteLine("Le livre n'est pas emprunté");
                }
            }
            catch
            {
                Console.WriteLine("Le livre n'existe pas !");
            }
        }

        /// <summary>
        /// Affiche tous les livres de la bibliothèque.
        /// </summary>
        public void AfficherLivres()
        {
            foreach (Livre livre in Livres)
            {
                Console.WriteLine(livre.ToString());
            }
        }
    }
}
