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
   public class DotKiemTraBLL
    {
        public static DotKiemTra InsertFile(DotKiemTra item)
        {
            return new DotKiemTraController().Insert(item);
        }
        public static DotKiemTra UpDateFile(DotKiemTra item)
        {
            return new DotKiemTraController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new DotKiemTraController().Delete(id);
        }
        public static DotKiemTra GwtById(object id)
        {
            return new Select().From(DotKiemTra.Schema.TableName).Where(DotKiemTra.Columns.IdDotKiemTra).IsEqualTo(id).ExecuteSingle<DotKiemTra>();
        }
        public static List<DotKiemTra> GetListDotKiemTra()
        {
            string sql = @"select * from DotKiemTra ORDER BY Ten ASC";
            return new InlineQuery().ExecuteTypedList<DotKiemTra>(sql);

        }
        public static List<DotKiemTra> SearchList(string textSearch)
        {
            string sql = @"select * from DotKiemTra ";


            sql += " WHERE Ten Like N'%" + textSearch + "%' or GhiChu Like N'%" + textSearch + "%' ORDER BY Ten ASC  ";


            return new InlineQuery().ExecuteTypedList<DotKiemTra>(sql);
        }
    }
}
