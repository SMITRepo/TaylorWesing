using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;

namespace TaylorWessing.Persistence.Entities
{
    public class APIAudit
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }

        public string Data { get; set; }

        public DateTime DateCreated { get; set; }

    }
}