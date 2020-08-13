using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Public;
using SubSonic;

namespace BLL
{
   public class LopBLL
    {
        public static Lop InsertFile(Lop item)
        {
            return new LopController().Insert(item);
        }
        public static Lop UpDateFile(Lop item)
        {
            return new LopController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new LopController().Delete(id);
        }
        public static Lop GwtById(object id)
        {
            return new Select().From(Lop.Schema.TableName).Where(Lop.Columns.IdLop).IsEqualTo(id).ExecuteSingle<Lop>();
        }
        public static List<Lop> GetListLop()
        {
            string sql = @"select  l .*, kh.TenKhoaHoc
            from Lop as l join KhoaHoc as kh on l.IdKhoaHoc = kh.IdKhoaHoc ORDER BY l.TenLop ASC";
            return new InlineQuery().ExecuteTypedList<Lop>(sql);

        }
        //lớp đang mở
        public static List<Lop> GetListLop_DM()
        {
            string sql = @"select  l .*, kh.TenKhoaHoc
            from Lop as l join KhoaHoc as kh on l.IdKhoaHoc = kh.IdKhoaHoc where l.TrangThai like N'Đang Mở' ORDER BY l.TenLop ASC";
            return new InlineQuery().ExecuteTypedList<Lop>(sql);

        }
        //
        public static List<Lop> GetListLopSM()
        {
            string sql = @"select  l .*, kh.TenKhoaHoc
            from Lop as l join KhoaHoc as kh on l.IdKhoaHoc = kh.IdKhoaHoc where l.TrangThai like N'Sắp Mở' ORDER BY l.TenLop ASC";
            return new InlineQuery().ExecuteTypedList<Lop>(sql);

        }
        public static List<Lop> GetListLopDiemDanh(string idlop)
        {
            string sql = @"select  l .*, kh.TenKhoaHoc
            from Lop as l join KhoaHoc as kh on l.IdKhoaHoc = kh.IdKhoaHoc where l.IdLop='"+idlop+"' ORDER BY l.TenLop ASC";
            return new InlineQuery().ExecuteTypedList<Lop>(sql);

        }
        public static List<Lop> SearchList(string textSearch)
        {
            string sql = @"select  l .*, kh.TenKhoaHoc
            from Lop as l join KhoaHoc as kh on l.IdKhoaHoc = kh.IdKhoaHoc ";


            sql += " WHERE l.TrangThai Like N'%" + textSearch + "%'  or l.TenLop Like N'%" + textSearch + "%'  or kh.TenKhoaHoc Like N'%" + textSearch + "%'  ";


            return new InlineQuery().ExecuteTypedList<Lop>(sql);
        }
        // tổng lớp 

        public static List<Lop> TongLop()
        {
            string sql = @"select COUNT(*) as Tong from Lop ";


            return new InlineQuery().ExecuteTypedList<Lop>(sql);
        }
    }
}
