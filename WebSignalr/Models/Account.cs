namespace WebSignalr.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [StringLength(100)]
        public string AccountID { get; set; }

        [StringLength(50)]
        public string Account_Name { get; set; }

        [StringLength(100)]
        public string Account_Email { get; set; }

        [StringLength(200)]
        public string Account_Pass { get; set; }

        [StringLength(100)]
        public string Account_IDAPI { get; set; }

        public DateTime? Account_DateCreate { get; set; }

        [StringLength(200)]
        public string Account_Code { get; set; }

        public bool? Account_IsOnline { get; set; }

        [Column(TypeName = "text")]
        public string Account_TokenApi { get; set; }

        [StringLength(100)]
        public string Account_oauth_provider { get; set; }
    }
}
