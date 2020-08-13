using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public;
using SubSonic;

namespace BLL
{
   public class DotTuyenSinhBLL
    {
        public static DotTuyenSinh InsertFile(DotTuyenSinh item)
        {
            return new DotTuyenSinhController().Insert(item);
        }
        public static DotTuyenSinh UpDateFile(DotTuyenSinh item)
        {
            return new DotTuyenSinhController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new DotTuyenSinhController().Delete(id);
        }
        public static DotTuyenSinh GwtById(object id)
        {
            return new Select().From(DotTuyenSinh.Schema.TableName).Where(DotTuyenSinh.Columns.IdDotTuyenSinh).IsEqualTo(id).ExecuteSingle<DotTuyenSinh>();
        }
        public static List<DotTuyenSinh> GetListDotTuyenSinh()
        {
            string sql = @"select * from DotTuyenSinh ORDER BY ThoiGian DESC";
            return new InlineQuery().ExecuteTypedList<DotTuyenSinh>(sql);

        }
        public static List<DotTuyenSinh> SearchList(string textSearch)
        {
            string sql = @"select * from DotTuyenSinh  ";


            sql += " WHERE TenDotTuyenSinh Like N'%" + textSearch + "%' or TrangThai Like N'%" + textSearch + "%' or NoiDung Like N'%" + textSearch + "%' ORDER BY ThoiGian DESC ";


            return new InlineQuery().ExecuteTypedList<DotTuyenSinh>(sql);
        }
    }
}
