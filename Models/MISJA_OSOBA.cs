namespace ProjektWojsko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MISJA_OSOBA
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int ID_OSOBA { get; set; }

        public int ID_MISJA { get; set; }

        public virtual MISJA MISJA { get; set; }

        public virtual OSOBA OSOBA { get; set; }
    }
}
