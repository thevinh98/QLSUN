using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public;
using SubSonic;

namespace BLL
{
   public class ThongBaoLopBLL
    {
        public static ThongBaoLop InsertFile(ThongBaoLop item)
        {
            return new ThongBaoLopController().Insert(item);
        }
        public static ThongBaoLop UpDateFile(ThongBaoLop item)
        {
            return new ThongBaoLopController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new ThongBaoLopController().Delete(id);
        }
        public static ThongBaoLop GwtById(object id)
        {
            return new Select().From(ThongBaoLop.Schema.TableName).Where(ThongBaoLop.Columns.Id).IsEqualTo(id).ExecuteSingle<ThongBaoLop>();
        }
        public static List<ThongBaoLop> GetListThongBaoLop()
        {
            string sql = @"select tbl .*, l.TenLop from ThongBaoLop as tbl join Lop  as l on l.IdLop=tbl.IdLop order by tbl.ThoiGian desc";
            return new InlineQuery().ExecuteTypedList<ThongBaoLop>(sql);

        }
        //thong báo hôm nay
        public static List<ThongBaoLop> GetListThongBaoLophomnay(string time)
        {
            string sql = @"select tbl .*, l.TenLop from ThongBaoLop as tbl join Lop  as l on l.IdLop=tbl.IdLop where tbl.ThoiGian='"+time+"' order by tbl.ThoiGian desc";
            return new InlineQuery().ExecuteTypedList<ThongBaoLop>(sql);

        }
        public static List<ThongBaoLop> SearchListhomnay(string time,string textSearch)
        {
            string sql = @"select tbl .*, l.TenLop from ThongBaoLop as tbl join Lop  as l on l.IdLop=tbl.IdLop ";


            sql += " WHERE tbl.ThoiGian='" + time + "' and (tbl.TieuDe Like N'%" + textSearch + "%' or tbl.NoiDung Like N'%" + textSearch + "%' or l.TenLop Like N'%" + textSearch + "%' or tbl.TrangThai Like N'%" + textSearch + "%')  order by tbl.ThoiGian desc  ";


            return new InlineQuery().ExecuteTypedList<ThongBaoLop>(sql);
        }
        //thong bao
        public static List<ThongBaoLop> ThongBao(string id)
        {
            string sql = @"select tbl .*, l.TenLop from ThongBaoLop as tbl join Lop  as l on l.IdLop=tbl.IdLop where l.IdLop='"+ id +"' and tbl.TrangThai like N'Hiện' order by tbl.ThoiGian desc";
            return new InlineQuery().ExecuteTypedList<ThongBaoLop>(sql);

        }
        public static List<ThongBaoLop> SearchList(string textSearch)
        {
            string sql = @"select tbl .*, l.TenLop from ThongBaoLop as tbl join Lop  as l on l.IdLop=tbl.IdLop ";


            sql += " WHERE tbl.TieuDe Like N'%" + textSearch + "%' or tbl.NoiDung Like N'%" + textSearch + "%' or l.TenLop Like N'%" + textSearch + "%' or tbl.TrangThai Like N'%" + textSearch + "%' order by tbl.ThoiGian desc  ";


            return new InlineQuery().ExecuteTypedList<ThongBaoLop>(sql);
        }
        // đem học phí
        public static List<ThongBaoLop> DemThongBao(string time)
        {
            string sql = @"SELECT COUNT(*) as DemTB
            FROM ThongBaoLop
            WHERE ThoiGian = '" + time + "' ";
            return new InlineQuery().ExecuteTypedList<ThongBaoLop>(sql);


        }
    }
}
