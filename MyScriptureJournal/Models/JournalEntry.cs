using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyScriptureJournal.Models
{
    public class JournalEntry
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Book name cannot be longer than 50 characters.")]
        public string Book { get; set; }

        
        public int Chapter { get; set; }
      

        public int Verse { get; set; }

        [Required]
        public string Note { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Added")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }

    }
}
