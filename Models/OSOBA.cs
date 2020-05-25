namespace ProjektWojsko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OSOBA")]
    public partial class OSOBA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OSOBA()
        {
            HISTORIA_SPRZETU = new HashSet<HISTORIA_SPRZETU>();
            MISJA_OSOBA = new HashSet<MISJA_OSOBA>();
            OSOBA1 = new HashSet<OSOBA>();
            POJAZD = new HashSet<POJAZD>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string IMIE { get; set; }

        [Required]
        [StringLength(50)]
        public string NAZWISKO { get; set; }

        [Required]
        [StringLength(11)]
        public string PESEL { get; set; }

        [Required]
        [StringLength(50)]
        public string IMIE_OJCA { get; set; }

        [StringLength(150)]
        public string NR_TELEFONU { get; set; }

        [Required]
        [StringLength(50)]
        public string STANOWISKO { get; set; }

        public int WYNAGRODZENIE { get; set; }

        [Column(TypeName = "date")]
        public DateTime DATA_ZATRUDNIENIA { get; set; }

        [Column(TypeName = "date")]
        public DateTime? STAZ_PRACY { get; set; }

        [Required]
        [StringLength(50)]
        public string FUNKCJA { get; set; }

        [StringLength(50)]
        public string STOPIEN { get; set; }

        [StringLength(1)]
        public string CZY_PRZELOZONY { get; set; }

        [StringLength(500)]
        public string ODBYTE_KURSY { get; set; }

        public int? DODATEK_MIESZKANIOWY { get; set; }

        public int? ID_JEDNOSTKA_ORGANIZACYJNA { get; set; }

        public int? ID_OSOBA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIA_SPRZETU> HISTORIA_SPRZETU { get; set; }

        public virtual JEDNOSTKA_ORGANIZACYJNA JEDNOSTKA_ORGANIZACYJNA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MISJA_OSOBA> MISJA_OSOBA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OSOBA> OSOBA1 { get; set; }

        public virtual OSOBA OSOBA2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POJAZD> POJAZD { get; set; }
    }
}
