using Framework.Core;

namespace Data.Entity
{
    public class Account : BaseEntity
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
