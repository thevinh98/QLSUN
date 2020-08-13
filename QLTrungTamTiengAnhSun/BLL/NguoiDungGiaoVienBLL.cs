using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public;
using SubSonic;


namespace BLL
{
   public class NguoiDungGiaoVienBLL
    {
        public static NguoiDungGiaoVien InsertFile(NguoiDungGiaoVien item)
        {
            return new NguoiDungGiaoVienController().Insert(item);
        }
        public static NguoiDungGiaoVien UpDateFile(NguoiDungGiaoVien item)
        {
            return new NguoiDungGiaoVienController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new NguoiDungGiaoVienController().Delete(id);
        }
        public static NguoiDungGiaoVien GwtById(object id)
        {
            return new Select().From(NguoiDungGiaoVien.Schema.TableName).Where(NguoiDungGiaoVien.Columns.Id).IsEqualTo(id).ExecuteSingle<NguoiDungGiaoVien>();
        }
        public static List<NguoiDungGiaoVien> GetListNguoiDungGiaoVien()
        {
            string sql = @"select nd .*, gv.HoTen
                    from NguoiDungGiaoVien as nd join GiaoVien as gv on nd.IdGiaoVien=gv.IdGiaoVien
                     ORDER BY TenTaiKhoan ASC";
            return new InlineQuery().ExecuteTypedList<NguoiDungGiaoVien>(sql);

        }
        public static List<NguoiDungGiaoVien> SearchList(string textSearch)
        {
            string sql = @"select nd .*, gv.HoTen
                    from NguoiDungGiaoVien as nd join GiaoVien as gv on nd.IdGiaoVien=gv.IdGiaoVien";


            sql += " WHERE gv.HoTen Like N'%" + textSearch + "%' or nd.TenTaiKhoan Like N'%" + textSearch + "%'  or nd.TrangThai Like N'%" + textSearch + "%'  ORDER BY nd.TenTaiKhoan ASC";


            return new InlineQuery().ExecuteTypedList<NguoiDungGiaoVien>(sql);
        }
        public static NguoiDungGiaoVien GetUserByUserName(string userName)
        {
            // Đây là hàm collection, cái này lấy cả danh sách, ta ko nên dùng nó nếu chỉ lấy 1 giá trị, nó sẽ nặng
            // Đặt tên biến rất quan trọng, nên rèn luyện tính cẩn thận
            // ExcuteSingle là lấy 1 giá trị
            // ExcuteList là lấy danh sách
            return new Select().From(NguoiDungGiaoVien.Schema.TableName).Where(NguoiDungGiaoVien.Columns.TenTaiKhoan).
                IsEqualTo(userName).ExecuteSingle<NguoiDungGiaoVien>();




            //TblNguoiDungCollection arrUser = new TblNguoiDungController().FetchByQuery(new SubSonic.Query(Tables.TblNguoiDung).WHERE
            //    (TblNguoiDung.Columns.TenDangNhap, strTen));
            //return (arrUser != null && arrUser.Count > 0) ? arrUser[0] : null;
        }
    }
}
