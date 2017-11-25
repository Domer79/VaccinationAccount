using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Concrete;

namespace Dal.EntityConfiguration
{
    class PatientConfiguration: EntityTypeConfiguration<Patient>
    {
        public PatientConfiguration()
        {
            HasKey(e => e.Id);
            Property(e => e.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(200)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Patient_Name_LastName_MiddleName") {Order = 1}));

            Property(e => e.LastName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(200)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Patient_Name_LastName_MiddleName") {Order = 2}));
            ;
            Property(e => e.MiddleName)
                .IsUnicode()
                .HasMaxLength(200)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Patient_Name_LastName_MiddleName") {Order = 3}));
            ;
            Property(e => e.BirthDate).IsRequired();
            Property(e => e.Gender).IsRequired().IsUnicode();
            Property(e => e.Snils).IsRequired().IsUnicode().HasMaxLength(20).HasColumnAnnotation("Index",
                new IndexAnnotation(new IndexAttribute("IX_Patient_Snils")));
            ;
        }
    }
}
