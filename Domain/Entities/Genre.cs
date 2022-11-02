using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPApp.Domain.Entities
{
    public class Genre : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
