//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FeedbackForITStudents.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TRALOI
    {
        public int MaCTL { get; set; }
        public string Noidungtraloi { get; set; }
        public System.DateTime Thoigian { get; set; }
        public int MaTK { get; set; }
        public int Luottim { get; set; }
        public int MaCHD { get; set; }
    
        public virtual TAIKHOAN TAIKHOAN { get; set; }
        public virtual CAUHOIDADUYET CAUHOIDADUYET { get; set; }
    }
}
