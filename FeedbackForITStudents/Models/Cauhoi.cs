﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel.DataAnnotations;

    public partial class CAUHOI
    {
        public int MaCH { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập nội dung câu hỏi")]
        public string Noidung { get; set; }
        public bool Andanh { get; set; }
        public System.DateTime Thoigian { get; set; }
        public string Email { get; set; }
        public string MaTKAsp { get; set; }
        public bool pin { get; set; }
        public Nullable<int> MaCD { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual CHUDE CHUDE { get; set; }
    }
}
