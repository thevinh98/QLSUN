using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubSonic;
using Public;

namespace BLL
{
   public class DiemDanhBLL
    {
        public static DiemDanh InsertFile(DiemDanh item)
        {
            return new DiemDanhController().Insert(item);
        }
        public static DiemDanh UpDateFile(DiemDanh item)
        {
            return new DiemDanhController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new DiemDanhController().Delete(id);
        }
        public static DiemDanh GwtById(object id)
        {
            return new Select().From(DiemDanh.Schema.TableName).Where(DiemDanh.Columns.Id).IsEqualTo(id).ExecuteSingle<DiemDanh>();
        }
        public static List<DiemDanh> GetListDiemDanh()
        {
            string sql = @"select dd .*, hv.HoTen ,lgd.BuoiHoc , l.TenLop, lgd.ThoiGianBatDau, lgd.ThoiGianKetThuc,ph.SoPhong
                from DiemDanh as dd join NhapHoc as nh on nh.IdNhapHoc = dd.IdNhapHoc
                join LichGiangDay lgd on dd.IdLichGiangDay = lgd.IdLichGiangDay
                join Lop as l on l.IdLop= nh.IdLop
                join HocVien as hv on hv.IdHocVien = nh.IdHocVien
                join PhongHoc as ph on ph.IdPhongHoc = lgd. IdPhongHoc order by hv.HoTen asc";
            return new InlineQuery().ExecuteTypedList<DiemDanh>(sql);

        }

        public static List<DiemDanh> GetListDiemDanhLop(string idlop)
        {
            string sql = @"select dd .*, hv.HoTen ,lgd.BuoiHoc , l.TenLop, lgd.ThoiGianBatDau, lgd.ThoiGianKetThuc,ph.SoPhong
                from DiemDanh as dd join NhapHoc as nh on nh.IdNhapHoc = dd.IdNhapHoc
                join LichGiangDay lgd on dd.IdLichGiangDay = lgd.IdLichGiangDay
                join Lop as l on l.IdLop= nh.IdLop
                join HocVien as hv on hv.IdHocVien = nh.IdHocVien
                join PhongHoc as ph on ph.IdPhongHoc = lgd. IdPhongHoc where l.IdLop='"+ idlop + "' order by hv.HoTen asc";
            return new InlineQuery().ExecuteTypedList<DiemDanh>(sql);

        }
        //thong tin diem danh
        public static List<DiemDanh> Thongtindiemdanh(string id)
        {
            string sql = @"select dd .*, hv.HoTen ,lgd.BuoiHoc , l.TenLop, lgd.ThoiGianBatDau, lgd.ThoiGianKetThuc,ph.SoPhong
                from DiemDanh as dd join NhapHoc as nh on nh.IdNhapHoc = dd.IdNhapHoc
                join LichGiangDay lgd on dd.IdLichGiangDay = lgd.IdLichGiangDay
                join Lop as l on l.IdLop= nh.IdLop
                join HocVien as hv on hv.IdHocVien = nh.IdHocVien
                join PhongHoc as ph on ph.IdPhongHoc = lgd. IdPhongHoc where hv.IdHocVien='" + id + "' order by lgd.ThoiGianBatDau asc";
            return new InlineQuery().ExecuteTypedList<DiemDanh>(sql);

        }
        public static List<DiemDanh> GetListDiemDanhLopBH(string idlop)
        {
            string sql = @"select dd .*, hv.HoTen ,lgd.BuoiHoc , l.TenLop, lgd.ThoiGianBatDau, lgd.ThoiGianKetThuc,ph.SoPhong
                from DiemDanh as dd join NhapHoc as nh on nh.IdNhapHoc = dd.IdNhapHoc
                join LichGiangDay lgd on dd.IdLichGiangDay = lgd.IdLichGiangDay
                join Lop as l on l.IdLop= nh.IdLop
                join HocVien as hv on hv.IdHocVien = nh.IdHocVien
                join PhongHoc as ph on ph.IdPhongHoc = lgd. IdPhongHoc where l.IdLop='" + idlop + "'  order by lgd.BuoiHoc asc";
            return new InlineQuery().ExecuteTypedList<DiemDanh>(sql);

        }

        public static List<DiemDanh> SearchList(string textSearch)
        {
            string sql = @"select dd .*, hv.HoTen,lgd.BuoiHoc , l.TenLop, lgd.ThoiGianBatDau, lgd.ThoiGianKetThuc,ph.SoPhong
                from DiemDanh as dd join NhapHoc as nh on nh.IdNhapHoc = dd.IdNhapHoc
                join LichGiangDay lgd on dd.IdLichGiangDay = lgd.IdLichGiangDay
                join Lop as l on l.IdLop= nh.IdLop
                join HocVien as hv on hv.IdHocVien = nh.IdHocVien
                join PhongHoc as ph on ph.IdPhongHoc = lgd. IdPhongHoc ";


            sql += " WHERE hv.Hoten Like N'%" + textSearch + "%' or l.TenLop Like N'%" + textSearch + "%' or lgd.BuoiHoc Like N'%" + textSearch + "%' or lgd.ThoiGianBatDau Like N'%" + textSearch + "%' or lgd.ThoiGianKetThuc Like N'%" + textSearch + "%' or dd.TrangThai Like N'%" + textSearch + "%' or ph.SoPhong Like N'%" + textSearch + "%' ORDER BY l.TenLop ASC  ";


            return new InlineQuery().ExecuteTypedList<DiemDanh>(sql);
        }
    }
}
