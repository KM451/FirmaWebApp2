﻿using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Model
{
    public class SposobDostawy
    {
        [Key]
        public int IdSposobuDostawy { get; set; }

        [Required]
        [Display(Name = "Nazwa")]
        public string Nazwa { get; set; }

        [Display(Name = "Uwagi")]
        public string? Uwagi { get; set; }

        [Display(Name = "Czy aktywny")]
        public bool CzyAktywny { get; set; }

        public virtual ICollection<ZlecenieZakupu>? ZlecenieZakupu { get; set; }
    }
}
