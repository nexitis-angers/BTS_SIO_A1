using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Domain
{
    public abstract class Equipment : IComparable<Equipment>
    {
        #region Properties
        /// <summary>
        /// Affecte ou obtient l'identifiant
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Affecte ou obtient le nom de l'équipement
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Affecte ou obtient la propriété de navigation vers la pièce
        /// </summary>
        public Room Room { get; set; }
        /// <summary>
        /// Affecte ou obtient l'identifiant de la pièce où est situé l'équipement
        /// </summary>
        public int RoomId { get; set; }
        #endregion

        #region Methods
        public override int GetHashCode()
        {
            int roomHashCode = RoomId;
            int equipmentHashCode = string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode();

            return roomHashCode * equipmentHashCode;
        }

        public override bool Equals(object obj)
        {
            return GetHashCode().Equals(obj.GetHashCode());
        }

        public int CompareTo(Equipment other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }
        #endregion
    }
}
