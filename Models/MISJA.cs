namespace ProjektWojsko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MISJA")]
    public partial class MISJA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MISJA()
        {
            MISJA_OSOBA = new HashSet<MISJA_OSOBA>();
            MISJA_SPRZET_WOJSKOWY = new HashSet<MISJA_SPRZET_WOJSKOWY>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string KRYPTONIM { get; set; }

        [StringLength(500)]
        public string OPIS { get; set; }

        public int? LICZBA_ZOLNIERZY { get; set; }

        public int? LICZBA_SPRZETU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MISJA_OSOBA> MISJA_OSOBA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MISJA_SPRZET_WOJSKOWY> MISJA_SPRZET_WOJSKOWY { get; set; }
    }
}
