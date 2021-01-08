//using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.ModelConfiguration;

//namespace APesquisa.Data.Models.Mapping
//{
//    public class MergeTableMap : EntityTypeConfiguration<MergeTable>
//    {
//        public MergeTableMap()
//        {
//            // Primary Key
//            HasKey(t => t.ID);

//            // Properties
//            Property(t => t.ID)
//                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

//            Property(t => t.Name)
//                .HasMaxLength(255)
//                .IsRequired();

//            Property(t => t.Type)
//                .HasMaxLength(255)
//                .IsRequired();

//            // Table & Column Mappings
//            ToTable("MergeTable");
//            Property(t => t.ID).HasColumnName("ID");
//            Property(t => t.Name).HasColumnName("Name");
//            Property(t => t.Type).HasColumnName("Type");
//            Property(t => t.AllowedNoPoo).HasColumnName("AllowedNoPoo");
//            Property(t => t.AllowedLowPoo).HasColumnName("AllowedLowPoo");
//            Property(t => t.Prohibited).HasColumnName("Prohibited");
//            Property(t => t.Vegan).HasColumnName("Vegan");
//            Property(t => t.MayBeVegan).HasColumnName("MayBeVegan");
//            Property(t => t.NonVegan).HasColumnName("NonVegan");
//        }
//    }
//}
