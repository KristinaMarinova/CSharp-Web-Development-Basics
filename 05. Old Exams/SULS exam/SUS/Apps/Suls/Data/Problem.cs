using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Suls.Data
{
    public class Problem
    {
        public Problem()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Submissions = new HashSet<Submissions>();
        }

        public string Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public ushort Points { get; set; }
        public ICollection<Submissions> Submissions { get; set; }

    }
}
