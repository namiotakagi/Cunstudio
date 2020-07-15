using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cunstudio.Models
{
    public class AnhCuaKH
    {
        public int Id_KhachHang { get; set; }
        public string HinhAnh { get; set; }
        public AnhCuaKH(int idKH)
        {
            using (CunstudioEntities db = new CunstudioEntities())
            {
                this.Id_KhachHang = idKH;
                Anh a = db.Anhs.Single(n => n.ID_KhachHang == idKH);
                HinhAnh = a.HinhAnh;
            }
        }
        public AnhCuaKH()
        {

        }

    }
}