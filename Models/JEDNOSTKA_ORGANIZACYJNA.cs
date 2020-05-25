namespace ProjektWojsko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class JEDNOSTKA_ORGANIZACYJNA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JEDNOSTKA_ORGANIZACYJNA()
        {
            JEDNOSTKA_ORGANIZACYJNA1 = new HashSet<JEDNOSTKA_ORGANIZACYJNA>();
            OSOBA = new HashSet<OSOBA>();
            SPRZET_WOJSKOWY = new HashSet<SPRZET_WOJSKOWY>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string NAZWA { get; set; }

        [StringLength(1)]
        public string CZY_MAGAZYN { get; set; }

        public int? LICZBA_ZOLNIERZY { get; set; }

        public int ID_JEDNOSTKA_WOJSKOWA { get; set; }

        public int? ID_JEDNOSTKA_ORGANIZACYJNA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JEDNOSTKA_ORGANIZACYJNA> JEDNOSTKA_ORGANIZACYJNA1 { get; set; }

        public virtual JEDNOSTKA_ORGANIZACYJNA JEDNOSTKA_ORGANIZACYJNA2 { get; set; }

        public virtual JEDNOSTKA_WOJSKOWA JEDNOSTKA_WOJSKOWA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OSOBA> OSOBA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPRZET_WOJSKOWY> SPRZET_WOJSKOWY { get; set; }
    }
}
