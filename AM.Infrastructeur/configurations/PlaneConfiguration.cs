using AM.Applactioncore.Domaine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructeur.Configurations
{
    // Méthode de configuration qui configure les propriétés et relations de l'entité Plane.

    public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {

            // Définition de la clé primaire de l'entité Plane, ici PlaneId.
            builder.HasKey(p => p.PlaneId);

            // Définition du nom de la table dans la base de données où les données de Plane seront stockées.
            builder.ToTable("MyPlanes");

            // Configuration de la propriété Capacity de l'entité Plane pour lui donner un nom personnalisé dans la base de données.
            builder.Property(p => p.Capacity).HasColumnName("PlanCapacity");
        }
    }
}
