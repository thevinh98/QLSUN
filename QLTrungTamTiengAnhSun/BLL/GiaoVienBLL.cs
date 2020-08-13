using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubSonic;
using Public;

namespace BLL
{
    public class GiaoVienBLL
    {
        public static GiaoVien InsertFile(GiaoVien item)
        {
            return new GiaoVienController().Insert(item);
        }
        public static GiaoVien UpDateFile(GiaoVien item)
        {
            return new GiaoVienController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new GiaoVienController().Delete(id);
        }
        public static GiaoVien GwtById(object id)
        {
            return new Select().From(GiaoVien.Schema.TableName).Where(GiaoVien.Columns.IdGiaoVien).IsEqualTo(id).ExecuteSingle<GiaoVien>();
        }
        public static List<GiaoVien> GetListGiaoVien()
        {
            string sql = @"select GiaoVien .*,GiaoVien.Sdt from GiaoVien ORDER BY NgayVaoLam DESC";
            return new InlineQuery().ExecuteTypedList<GiaoVien>(sql);

        }
        public static List<GiaoVien> GetListGiaoVienDL()
        {
            string sql = @"select GiaoVien .*,GiaoVien.Sdt from GiaoVien  ORDER BY NgayVaoLam DESC";
            return new InlineQuery().ExecuteTypedList<GiaoVien>(sql);

        }
        public static List<GiaoVien> ThongTinGiaoVien(string id)
        {
            string sql = @"select GiaoVien .*,GiaoVien.Sdt from GiaoVien   where GiaoVien.IdGiaoVien='"+id+"'";
            return new InlineQuery().ExecuteTypedList<GiaoVien>(sql);

        }
        public static List<GiaoVien> SearchList(string textSearch)
        {
            string sql = @"select * from GiaoVien";
            DateTime dateTimeTemp = DateTime.MinValue;
            DateTime.TryParse(textSearch, out dateTimeTemp);
            if (dateTimeTemp != DateTime.MinValue)
            {
                sql += " WHERE cast( NamSinh as Date) = '" + dateTimeTemp.ToString("yyyy-MM-dd") + "'" + "OR cast( NgayVaoLam as Date) = '" + dateTimeTemp.ToString("yyyy-MM-dd") + "'  "  +"OR cast( NamSinh as Date) = '" + dateTimeTemp.ToString("yyyy-MM-dd") + "'" ;
            }
            else
            {
                sql += " WHERE HoTen Like N'%" + textSearch + "%' or TrinhDo Like N'%" + textSearch + "%' or GioiTinh Like N'%" + textSearch + "%'  or NamSinh Like N'%" + textSearch + "%' or SDT Like N'%" + textSearch + "%'  or DiaChi Like N'%" + textSearch + "%' or Email Like N'%" + textSearch + "%' or NgayVaoLam Like N'%" + textSearch + "%' ORDER BY NgayVaoLam DESC  ";
            }
           


            return new InlineQuery().ExecuteTypedList<GiaoVien>(sql);
        }
        // tổng lớp 

        public static List<GiaoVien> TongGiaoVien()
        {
            string sql = @"select COUNT(*) as Tong from GiaoVien ";


            return new InlineQuery().ExecuteTypedList<GiaoVien>(sql);
        }
    }
}
