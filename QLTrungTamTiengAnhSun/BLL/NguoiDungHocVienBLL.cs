using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public;
using SubSonic;

namespace BLL
{
   public class NguoiDungHocVienBLL
    {
        public static NguoiDungHocVien InsertFile(NguoiDungHocVien item)
        {
            return new NguoiDungHocVienController().Insert(item);
        }
        public static NguoiDungHocVien UpDateFile(NguoiDungHocVien item)
        {
            return new NguoiDungHocVienController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new NguoiDungHocVienController().Delete(id);
        }
        public static NguoiDungHocVien GwtById(object id)
        {
            return new Select().From(NguoiDungHocVien.Schema.TableName).Where(NguoiDungHocVien.Columns.Id).IsEqualTo(id).ExecuteSingle<NguoiDungHocVien>();
        }
        public static List<NguoiDungHocVien> GetListNguoiDungHocVien()
        {
            string sql = @"select nd .*, hv.HoTen
                    from NguoiDungHocVien as nd join HocVien as hv on nd.IdHocVien=hv.IdHocVien
                     ORDER BY TenTaiKhoan ASC";
            return new InlineQuery().ExecuteTypedList<NguoiDungHocVien>(sql);

        }
        public static List<NguoiDungHocVien> SearchList(string textSearch)
        {
            string sql = @"select nd .*, hv.HoTen
                    from NguoiDungHocVien as nd join HocVien as hv on nd.IdHocVien=hv.IdHocVien ";


            sql += " WHERE hv.HoTen Like N'%" + textSearch + "%' or nd.TenTaiKhoan Like N'%" + textSearch + "%'  or nd.TrangThai Like N'%" + textSearch + "%'  ORDER BY nd.TenTaiKhoan ASC";


            return new InlineQuery().ExecuteTypedList<NguoiDungHocVien>(sql);
        }
        public static NguoiDungHocVien GetUserByUserName(string userName)
        {
            // Đây là hàm collection, cái này lấy cả danh sách, ta ko nên dùng nó nếu chỉ lấy 1 giá trị, nó sẽ nặng
            // Đặt tên biến rất quan trọng, nên rèn luyện tính cẩn thận
            // ExcuteSingle là lấy 1 giá trị
            // ExcuteList là lấy danh sách
            return new Select().From(NguoiDungHocVien.Schema.TableName).Where(NguoiDungHocVien.Columns.TenTaiKhoan).
                IsEqualTo(userName).ExecuteSingle<NguoiDungHocVien>();
        }
    }
}
