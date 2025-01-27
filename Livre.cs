namespace GestionBibliotheque
{
    /// <summary>
    /// Représente un livre dans la bibliothèque.
    /// </summary>
    internal class Livre
    {
        /// <summary>
        /// Titre du livre.
        /// </summary>
        public string titre;

        /// <summary>
        /// Auteur du livre.
        /// </summary>
        private string auteur;

        /// <summary>
        /// Indique si le livre est disponible pour emprunt.
        /// </summary>
        public bool EstDisponible = true;

        /// <summary>
        /// Nom de l'emprunteur du livre.
        /// </summary>
        public string? NomEmprunteur;

        /// <summary>
        /// Date à laquelle le livre a été emprunté.
        /// </summary>
        public DateTime? DateEmprunt;

        /// <summary>
        /// Date à laquelle le livre doit être retourné.
        /// </summary>
        public DateTime? DateRetour;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Livre"/>.
        /// </summary>
        /// <param name="titre">Titre du livre.</param>
        /// <param name="auteur">Auteur du livre.</param>
        public Livre(string titre, string auteur)
        {
            this.titre = titre;
            this.auteur = auteur;
        }

        /// <summary>
        /// Retourne une chaîne qui représente le livre.
        /// </summary>
        /// <returns>Une chaîne qui représente le livre.</returns>
        public override string ToString()
        {
            string dateEmpruntStr = DateEmprunt.HasValue ? DateEmprunt.Value.ToString("dd MMMM yyyy") : "N/A";
            string dateRetourStr = DateRetour.HasValue ? DateRetour.Value.ToString("dd MMMM yyyy") : "N/A";

            return titre + " de " + auteur + " : " + (EstDisponible ? "disponible" : "emprunté par " + NomEmprunteur + " depuis le " + dateEmpruntStr + " jusqu'au " + dateRetourStr);
        }
    }
}
