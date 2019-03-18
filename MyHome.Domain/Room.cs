using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Domain
{
    public class Room : IComparable<Room>
    {
        #region Properties
        /// <summary>
        /// Affecte ou obtient l'identifiant
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Affecte ou obtient le nom de la pièce
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Affecte ou obtient la description de la pièce
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Affecte ou obtient la propriété de navigation vers la maison
        /// </summary>
        public House House { get; set; }
        /// <summary>
        /// Affecte ou obtient l'idenfiant de la maison
        /// </summary>
        public int HouseId { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Obtient le hashcode de l'objet
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int houseHashCode = House == null ? 0 : House.GetHashCode();
            int myHashCode = string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode();
            
            // La clé de hashage (son unicité) repose sur le nom de la pièce multiplié par le hash de la maison
            return houseHashCode * myHashCode;
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
        public int CompareTo(Room other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }
        #endregion
    }
}
