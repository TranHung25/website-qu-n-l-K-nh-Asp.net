//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quanly.Models.framework
{
    using System;
    using System.Collections.Generic;
    
    public partial class tintuc
    {
        public int baiviet_id { get; set; }
        public string tenbaiviet { get; set; }
        public string mota { get; set; }
        public Nullable<int> danhmuctin_id { get; set; }
        public string hinhanh { get; set; }
    
        public virtual danhmuc_tin danhmuc_tin { get; set; }
    }
}
