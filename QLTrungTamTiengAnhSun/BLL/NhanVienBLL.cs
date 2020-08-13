using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public;
using System.Data;
using SubSonic;
namespace BLL
{
    public class NhanVienBLL
    {
        public static NhanVien InsertFile(NhanVien item)
        {
            return new NhanVienController().Insert(item);
        }
        public static NhanVien UpDateFile(NhanVien item)
        {
            return new NhanVienController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new NhanVienController().Delete(id);
        }
        public static NhanVien GwtById(object id)
        {
            return new Select().From(NhanVien.Schema.TableName).Where(NhanVien.Columns.Id).IsEqualTo(id).ExecuteSingle<NhanVien>();
        }
        public static List<NhanVien> GetListNhanVien()
        {
           
            string sql = @"select nv.* ,nv.Sdt,cv.TenChucVu,cv.LuongThang
            from NhanVien as nv join ChucVu as cv on nv.IdChucVu =cv.IdChucVu ORDER BY NgayVaoLam DESC ";
            return new InlineQuery().ExecuteTypedList<NhanVien>(sql);
        }
        public static List<NhanVien> GetListNhanVienOne(string id)
        {

            string sql = @"select nv.* ,nv.Sdt,cv.TenChucVu,cv.LuongThang
            from NhanVien as nv join ChucVu as cv on nv.IdChucVu =cv.IdChucVu  where nv.Id='"+id+"' ";
            return new InlineQuery().ExecuteTypedList<NhanVien>(sql);
        }
        public static List<NhanVien> SearchList(string textSearch)
        {
            //            string sql = @"select nv.*, cv.TenChucVu,cv.LuongThang
            //from NhanVien as nv join ChucVu as cv on nv.IdChucVu =cv.IdChucVu ";
            string sql = @"select nv.*  , cv.TenChucVu,cv.LuongThang
            from NhanVien as nv join ChucVu as cv on nv.IdChucVu =cv.IdChucVu";

            sql += " WHERE nv.HoTen Like N'%" + textSearch + "%' or nv.DiaChi Like N'%" + textSearch + "%' or nv.Email Like N'%" + textSearch + "%' or nv.TrangThai Like N'%" + textSearch + "%' or cv.TenChucVu Like N'%" + textSearch + "%' ORDER BY NgayVaoLam DESC ";


            return new InlineQuery().ExecuteTypedList<NhanVien>(sql);
        }
        // tổng lớp 

        public static List<NhanVien> TongNhanVien()
        {
            string sql = @"select COUNT(*) as Tong from NhanVien ";


            return new InlineQuery().ExecuteTypedList<NhanVien>(sql);
        }
    }
}
