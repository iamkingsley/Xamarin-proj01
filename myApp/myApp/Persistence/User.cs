using System;
using SQLite;


namespace myApp.Persistence
{
    //[Table("Users")]
    class User
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [Unique, MaxLength(255)]
        public String username { get; set; }
        [MaxLength(255)]
        public String firstName { get; set; }
        [MaxLength(255)]
        public String lastName { get; set; }
        [MaxLength(20)]
        public String password { get; set; }
        [MaxLength(10)]
        public String phone { get; set; }
        public int region { get; set; }
    }
}
