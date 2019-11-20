using Domain.Abstract;
using System;

namespace Domain.Entities
{
    public class RefreshToken : IBaseEntity
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public DateTime ValidTime { get; set; }
        public string IpAddress { get; set; }
    }
}
