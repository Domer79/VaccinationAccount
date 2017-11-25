using System.Data.Entity.ModelConfiguration;
using Contracts.Concrete;

namespace Dal.EntityConfiguration
{
    public class VaccinationConfiguration : EntityTypeConfiguration<Vaccination>
    {
        public VaccinationConfiguration()
        {
            HasKey(e => e.Id);
            Property(e => e.Preparation).IsRequired().IsUnicode();
            Property(e => e.Approval).IsRequired();
            Property(e => e.Date).IsRequired();
        }
    }
}