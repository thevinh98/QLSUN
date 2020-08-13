using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubSonic;
using Public;

namespace BLL
{
  public  class ThuChiBLL
    {
        public static ThuChi InsertFile(ThuChi item)
        {
            return new ThuChiController().Insert(item);
        }
        public static ThuChi UpDateFile(ThuChi item)
        {
            return new ThuChiController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new ThuChiController().Delete(id);
        }
        public static ThuChi GwtById(object id)
        {
            return new Select().From(ThuChi.Schema.TableName).Where(ThuChi.Columns.Id).IsEqualTo(id).ExecuteSingle<ThuChi>();
        }
        public static List<ThuChi> GetListThuChi()
        {
            string sql = @"select * from ThuChi ORDER BY ThoiGian DESC";
            return new InlineQuery().ExecuteTypedList<ThuChi>(sql);

        }
        public static List<ThuChi> SearchList(string textSearch)
        {
            string sql = @"select * from ThuChi";


            sql += " WHERE TenKhoanChi Like N'%" + textSearch + "%' or SoTien Like N'%" + textSearch + "%' or NoiDung Like N'%" + textSearch + "%' or ThoiGian Like N'%" + textSearch + "%' ORDER BY ThoiGian ASC  ";


            return new InlineQuery().ExecuteTypedList<ThuChi>(sql);
        }
        //thống kê
        public static List<ThuChi> ThongKeThuChi(string time1, string time2)
        {
            string sql = @" select Sum(SoTien) as TongTien
			  from ThuChi
			  where ThoiGian BETWEEN '"+time1+"' AND '"+time2+"'";
            return new InlineQuery().ExecuteTypedList<ThuChi>(sql);
        }
    }
}
