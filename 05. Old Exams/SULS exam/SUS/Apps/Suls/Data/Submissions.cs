using System;
using System.ComponentModel.DataAnnotations;

namespace Suls.Data
{
    public class Submissions
    {
        public Submissions()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        [Required]
        [MaxLength(800)]
        public string Code { get; set; }
        public ushort AchievedResult { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual User User { get; set; }
        public virtual Problem Problem { get; set; }
    }
}