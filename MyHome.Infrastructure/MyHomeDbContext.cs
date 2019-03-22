using Microsoft.EntityFrameworkCore;
using MyHome.Infrastructure.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Infrastructure
{
    public class MyHomeDbContext : DbContext
    {
        /// <summary>
        /// Constructeur du contexte d'accès à la base de données
        /// </summary>
        /// <param name="options">Options de la bbd, ex: chaine de connexion</param>
        public MyHomeDbContext(DbContextOptions<MyHomeDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // On indique à EF de mapper l'objet User en base de données
            // Permet la prise en compte du map en BDD
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
