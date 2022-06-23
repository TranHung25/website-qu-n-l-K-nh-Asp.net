using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Quanly.Areas.Admin.model.DTO
{
    public class account
    {
        [Required(ErrorMessage = "Tài khoản là bắt buộc!")]
        public string username { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc!")]
        [DataType(DataType.Password, ErrorMessage = "Mật khẩu")]
        public string password { get; set; }
    }
}