using System;
using System.Collections;
using System.Collections.Generic;

namespace MyHome.Domain
{
    public class House : IComparable<House>
    {
        #region Properties
        /// <summary>
        /// Affecte ou obtient l'identifiant
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Affecte ou obtient le nom de la maison
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Affecte ou obtient la liste des pièces de la maison
        /// </summary>
        public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
        #endregion

        #region Methods
        /// <summary>
        /// Obtient le hashcode de l'objet
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            // La clé de hashage (son unicité) repose sur le nom de la maison
            return string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode();
        }

        /// <summary>
        /// Vérifie l'égalité entre 2 objets
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return GetHashCode().Equals(obj.GetHashCode());
        }

        /// <summary>
        /// Compare 2 maisons entre-elles
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(House other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }
        #endregion
    }
}
