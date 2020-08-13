using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public;
using SubSonic;

namespace BLL
{
   public class HocVienBLL
    {
        public static HocVien InsertFile(HocVien item)
        {
            return new HocVienController().Insert(item);
        }
        public static HocVien UpDateFile(HocVien item)
        {
            return new HocVienController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new HocVienController().Delete(id);
        }
        public static HocVien GwtById(object id)
        {
            return new Select().From(HocVien.Schema.TableName).Where(HocVien.Columns.IdHocVien).IsEqualTo(id).ExecuteSingle<HocVien>();
        }
        public static List<HocVien> GetListHocVien()
        {
            string sql = @"select HocVien .*,HocVien.Sdt from HocVien ORDER BY HoTen ASC";
            return new InlineQuery().ExecuteTypedList<HocVien>(sql);
            // return new Select().From(HocVien.Schema.TableName).OrderAsc(HocVien.Columns.HoTen).ExecuteTypedList<HocVien>();
        }
        //thông tin học viên
        public static List<HocVien> GetListThongTinHocVien(string id)
        {
            string sql = @"select HocVien .*,HocVien.Sdt from HocVien where IdHocVien='"+id+"'";
            return new InlineQuery().ExecuteTypedList<HocVien>(sql);
            // return new Select().From(HocVien.Schema.TableName).OrderAsc(HocVien.Columns.HoTen).ExecuteTypedList<HocVien>();
        }
        public static List<HocVien> GetListHocVienTS()
        {
            string sql = @"select HocVien .*,HocVien.Sdt from HocVien where TrangThai like N'Tuyển Sinh' ORDER BY HoTen ASC";
            return new InlineQuery().ExecuteTypedList<HocVien>(sql);
            // return new Select().From(HocVien.Schema.TableName).OrderAsc(HocVien.Columns.HoTen).ExecuteTypedList<HocVien>();
        }
        public static List<HocVien> GetListHocVienNH()
        {
            string sql = @"select HocVien .*,HocVien.Sdt from HocVien where TrangThai like N'Nhập Học' ORDER BY HoTen ASC";
            return new InlineQuery().ExecuteTypedList<HocVien>(sql);
            // return new Select().From(HocVien.Schema.TableName).OrderAsc(HocVien.Columns.HoTen).ExecuteTypedList<HocVien>();
        }
        public static List<HocVien> SearchList(string textSearch)
        {
            string sql = @"select HocVien . *,HocVien.Sdt from HocVien ";


            sql += " WHERE HoTen Like N'%" + textSearch + "%' or NamSinh Like N'%" + textSearch + "%' or DiaChi Like N'%" + textSearch + "%' or FaceBook Like N'%" + textSearch + "%' or Email Like N'%" + textSearch + "%' ORDER BY HoTen ASC  ";


            return new InlineQuery().ExecuteTypedList<HocVien>(sql);
        }
        // tổng lớp 

        public static List<HocVien> TongHocVien()
        {
            string sql = @"select COUNT(*) as Tong from HocVien ";


            return new InlineQuery().ExecuteTypedList<HocVien>(sql);
        }
    }
}
