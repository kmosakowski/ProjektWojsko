namespace ProjektWojsko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class JEDNOSTKA_WOJSKOWA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JEDNOSTKA_WOJSKOWA()
        {
            JEDNOSTKA_ORGANIZACYJNA = new HashSet<JEDNOSTKA_ORGANIZACYJNA>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string RODZAJ { get; set; }

        [Required]
        [StringLength(50)]
        public string NAZWA { get; set; }

        [Required]
        [StringLength(50)]
        public string NUMER { get; set; }

        [Required]
        [StringLength(50)]
        public string PATRON { get; set; }

        public int? LICZBA_PODODZIALOW { get; set; }

        public int? LICZBA_CYWILI { get; set; }

        public int? LICZBA_ZOLNIERZY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JEDNOSTKA_ORGANIZACYJNA> JEDNOSTKA_ORGANIZACYJNA { get; set; }
    }
}
