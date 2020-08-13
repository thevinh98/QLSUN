using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public;
using SubSonic;

namespace BLL
{
   public class ChucVuBLL
    {
        public static ChucVu InsertFile(ChucVu item)
        {
            return new  ChucVuController().Insert(item);
        }
        public static ChucVu UpDateFile(ChucVu item)
        {
            return new ChucVuController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new ChucVuController().Delete(id);
        }
        public static ChucVu GwtById(object id)
        {
            return new Select().From(ChucVu.Schema.TableName).Where(ChucVu.Columns.IdChucVu).IsEqualTo(id).ExecuteSingle<ChucVu>();
        }
        public static List<ChucVu> GetListChucVu()
        {
            string sql = @"select * from ChucVu ORDER BY TenChucVu ASC";
            return new InlineQuery().ExecuteTypedList<ChucVu>(sql);
           
        }
        public static List<ChucVu> SearchList(string textSearch)
        {
            string sql = @"select * from ChucVu ";


            sql += " WHERE TenChucVu Like N'%" + textSearch + "%' or LuongThang Like N'%" + textSearch + "%' ORDER BY TenChucVu ASC  ";
         

            return new InlineQuery().ExecuteTypedList<ChucVu>(sql);
        }
    }
}
