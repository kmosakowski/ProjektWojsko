namespace ProjektWojsko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("POJAZD")]
    public partial class POJAZD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public POJAZD()
        {
            HISTORIA_NAPRAW = new HashSet<HISTORIA_NAPRAW>();
        }

        public POJAZD(int ID, String NR_REJESTRACYJNY, DateTime ROK_PRODUKCJI, String CZY_SPECJALNY, String STATUS, int ID_OSOBA)
        {
            this.ID = ID;
            this.NR_REJESTRACYJNY = NR_REJESTRACYJNY;
            this.ROK_PRODUKCJI = ROK_PRODUKCJI;
            this.CZY_SPECJALNY = CZY_SPECJALNY;
            this.STATUS = STATUS;
            this.ID_OSOBA = ID_OSOBA;
        }

        public POJAZD(int ID, String NR_REJESTRACYJNY, DateTime ROK_PRODUKCJI, String CZY_SPECJALNY, String STATUS)
        {
            this.ID = ID;
            this.NR_REJESTRACYJNY = NR_REJESTRACYJNY;
            this.ROK_PRODUKCJI = ROK_PRODUKCJI;
            this.CZY_SPECJALNY = CZY_SPECJALNY;
            this.STATUS = STATUS;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string NR_REJESTRACYJNY { get; set; }

        [Column(TypeName = "date")]
        public DateTime ROK_PRODUKCJI { get; set; }

        [StringLength(1)]
        public string CZY_SPECJALNY { get; set; }

        [StringLength(50)]
        public string STATUS { get; set; }

        public int ID_OSOBA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIA_NAPRAW> HISTORIA_NAPRAW { get; set; }

        public virtual OSOBA OSOBA { get; set; }
    }
}
