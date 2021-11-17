using DRestaurantReservation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRestaurantReservation
{
   public class Class1  : EntityTypeConfiguration<TTableReservation>
{
    public Class1()
        {
           
            this.Property(m => m.NumberOfPersons)
                .HasColumnType("int");

            this.Property(m => m.TableId)
               .HasColumnType("int");



            this.Property(m => m.Name)
                .HasMaxLength(50);

            this.Property(m => m.ResDate)
                .IsRequired();


           

            // Table & column mappings
            this.ToTable("TTableReservation", "Restaurant");
            
            this.Property(m => m.Name).HasColumnName("Name");
            this.Property(m => m.NumberOfPersons).HasColumnName("NumberOfPersons");
            this.Property(m => m.ResDate).HasColumnName("ResDate");
            this.Property(m => m.TableId).HasColumnName("TableId");
         
        }

    }
}
