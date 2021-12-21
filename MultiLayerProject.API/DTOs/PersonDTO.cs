using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MultiLayerProject.API.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı boş olamaz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} alanı boş olamaz.")]
        public string Surname { get; set; }
    }
}
