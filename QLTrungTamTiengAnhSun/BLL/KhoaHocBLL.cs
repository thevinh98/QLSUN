using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public;
using SubSonic;

namespace BLL
{
   public class KhoaHocBLL
    {
        public static KhoaHoc InsertFile(KhoaHoc item)
        {
            return new KhoaHocController().Insert(item);
        }
        public static KhoaHoc UpDateFile(KhoaHoc item)
        {
            return new KhoaHocController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new KhoaHocController().Delete(id);
        }
        public static KhoaHoc GwtById(object id)
        {
            return new Select().From(KhoaHoc.Schema.TableName).Where(KhoaHoc.Columns.IdKhoaHoc).IsEqualTo(id).ExecuteSingle<KhoaHoc>();
        }
        public static List<KhoaHoc> GetListKhoaHoc()
        {
            string sql = @"select * from KhoaHoc ORDER BY TenKhoaHoc ASC";
            return new InlineQuery().ExecuteTypedList<KhoaHoc>(sql);

        }
        public static List<KhoaHoc> GetListKhoaHocMo()
        {
            string sql = @"select * from KhoaHoc where KhoaHoc.TrangThai like N'Đang Mở' ORDER BY TenKhoaHoc ASC";
            return new InlineQuery().ExecuteTypedList<KhoaHoc>(sql);

        }
        public static List<KhoaHoc> SearchList(string textSearch)
        {
            string sql = @"select * from KhoaHoc ";


            sql += " WHERE TenKhoaHoc Like N'%" + textSearch + "%' or TrangThai Like N'%" + textSearch + "%' ORDER BY TenKhoaHoc ASC  ";


            return new InlineQuery().ExecuteTypedList<KhoaHoc>(sql);
        }
    }
}
