using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyHome.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Infrastructure.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User)); // Nom de la future table
            builder.HasKey(x => x.Id); // On indique la clé primaire
            // Le champ FirstName est requis, sa longueur max est de 50 car.
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(125);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(50);

            // Création d'un index, ayant la contrainte d'unicité
            // comme défini dans le hashcode du type User
            builder.HasIndex(x => new { x.Email }).IsUnique();

            // Initialisation de la table avec des données
            builder.HasData(new User() {
                Id = 1,
                FirstName = "Cédric",
                LastName = "Daniel",
                Email = "cedric.daniel@simphonis.com",
                Password = "toto" });
        }
    }
}
