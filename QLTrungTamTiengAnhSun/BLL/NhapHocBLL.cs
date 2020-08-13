using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public;
using SubSonic;

namespace BLL
{
   public class NhapHocBLL
    {
        public static NhapHoc InsertFile(NhapHoc item)
        {
            return new NhapHocController().Insert(item);
        }
        public static NhapHoc UpDateFile(NhapHoc item)
        {
            return new NhapHocController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new NhapHocController().Delete(id);
        }
        public static NhapHoc GwtById(object id)
        {
            return new Select().From(NhapHoc.Schema.TableName).Where(NhapHoc.Columns.IdNhapHoc).IsEqualTo(id).ExecuteSingle<NhapHoc>();
        }
        public static List<NhapHoc> GetListNhapHoc()
        {
            string sql = @"select nh .*, hv.HoTen,hv.GioiTinh, hv.NamSinh,hv.SDT,hv.Email,hv.DiaChi,hv.FaceBook, l.TenLop from NhapHoc as nh join HocVien as hv on hv.IdHocVien= nh.IdHocVien join Lop as l on l.IdLop = nh.IdLop";
            return new InlineQuery().ExecuteTypedList<NhapHoc>(sql);

        }

        public static List<NhapHoc> GetListNhapHoc_DM()
        {
            string sql = @"select nh .*, hv.HoTen,hv.GioiTinh, hv.NamSinh,hv.SDT,hv.Email,hv.DiaChi,hv.FaceBook, 
l.TenLop from NhapHoc as nh join HocVien as hv on hv.IdHocVien= nh.IdHocVien join Lop as l on l.IdLop = nh.IdLop
where l.TrangThai like N'Đang Mở'";
            return new InlineQuery().ExecuteTypedList<NhapHoc>(sql);

        }
        public static List<NhapHoc> GetListLop(string id)
        {
            string sql = @"select nh .*, hv.HoTen ,hv.GioiTinh, hv.NamSinh,hv.SDT,hv.Email,hv.DiaChi,hv.FaceBook, l.TenLop from NhapHoc as nh join HocVien as hv on hv.IdHocVien= nh.IdHocVien join Lop as l on l.IdLop = nh.IdLop where hv.IdHocVien='" + id+"'";
            return new InlineQuery().ExecuteTypedList<NhapHoc>(sql);

        }
        public static List<NhapHoc> GetListDanhSachHV( string idLop)
        {
            string sql = @"select nh .*, hv.HoTen ,hv.GioiTinh, hv.NamSinh,hv.SDT,hv.Email,hv.DiaChi,hv.FaceBook, l.TenLop from NhapHoc as nh join HocVien as hv on hv.IdHocVien= nh.IdHocVien join Lop as l on l.IdLop = nh.IdLop where nh.IdLop='" + idLop+"'";
            return new InlineQuery().ExecuteTypedList<NhapHoc>(sql);

        }
        // tong hoc viên trong lop
        public static List<NhapHoc> GetListTongHv(string idLop)
        {
            string sql = @"select COUNT (hv.HoTen) as TongHV from NhapHoc as nh join HocVien as hv on hv.IdHocVien= nh.IdHocVien join Lop as l on l.IdLop = nh.IdLop where nh.IdLop='"+idLop+"'";
            return new InlineQuery().ExecuteTypedList<NhapHoc>(sql);

        }
        public static List<NhapHoc> GetListNhapHoc_HocPhi(string id)
        {
            string sql = @"select nh .*, hv.HoTen ,hv.GioiTinh, hv.NamSinh,hv.SDT,hv.Email,hv.DiaChi,hv.FaceBook, l.TenLop ,l.HocPhiLop from NhapHoc as nh join HocVien as hv on hv.IdHocVien= nh.IdHocVien join Lop as l on l.IdLop = nh.IdLop where IdNhapHoc='" + id+ "' ORDER BY hv.HoTen ASC";
            return new InlineQuery().ExecuteTypedList<NhapHoc>(sql);

        }

        public static List<NhapHoc> SearchList(string textSearch)
        {
            string sql = @"select nh .*, hv. *, l.TenLop from NhapHoc as nh join HocVien as hv on hv.IdHocVien= nh.IdHocVien join Lop as l on l.IdLop = nh.IdLop";


            sql += " WHERE hv.HoTen Like N'%" + textSearch + "%' or hv.NamSinh Like N'%" + textSearch + "%' or hv.DiaChi Like N'%" + textSearch + "%' or hv.FaceBook Like N'%" + textSearch + "%' or hv.Email Like N'%" + textSearch + "%' or l.TenLop Like N'%" + textSearch + "%' or nh.TrangThai Like N'%" + textSearch + "%' ORDER BY hv.HoTen ASC  ";


            return new InlineQuery().ExecuteTypedList<NhapHoc>(sql);
        }
    }
}
