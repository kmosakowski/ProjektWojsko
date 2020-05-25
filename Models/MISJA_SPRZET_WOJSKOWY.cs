namespace ProjektWojsko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MISJA_SPRZET_WOJSKOWY
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int MISJA_ID { get; set; }

        public int SPRZET_WOJSKOWY_ID { get; set; }

        public virtual MISJA MISJA { get; set; }

        public virtual SPRZET_WOJSKOWY SPRZET_WOJSKOWY { get; set; }
    }
}
