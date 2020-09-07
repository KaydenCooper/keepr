namespace Keepr.Models
{
    public class VaultKeep
    {
        public int Id { get; set; }
        public int VaultId { get; set; }
        public string KeepId { get; set; }

        public string UserId { get; set; }

    }
}