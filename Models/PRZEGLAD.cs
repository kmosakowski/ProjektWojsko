namespace ProjektWojsko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRZEGLAD")]
    public partial class PRZEGLAD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRZEGLAD()
        {
            HISTORIA_NAPRAW = new HashSet<HISTORIA_NAPRAW>();
        }

        public PRZEGLAD(int ID, String WYKORZYSTANE_CZESCI)
        {
            this.ID = ID;
            this.WYKORZYSTANE_CZESCI = WYKORZYSTANE_CZESCI;
        }

        public PRZEGLAD(int ID)
        {
            this.ID = ID;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(500)]
        public string WYKORZYSTANE_CZESCI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIA_NAPRAW> HISTORIA_NAPRAW { get; set; }
    }
}
