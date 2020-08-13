using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubSonic;
using Public;

namespace BLL
{
    public class HocPhiBLL
    {
        public static HocPhi InsertFile(HocPhi item)
        {
            return new HocPhiController().Insert(item);
        }
        public static HocPhi UpDateFile(HocPhi item)
        {
            return new HocPhiController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new HocPhiController().Delete(id);
        }
        public static HocPhi GwtById(object id)
        {
            return new Select().From(HocPhi.Schema.TableName).Where(HocPhi.Columns.Id).IsEqualTo(id).ExecuteSingle<HocPhi>();
        }
        public static List<HocPhi> GetListHocPhi()
        {
            string sql = @"select hp .*, hv.HoTen, l.TenLop, l.HocPhiLop
            from HocPhi as hp join NhapHoc as nh on hp.IdNhapHoc = nh.IdNhapHoc
            join Lop as l on l.IdLop = nh.IdLop
            join HocVien as hv on hv.IdHocVien = nh.IdHocVien order by hp.ThoiGianDong Desc";
            return new InlineQuery().ExecuteTypedList<HocPhi>(sql);

        }
        //học phí hôm nay
        public static List<HocPhi> GetListHocPhiHomNay(string time)
        {
            string sql = @"select hp .*, hv.HoTen, l.TenLop, l.HocPhiLop
            from HocPhi as hp join NhapHoc as nh on hp.IdNhapHoc = nh.IdNhapHoc
            join Lop as l on l.IdLop = nh.IdLop
            join HocVien as hv on hv.IdHocVien = nh.IdHocVien where hp.ThoiGianDong='"+time+"' order by hp.ThoiGianDong Desc";
            return new InlineQuery().ExecuteTypedList<HocPhi>(sql);

        }
        public static List<HocPhi> SearchListHomnay(string time,string textSearch)
        {
            string sql = @"select hp .*, hv.HoTen, l.TenLop, l.HocPhiLop
            from HocPhi as hp join NhapHoc as nh on hp.IdNhapHoc = nh.IdNhapHoc
            join Lop as l on l.IdLop = nh.IdLop
            join HocVien as hv on hv.IdHocVien = nh.IdHocVien";


            sql += " WHERE hp.ThoiGianDong ='"+time+"' and ( hv.HoTen Like N'%" + textSearch + "%' or l.TenLop Like N'%" + textSearch + "%' ) ORDER BY hp.ThoiGianDong DESC  ";


            return new InlineQuery().ExecuteTypedList<HocPhi>(sql);
        }
        public static List<HocPhi> SearchList(string textSearch)
        {
            string sql = @"select hp .*, hv.HoTen, l.TenLop, l.HocPhiLop
            from HocPhi as hp join NhapHoc as nh on hp.IdNhapHoc = nh.IdNhapHoc
            join Lop as l on l.IdLop = nh.IdLop
            join HocVien as hv on hv.IdHocVien = nh.IdHocVien";


            sql += " WHERE hv.HoTen Like N'%" + textSearch + "%' or l.TenLop Like N'%" + textSearch + "%' ORDER BY hp.ThoiGianDong DESC  ";


            return new InlineQuery().ExecuteTypedList<HocPhi>(sql);
        }
        //hoc phí
        public static List<HocPhi> GetListHocPhiHv()
        {
            string sql = @"select  hv.HoTen,hv.SDT, l.TenLop, l.HocPhiLop,sum (TienThanhToan) as DaDong , (HocPhiLop -sum (TienThanhToan)-GiamTru) as HocPhiConLai,hp.GiamTru,hp.HanDong
            from HocPhi as hp join NhapHoc as nh on hp.IdNhapHoc = nh.IdNhapHoc
            join Lop as l on l.IdLop = nh.IdLop
            join HocVien as hv on hv.IdHocVien = nh.IdHocVien 
			 group by HoTen , TenLop,HocPhiLop, hp.GiamTru , hp.HanDong,hv.sdt
			 order by hp.HanDong desc";
            return new InlineQuery().ExecuteTypedList<HocPhi>(sql);

        }

        public static List<HocPhi> SearchHocPhiHv(string textSearch)
        {
            string sql = @"select  hv.HoTen,hv.SDT, l.TenLop, l.HocPhiLop,sum (TienThanhToan) as DaDong , (HocPhiLop -sum (TienThanhToan)-GiamTru) as HocPhiConLai,hp.GiamTru,hp.HanDong
            from HocPhi as hp join NhapHoc as nh on hp.IdNhapHoc = nh.IdNhapHoc
            join Lop as l on l.IdLop = nh.IdLop
            join HocVien as hv on hv.IdHocVien = nh.IdHocVien 
			 ";


            sql += " WHERE hv.HoTen Like N'%" + textSearch + "%' or l.TenLop Like N'%" + textSearch + "%' or hv.SDT Like N'%" + textSearch + "%' or hp.GiamTru Like N'%" + textSearch + "%' or hp.HanDong Like N'%" + textSearch + "%' group by HoTen , TenLop,HocPhiLop, hp.GiamTru , hp.HanDong,hv.sdt order by hp.HanDong desc  ";


            return new InlineQuery().ExecuteTypedList<HocPhi>(sql);
        }
        // học phí theo hoc viên

        public static List<HocPhi> HocPhiHocVien(string id)
        {
            string sql = @"select  hv.HoTen,hv.SDT, l.TenLop, l.HocPhiLop,sum (TienThanhToan) as DaDong , (HocPhiLop -sum (TienThanhToan)-GiamTru) as HocPhiConLai,hp.GiamTru,hp.HanDong
            from HocPhi as hp join NhapHoc as nh on hp.IdNhapHoc = nh.IdNhapHoc
            join Lop as l on l.IdLop = nh.IdLop
            join HocVien as hv on hv.IdHocVien = nh.IdHocVien 
                where nh.IdNhapHoc='" + id + "' group by HoTen , TenLop,HocPhiLop, hp.GiamTru , hp.HanDong,hv.sdt order by hp.HanDong desc";
            return new InlineQuery().ExecuteTypedList<HocPhi>(sql);

        }

        //thống kê
        public static List<HocPhi> ThongKeHocPhi(string time1, string time2)
        {
            string sql = @"select l.TenLop, sum (TienThanhToan) as DaDong 
            from HocPhi as hp join NhapHoc as nh on hp.IdNhapHoc = nh.IdNhapHoc
            join Lop as l on l.IdLop = nh.IdLop
            join HocVien as hv on hv.IdHocVien = nh.IdHocVien  
			WHERE hp.ThoiGianDong BETWEEN '" + time1 + "' AND '" + time2 + "' group by  TenLop order by l.TenLop ASC";
            return new InlineQuery().ExecuteTypedList<HocPhi>(sql);

        }
        // đem học phí
        public static List<HocPhi> DemHocPhi(string time)
        {
            string sql = @"SELECT COUNT(*) as DemHP
            FROM HocPhi
            WHERE ThoiGianDong = '"+time+"' ";
            return new InlineQuery().ExecuteTypedList<HocPhi>(sql);

           
        }
    }
}
