namespace ProjektWojsko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HISTORIA_NAPRAW
    {

        public HISTORIA_NAPRAW()
        {
        }
        public HISTORIA_NAPRAW(int ID, DateTime OD_KIEDY, int ID_POJAZD, int ID_PRZEGLAD)
        {
            this.ID = ID;
            this.OD_KIEDY = OD_KIEDY;
            this.ID_POJAZD = ID_POJAZD;
            this.ID_PRZEGLAD = ID_PRZEGLAD;
        }

        public HISTORIA_NAPRAW(int ID, DateTime DO_KIEDY)
        {
            this.ID = ID;
            this.DO_KIEDY = DO_KIEDY;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime OD_KIEDY { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DO_KIEDY { get; set; }

        public int ID_POJAZD { get; set; }

        public int ID_PRZEGLAD { get; set; }

        public virtual POJAZD POJAZD { get; set; }

        public virtual PRZEGLAD PRZEGLAD { get; set; }
    }
}
