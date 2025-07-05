using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorcycle_Emission_Inspection_Management.Common
{
    /// <summary>
    /// Lưu thông tin người dùng sau khi đăng nhập
    /// (dạng static – dùng được ở mọi nơi trong app).
    /// </summary>
    public static class UserSession
    {
        public static int UserId { get; set; }
        public static int? StationId { get; set; }   // nullable: Owner, Admin có thể null
        public static string Username { get; set; }
        public static string RoleName { get; set; }
    }
}

