using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cunstudio.Models
{
    [MetadataTypeAttribute(typeof(KhachHangMetaData))]
    public partial class KhachHang
    {
        internal sealed class KhachHangMetaData
        {
            public int Id_KhachHang { get; set; }
            [DisplayName("Họ và tên khách hàng")]
            [Required(ErrorMessage = "{0} không được để trống")]
            public string Ten { get; set; }
            [DisplayName("Số điện thoại")]
            [Required(ErrorMessage = "{0} không được để trống")]
            [StringLength(10, ErrorMessage = "Không quá 10 số")]
            public Nullable<int> SDT { get; set; }
            [DisplayName("Email")]
            [Required(ErrorMessage = "{0} không được để trống")]
            [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z09!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z09-]*[a-z0-9])?)\Z", ErrorMessage = "Email không hợp lệ!")]
            public string Email { get; set; }
            [DisplayName("Địa chỉ")]
            [Required(ErrorMessage = "{0} không được để trống")]
            public string DiaChi { get; set; }
            [DisplayName("Tài khoản")]
            [Required(ErrorMessage = "{0} không được để trống")]
            public string TaiKhoan { get; set; }
            [DisplayName("Mật khẩu")]
            [Required(ErrorMessage = "{0} không được để trống")]
            [StringLength(10, ErrorMessage = "Không quá 9 ký tự")]
            public string MatKhau { get; set; }
            //[DisplayName("Nhập lại mật khẩu")]
            //[Compare("MatKhau", ErrorMessage = "Mật khẩu không đúng")]
            //public string NLMatKhau { get; set; }
        }
    }
}