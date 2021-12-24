using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiLayerProject.Website.DTOs
{
    public class ErrorDTO
    {
        public List<String> Errors { get; set; }
        public int Status { get; set; }

        public ErrorDTO()
        {
            Errors = new List<string>();
        }
    }
}
