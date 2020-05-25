namespace ProjektWojsko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HISTORIA_SPRZETU
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime OD_KIEDY { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DO_KIEDY { get; set; }

        public int ID_OSOBA { get; set; }

        public int ID_SPRZET_WOJSKOWY { get; set; }

        public virtual SPRZET_WOJSKOWY SPRZET_WOJSKOWY { get; set; }

        public virtual OSOBA OSOBA { get; set; }
    }
}
