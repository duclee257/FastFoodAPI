//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FastFoodAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DonHang
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string TinhTrang { get; set; }
        public Nullable<int> Phiship { get; set; }
        public Nullable<int> TongTien { get; set; }
    
        public virtual ChiTietDonHang ChiTietDonHang { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
    }
}
