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
    
    public partial class TRANGCHU
    {
        public string MaTC { get; set; }
        public Nullable<int> MaTK { get; set; }
        public string MaCH { get; set; }
        public Nullable<bool> Thatim { get; set; }
        public string MaCTL { get; set; }
        public string EMAIL { get; set; }
    
        public virtual TAIKHOAN TAIKHOAN { get; set; }
        public virtual TAIKHOANSV TAIKHOANSV { get; set; }
    }
}
