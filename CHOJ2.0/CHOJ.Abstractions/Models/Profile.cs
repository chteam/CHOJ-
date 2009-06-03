using System;

namespace CHOJ.Models
{
    public class Profile
    {
        public Guid Id { get; set; }
        public string LiveId { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string School { get; set; }
        public string SchoolDetails { get; set; }
        public int Submit { get; set; }
        public int Accepted { get; set; }
        public DateTime RegisterTime { get; set; }
        public DateTime LogOnTime { get; set; }
    }
}