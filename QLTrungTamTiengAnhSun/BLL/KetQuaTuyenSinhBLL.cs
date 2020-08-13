using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public;
using SubSonic;

namespace BLL
{
    public class KetQuaTuyenSinhBLL
    {
        public static KetQuaTuyenSinh InsertFile(KetQuaTuyenSinh item)
        {
            return new KetQuaTuyenSinhController().Insert(item);
        }
        public static KetQuaTuyenSinh UpDateFile(KetQuaTuyenSinh item)
        {
            return new KetQuaTuyenSinhController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new KetQuaTuyenSinhController().Delete(id);
        }
        public static KetQuaTuyenSinh GwtById(object id)
        {
            return new Select().From(KetQuaTuyenSinh.Schema.TableName).Where(KetQuaTuyenSinh.Columns.Id).IsEqualTo(id).ExecuteSingle<KetQuaTuyenSinh>();
        }
        public static List<KetQuaTuyenSinh> GetListKetQuaTuyenSinh()
        {
            string sql = @"select kq .*, dkt.TenDotTuyenSinh, hv.HoTen,dkt.ThoiGian
From KetQuaTuyenSinh as kq join DotTuyenSinh as dkt on kq.IdDotTuyenSinh = dkt.IdDotTuyenSinh join
HocVien as hv on kq.IdHocVien=hv.IdHocVien  ORDER BY  dkt.ThoiGian DESC ";
            return new InlineQuery().ExecuteTypedList<KetQuaTuyenSinh>(sql);

        }
        // ket qua id
        public static List<KetQuaTuyenSinh> GetListKetQuaTuyenSinh_TT(string id)
        {
            string sql = @"select kq .*, dkt.TenDotTuyenSinh, hv.HoTen,dkt.ThoiGian
From KetQuaTuyenSinh as kq join DotTuyenSinh as dkt on kq.IdDotTuyenSinh = dkt.IdDotTuyenSinh join
HocVien as hv on kq.IdHocVien=hv.IdHocVien  where hv.IdHocVien ='"+id+"' ";
            return new InlineQuery().ExecuteTypedList<KetQuaTuyenSinh>(sql);

        }
        public static List<ChucVu> SearchList(string textSearch)
        {
            string sql = @"select * from ChucVu ";


            sql += " WHERE TenChucVu Like N'%" + textSearch + "%' or LuongThang Like N'%" + textSearch + "%' ORDER BY TenChucVu ASC  ";


            return new InlineQuery().ExecuteTypedList<ChucVu>(sql);
        }
    }
}
