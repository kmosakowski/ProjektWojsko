namespace ProjektWojsko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SPRZET_WOJSKOWY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SPRZET_WOJSKOWY()
        {
            HISTORIA_SPRZETU = new HashSet<HISTORIA_SPRZETU>();
            MISJA_SPRZET_WOJSKOWY = new HashSet<MISJA_SPRZET_WOJSKOWY>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TYP { get; set; }

        public int NUMER { get; set; }

        [Column(TypeName = "date")]
        public DateTime ROK_PRODUKCJI { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DATA_UZYWALNOSCI { get; set; }

        [StringLength(500)]
        public string CZESCI_ZAMIENNE { get; set; }

        [StringLength(500)]
        public string DODATKOWE_WYPOSAZENIE { get; set; }

        [StringLength(500)]
        public string DODATKOWE_INFORMACJE { get; set; }

        public int ID_JEDNOSTKA_ORGANIZACYJNA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIA_SPRZETU> HISTORIA_SPRZETU { get; set; }

        public virtual JEDNOSTKA_ORGANIZACYJNA JEDNOSTKA_ORGANIZACYJNA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MISJA_SPRZET_WOJSKOWY> MISJA_SPRZET_WOJSKOWY { get; set; }
    }
}
