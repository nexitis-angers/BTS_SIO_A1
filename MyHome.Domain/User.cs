using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Domain
{
    public class User : IComparable<User>
    {
        #region Properties
        /// <summary>
        /// Affecte ou obtient l'identifiant
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Affecte ou obtient le prénom
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Affecte ou obtient le nom de famille
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Affecte ou obtient l'email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Affecte ou obtient le mot de passe
        /// </summary>
        public string Password { get; set; }
        #endregion

        #region Methods
        public override int GetHashCode()
        {
            // L'objet utilisateur sera unique de par son email
            return string.IsNullOrEmpty(Email) ? 0 : Email.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            // On force l'évaluation de l'égalité entre 2 utilisateurs sur le calcul du hashcode
            return GetHashCode().Equals(obj.GetHashCode());
        }

        public int CompareTo(User other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }
        #endregion
    }
}
