
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresTestApplication
{
    [Table("anagrafe")]
    public class Anagrafe
    {
        [Key]
        public string cod_fisc { get; set; }
        [Column(TypeName="Date")]
        public DateTime? data_nascita { get; set; }
        [Column(TypeName="Date")]
        public DateTime? data_decesso { get; set; }
        [Column(TypeName="Date")]
        public DateTime? data_inizio_assistenza { get; set; }
        [Column(TypeName="Date")]
        public DateTime? data_fine_assistenza { get; set; }
        [Column(TypeName="Date")]
        public DateTime? data_riferimento { get; set; }
        public string sesso { get; set; }
        public string stato_id { get; set; }
        public string comune_nascita { get; set; }
        public string comune_residenza { get; set; }
        public string codice_medico { get; set; }
        public string asl_assistenza { get; set; }
    }

}