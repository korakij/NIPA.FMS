using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MNG.Models.Productions
{
    public class TestChemInLadle
    {
        public TestChemInLadle()
        {
            Result = new ChemicalComposition();
            Validation = new ChemicalCompositionValidation();
        }

        [Key]
        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        public DateTime Time { get; set; }

        public virtual Product Product { get; set; }
        public int? ProductId { get; set; }

        public ChemicalComposition Result { get; set; }
        public ChemicalCompositionValidation Validation { get; set; }
        public bool IsCompleted { get; set; }

        public virtual Kanban Kanbans { get; set; }
        [Required]
        [StringLength(20)]
        public string KanbanCode { get; set; }
    }
}
