using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLyTV;
using System.Data;

namespace DAL_QuanLyTV
{
    public class DAL_DangNhap
    {

        /*============= ĐĂNG NHẬP =============*/
        //Kiểm tra tên tài khoản có trong CSDL không
        public bool checkTaiKhoan(string tentaikhoan)
        {
            string sql = "SELECT * FROM NGUOIDUNG WHERE Tendangnhap = @taikhoan";
            string name = "@taikhoan";
            return DataProvider.checkLogin(sql, name, tentaikhoan);
        }

        //Kiểm tra mật khẩu có trong CSDL không
        public bool checkMatKhau(string matkhau)
        {
            string sql = "SELECT MATKHAU FROM NGUOIDUNG WHERE Matkhau = @matkhau";
            string name = "@matkhau";
            return DataProvider.checkLogin(sql, name, matkhau);
        }

        /*============= ĐĂNG KÝ =============*/

        /// <summary>
        /// Thêm người dùng mới
        /// </summary>
        /// <param name="dk"></param>
        /// <returns></returns>
        public bool dangKy(DTO_DangNhap dk)
        {
            string sql = "INSERT INTO NGUOIDUNG VALUES (@taikhoan, @matkhau, 1, @gmail)";
            string[] name = { "@taikhoan", "@matkhau", "@gmail" };
            object[] value = { dk.TaiKhoan, dk.MatKhau, dk.Gmail };
            return DataProvider.updateData(sql, name, value);
        }

        /// <summary>
        /// Kiểm tra tên tài khoản đã có trong cơ sở dữ liệu hay chưa
        /// </summary>
        /// <param name="taikhoan"></param>
        /// <returns></returns>
        public int checkTenTaiKhoan(string taikhoan)
        {
            string sql = string.Format("SELECT COUNT(*) FROM NGUOIDUNG WHERE Tendangnhap='{0}'", taikhoan);
            return DataProvider.executeScalar(sql);
        }

        /*============= ĐỔI MẬT KHẨU =============*/
        /// <summary>
        /// Sửa mật khẩu
        /// </summary>
        /// <param name="matkhau"></param>
        /// <returns></returns>
        public bool doiMatKhau(DTO_DangNhap matkhau)
        {
            string sql = string.Format("UPDATE NGUOIDUNG SET MATKHAU = @matkhau WHERE Tendangnhap= '{0}'", matkhau.TaiKhoan);
            string[] name = { "@matkhau" };
            object[] value = { matkhau.MatKhau };
            return DataProvider.updateData(sql, name, value);
        }
       

    }
}
