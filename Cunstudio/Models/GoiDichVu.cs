//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cunstudio.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GoiDichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoiDichVu()
        {
            this.HopDongs = new HashSet<HopDong>();
        }
    
        public int Id_Goi { get; set; }
        public string TenGoi { get; set; }
        public string DiaDiem { get; set; }
        public string HoTro { get; set; }
        public Nullable<decimal> SoTam { get; set; }
        public Nullable<decimal> GiaTien { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDong> HopDongs { get; set; }
    }
}
