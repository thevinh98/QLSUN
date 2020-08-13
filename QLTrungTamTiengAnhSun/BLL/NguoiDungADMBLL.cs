using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public;
using SubSonic;

namespace BLL
{
   public class NguoiDungADMBLL
    {
        public static NguoiDungADM InsertFile(NguoiDungADM item)
        {
            return new NguoiDungADMController().Insert(item);
        }
        public static NguoiDungADM UpDateFile(NguoiDungADM item)
        {
            return new NguoiDungADMController().Update(item);
        }
        public static bool DeleteFile(object id)
        {
            return new NguoiDungADMController().Delete(id);
        }
        public static NguoiDungADM GwtById(object id)
        {
            return new Select().From(NguoiDungADM.Schema.TableName).Where(NguoiDungADM.Columns.Id).IsEqualTo(id).ExecuteSingle<NguoiDungADM>();
        }
        public static List<NguoiDungADM> GetListNguoiDungADM()
        {
            string sql = @"select nd .*, nv.HoTen
                    from NguoiDungADM as nd join NhanVien as nv on nd.IdNhanVien=nv.Id
                     ORDER BY TenTaiKhoan ASC";
            return new InlineQuery().ExecuteTypedList<NguoiDungADM>(sql);

        }
        public static List<NguoiDungADM> GetListNguoiDungADMView(string id)
        {
            string sql = @"select nd .*, nv.HoTen
                    from NguoiDungADM as nd join NhanVien as nv on nd.IdNhanVien=nv.Id
                     where nd.IdNhanVien='"+id+"'";
            return new InlineQuery().ExecuteTypedList<NguoiDungADM>(sql);

        }
        public static List<NguoiDungADM> SearchList(string textSearch)
        {
            string sql = @"select nd .*, nv.HoTen
                    from NguoiDungADM as nd join NhanVien as nv on nd.IdNhanVien=nv.Id ";


            sql += " WHERE nv.HoTen Like N'%" + textSearch + "%' or nd.TenTaiKhoan Like N'%" + textSearch + "%'  or nd.TrangThai Like N'%" + textSearch + "%'  ORDER BY nd.TenTaiKhoan ASC";


            return new InlineQuery().ExecuteTypedList<NguoiDungADM>(sql);
        }
        public static NguoiDungADM GetUserByUserName(string userName)
        {
            
            return new Select().From(NguoiDungADM.Schema.TableName).Where(NguoiDungADM.Columns.TenTaiKhoan).
                IsEqualTo(userName).ExecuteSingle<NguoiDungADM>();

           
        }
    }
}
