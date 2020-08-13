using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using SubSonic;
using Public;
namespace BLL
{
   public class ThongBaoGiaoVienBLL
    {
        public static ThongBaoGiaoVien InsertFile(ThongBaoGiaoVien item)
        {
            return new ThongBaoGiaoVienController().Insert(item);
        }
        public static ThongBaoGiaoVien UpDateFile(ThongBaoGiaoVien item)
        {
            return new ThongBaoGiaoVienController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new ThongBaoGiaoVienController().Delete(id);
        }
        public static ThongBaoGiaoVien GwtById(object id)
        {
            return new Select().From(ThongBaoGiaoVien.Schema.TableName).Where(ThongBaoGiaoVien.Columns.Id).IsEqualTo(id).ExecuteSingle<ThongBaoGiaoVien>();
        }
        public static List<ThongBaoGiaoVien> GetListThongBaoGiaoVien()
        {
            string sql = @"select tbgv .*, gv.HoTen from ThongBaoGiaoVien as tbgv join GiaoVien  as gv on gv.IdGiaoVien=tbgv.IdGiaoVien order by tbgv.ThoiGian desc";
            return new InlineQuery().ExecuteTypedList<ThongBaoGiaoVien>(sql);

        }
        // thong bao hom nay
        public static List<ThongBaoGiaoVien> GetListThongBaoGiaoVienhomnay(string time)
        {
            string sql = @"select tbgv .*, gv.HoTen from ThongBaoGiaoVien as tbgv join GiaoVien  as gv on gv.IdGiaoVien=tbgv.IdGiaoVien where tbgv.ThoiGian='"+time+"' order by tbgv.ThoiGian desc";
            return new InlineQuery().ExecuteTypedList<ThongBaoGiaoVien>(sql);

        }
        public static List<ThongBaoGiaoVien> SearchListhomnay(string time,string textSearch)
        {
            string sql = @"select tbgv .*, gv.HoTen from ThongBaoGiaoVien as tbgv join GiaoVien  as gv on gv.IdGiaoVien=tbgv.IdGiaoVien ";


            sql += " WHERE tbgv.ThoiGian='"+time+"' and ( tbgv.TieuDe Like N'%" + textSearch + "%' or tbgv.NoiDung Like N'%" + textSearch + "%' or tbgv.TrangThai Like N'%" + textSearch + "%' or gv.HoTen Like N'%" + textSearch + "%') ORDER BY ThoiGian DESC  ";


            return new InlineQuery().ExecuteTypedList<ThongBaoGiaoVien>(sql);
        }
        public static List<ThongBaoGiaoVien> GetListThongBaoGiaoVien_client(string id)
        {
            string sql = @"select tbgv .*, gv.HoTen from ThongBaoGiaoVien as tbgv join GiaoVien  as gv on gv.IdGiaoVien=tbgv.IdGiaoVien where tbgv.IdGiaoVien='"+id+"' and tbgv.TrangThai like N'Hiện' order by tbgv.ThoiGian desc";
            return new InlineQuery().ExecuteTypedList<ThongBaoGiaoVien>(sql);

        }
        public static List<ThongBaoGiaoVien> SearchList(string textSearch)
        {
            string sql = @"select tbgv .*, gv.HoTen from ThongBaoGiaoVien as tbgv join GiaoVien  as gv on gv.IdGiaoVien=tbgv.IdGiaoVien ";


            sql += " WHERE tbgv.TieuDe Like N'%" + textSearch + "%' or tbgv.NoiDung Like N'%" + textSearch + "%' or tbgv.TrangThai Like N'%" + textSearch + "%' or gv.HoTen Like N'%" + textSearch + "%' ORDER BY ThoiGian DESC  ";


            return new InlineQuery().ExecuteTypedList<ThongBaoGiaoVien>(sql);
        }
        // đem học phí
        public static List<ThongBaoGiaoVien> DemThongBao(string time)
        {
            string sql = @"SELECT COUNT(*) as DemTB
            FROM ThongBaoGiaoVien
            WHERE ThoiGian = '" + time + "' ";
            return new InlineQuery().ExecuteTypedList<ThongBaoGiaoVien>(sql);


        }
    }
}
