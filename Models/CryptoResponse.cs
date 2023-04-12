using System;

namespace CryptoAPI.Models
{
    public class CryptoResponse
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
