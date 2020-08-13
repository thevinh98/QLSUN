using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubSonic;
using Public;

namespace BLL
{
    public class LichGiangDayBLL
    {
        public static LichGiangDay InsertFile(LichGiangDay item)
        {
            return new LichGiangDayController().Insert(item);
        }
        public static LichGiangDay UpDateFile(LichGiangDay item)
        {
            return new LichGiangDayController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new LichGiangDayController().Delete(id);
        }
        public static LichGiangDay GwtById(object id)
        {
            return new Select().From(LichGiangDay.Schema.TableName).Where(LichGiangDay.Columns.IdLichGiangDay).IsEqualTo(id).ExecuteSingle<LichGiangDay>();
        }
        public static List<LichGiangDay> GetListLichGiangDay()
        {
            string sql = @"select lgd .* , l.TenLop, ph.SoPhong, gv.HoTen
                from LichGiangDay as lgd join Lop as l on l.IdLop = lgd.IdLop 
                join PhongHoc as ph on lgd.IdPhongHoc = ph.IdPhongHoc
                join GiaoVien as gv on lgd.IdGiaoVien = gv.IdGiaoVien ORDER BY l.TenLop ASC";
            return new InlineQuery().ExecuteTypedList<LichGiangDay>(sql);

        }
        public static List<LichGiangDay> GetListLichHoc(string idLop)
        {
            string sql = @"select lgd .* , l.TenLop, ph.SoPhong, gv.HoTen
                from LichGiangDay as lgd join Lop as l on l.IdLop = lgd.IdLop 
                join PhongHoc as ph on lgd.IdPhongHoc = ph.IdPhongHoc
                join GiaoVien as gv on lgd.IdGiaoVien = gv.IdGiaoVien where l.IdLop='"+idLop+"' ORDER BY lgd.ThoiGianBatDau ASC";
            return new InlineQuery().ExecuteTypedList<LichGiangDay>(sql);

        }

       
        public static List<LichGiangDay> SearchList(string textSearch)
        {
            string sql = @"select lgd .* , l.TenLop, ph.SoPhong, gv.HoTen
                from LichGiangDay as lgd join Lop as l on l.IdLop = lgd.IdLop 
                join PhongHoc as ph on lgd.IdPhongHoc = ph.IdPhongHoc
                join GiaoVien as gv on lgd.IdGiaoVien = gv.IdGiaoVien ";


            sql += " WHERE L.TenLop Like N'%" + textSearch + "%' or gv.HoTen Like N'%" + textSearch + "%' or l.SoBuoiHoc Like N'%" + textSearch + "%' ORDER BY l.TenLop DESC  ";


            return new InlineQuery().ExecuteTypedList<LichGiangDay>(sql);
        }
        //lịch dạy giáo viên
        public static List<LichGiangDay> SearchListLichDayGV(string textSearch,string time1,string time2)
        {
            string sql = @"select lgd .* , l.TenLop, ph.SoPhong, gv.HoTen
                from LichGiangDay as lgd join Lop as l on l.IdLop = lgd.IdLop 
                join PhongHoc as ph on lgd.IdPhongHoc = ph.IdPhongHoc
                join GiaoVien as gv on lgd.IdGiaoVien = gv.IdGiaoVien
                WHERE lgd.ThoiGianBatDau BETWEEN '" + time1 + "' AND '" + time2 + "' and gv.IdGiaoVien='"+textSearch+"' order by lgd.ThoiGianBatDau ASC";


           


            return new InlineQuery().ExecuteTypedList<LichGiangDay>(sql);
        }

        // tính lương
        public static List<LichGiangDay> LuongGv(string time1, string time2)
        {
            string sql = @"select gv.IdGiaoVien,  gv.HoTen ,gv.TrinhDo,sum (SoGio) as TongGio,SUM (SoGio *300000) as LuongGV
                from LichGiangDay as lgd join Lop as l on l.IdLop = lgd.IdLop 
                join PhongHoc as ph on lgd.IdPhongHoc = ph.IdPhongHoc
                join GiaoVien as gv on lgd.IdGiaoVien = gv.IdGiaoVien 
				WHERE lgd.ThoiGianBatDau BETWEEN '" + time1 + "' AND '" + time2 + "'group by gv.HoTen,gv.TrinhDo,gv.IdGiaoVien ";

            return new InlineQuery().ExecuteTypedList<LichGiangDay>(sql);
        }
        // hóa đơn
        public static List<LichGiangDay> HoaDonLuongGv(string time1, string time2,string id)
        {
            string sql = @"select lgd.IdGiaoVien as IdGV,  gv.HoTen ,gv.TrinhDo,gv.DiaChi,gv.GioiTinh,gv.SDT,sum (SoGio) as TongGio,SUM (SoGio *300000) as LuongGV
                from LichGiangDay as lgd join Lop as l on l.IdLop = lgd.IdLop 
                join PhongHoc as ph on lgd.IdPhongHoc = ph.IdPhongHoc
                join GiaoVien as gv on lgd.IdGiaoVien = gv.IdGiaoVien 
				WHERE lgd.ThoiGianBatDau BETWEEN '" + time1+"' AND '"+time2+"' and gv.IdGiaoVien='"+id+ "' group by HoTen, TrinhDo,SDT,DiaChi,GioiTinh,lgd.IdGiaoVien ";

            return new InlineQuery().ExecuteTypedList<LichGiangDay>(sql);
        }
        //tim kiếm
        public static List<LichGiangDay> Search_LuongGv(string time1, string time2,string text)
        {
            string sql = @"select   gv.HoTen ,gv.TrinhDo,sum (SoGio) as TongGio,SUM (SoGio *100000) as LuongGV
                from LichGiangDay as lgd join Lop as l on l.IdLop = lgd.IdLop 
                join PhongHoc as ph on lgd.IdPhongHoc = ph.IdPhongHoc
                join GiaoVien as gv on lgd.IdGiaoVien = gv.IdGiaoVien 
				WHERE lgd.ThoiGianBatDau BETWEEN '" + time1 + "' AND '" + time2 + "' and gv.HoTen like N'"+text+"'  group by gv.HoTen,gv.TrinhDo ";

            return new InlineQuery().ExecuteTypedList<LichGiangDay>(sql);
        }
        public static List<LichGiangDay> SearchListLH(string textSearch)
        {
            string sql = @"select lgd .* , l.TenLop, ph.SoPhong, gv.HoTen
                from LichGiangDay as lgd join Lop as l on l.IdLop = lgd.IdLop 
                join PhongHoc as ph on lgd.IdPhongHoc = ph.IdPhongHoc
                join GiaoVien as gv on lgd.IdGiaoVien = gv.IdGiaoVien ";


            sql += " WHERE L.TenLop Like N'%" + textSearch + "%' or gv.HoTen Like N'%" + textSearch + "%' or l.SoBuoiHoc Like N'%" + textSearch + "%' ORDER BY ThoiGianBatDau ASC  ";


            return new InlineQuery().ExecuteTypedList<LichGiangDay>(sql);
        }
    }
}
