using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public;
using SubSonic;

namespace BLL
{
   public class PhongHocBLL
    {
        public static PhongHoc InsertFile(PhongHoc item)
        {
            return new PhongHocController().Insert(item);
        }
        public static PhongHoc UpDateFile(PhongHoc item)
        {
            return new PhongHocController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new PhongHocController().Delete(id);
        }
        public static PhongHoc GwtById(object id)
        {
            return new Select().From(PhongHoc.Schema.TableName).Where(PhongHoc.Columns.IdPhongHoc).IsEqualTo(id).ExecuteSingle<PhongHoc>();
        }
        public static List<PhongHoc> GetListPhongHoc()
        {
            string sql = @"select * from PhongHoc ORDER BY SoPhong ASC";
            return new InlineQuery().ExecuteTypedList<PhongHoc>(sql);

        }
        public static List<PhongHoc> GetListPhongHocHD()
        {
            string sql = @"select * from PhongHoc where PhongHoc.TrangThai like N'Hoạt Động' ORDER BY SoPhong ASC";
            return new InlineQuery().ExecuteTypedList<PhongHoc>(sql);

        }
        public static List<PhongHoc> SearchList(string textSearch)
        {
            string sql = @"select * from PhongHoc ";


            sql += " WHERE SoPhong Like N'%" + textSearch + "%' or GhiChu Like N'%" + textSearch + "%' or TrangThai Like N'%" + textSearch + "%' ORDER BY SoPhong ASC  ";


            return new InlineQuery().ExecuteTypedList<PhongHoc>(sql);
        }
    }
}
