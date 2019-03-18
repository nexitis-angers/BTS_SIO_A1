using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Domain
{
    public class Alarm : Equipment
    {
        #region Constants
        /// <summary>
        /// Décrit la durée d'exécution de l'alarme en cas d'intrusion
        /// </summary>
        public const int RING_DURATION = 5;
        #endregion

        #region Properties
        /// <summary>
        /// Affecte ou obtient l'horodatage de la dernière intrusion
        /// </summary>
        public DateTime? IntrusionDetectedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsRinging
        {
            get
            {
                if(!this.IntrusionDetectedAt.HasValue)
                    return false;
                else
                {
                    // Vaudra vrai si l'alarme sonne depuis moins de 5 minutes
                    return DateTime.Now.Subtract(this.IntrusionDetectedAt.Value).TotalMinutes <= RING_DURATION;
                }
            }
        }
        #endregion
    }
}
