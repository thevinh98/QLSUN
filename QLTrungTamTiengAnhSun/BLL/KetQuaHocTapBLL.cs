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
    public class KetQuaHocTapBLL
    {
        public static KetQuaHocTap InsertFile(KetQuaHocTap item)
        {
            return new KetQuaHocTapController().Insert(item);
        }
        public static KetQuaHocTap UpDateFile(KetQuaHocTap item)
        {
            return new KetQuaHocTapController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new KetQuaHocTapController().Delete(id);
        }
        public static KetQuaHocTap GwtById(object id)
        {
            return new Select().From(KetQuaHocTap.Schema.TableName).Where(KetQuaHocTap.Columns.Id).IsEqualTo(id).ExecuteSingle<KetQuaHocTap>();
        }
        public static List<KetQuaHocTap> GetListKetQuaHocTap()
        {
            string sql = @"select kq.*, hv.HoTen,dkt.Ten,l.TenLop
                from KetQuaHocTap as kq join DotKiemTra as dkt on kq.IdDotKiemTra=dkt.IdDotKiemTra
                 join NhapHoc as nh on nh.IdNhapHoc=kq.IdNhapHoc
                 join HocVien as hv on hv.IdHocVien = nh.IdHocVien
                 join Lop as l on l.IdLop = nh.IdLop ORDER BY hv.HoTen  DESC";
            return new InlineQuery().ExecuteTypedList<KetQuaHocTap>(sql);

        }
        //
        public static List<KetQuaHocTap> ThongTinHocTap(string id)
        {
            string sql = @"select kq.*, hv.HoTen,dkt.Ten,l.TenLop
                from KetQuaHocTap as kq join DotKiemTra as dkt on kq.IdDotKiemTra=dkt.IdDotKiemTra
                 join NhapHoc as nh on nh.IdNhapHoc=kq.IdNhapHoc
                 join HocVien as hv on hv.IdHocVien = nh.IdHocVien
                 join Lop as l on l.IdLop = nh.IdLop  where hv.IdHocVien='"+id+"'";
            return new InlineQuery().ExecuteTypedList<KetQuaHocTap>(sql);

        }
        public static List<KetQuaHocTap> SearchList(string textSearch)
        {
            string sql = @"select kq.*, hv.HoTen,dkt.Ten,l.TenLop
                from KetQuaHocTap as kq join DotKiemTra as dkt on kq.IdDotKiemTra=dkt.IdDotKiemTra
                 join NhapHoc as nh on nh.IdNhapHoc=kq.IdNhapHoc
                 join HocVien as hv on hv.IdHocVien = nh.IdHocVien
                 join Lop as l on l.IdLop = nh.IdLop ";


            sql += " WHERE HoTen Like N'%" + textSearch + "%' or Ten Like N'%" + textSearch + "%' or TenLop Like N'%" + textSearch + "%' or Diem Like N'%" + textSearch + "%' ORDER BY HoTen ASC  ";


            return new InlineQuery().ExecuteTypedList<KetQuaHocTap>(sql);
        }
    }
}
