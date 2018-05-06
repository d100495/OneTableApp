namespace API.Models.MsSqlModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Workers
    {
        [Key]
        public int IdWorker { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        public int Age { get; set; }

        public decimal Payment { get; set; }

        [Required]
        [StringLength(50)]
        public string Office { get; set; }

        public int Pesel { get; set; }
    }
}
