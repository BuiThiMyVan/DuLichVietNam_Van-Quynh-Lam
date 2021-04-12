using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web_DuLichVietNam.Framework;

namespace Web_DuLichVietNam.Areas.Admin.Models
{
    public class KhachModel
    {
        private DuLichVNDbContext context = null;

        public KhachModel()
        {
            context = new DuLichVNDbContext();
        }

        public List<KHACHHANG> ListAll()
        {
            var list = context.Database.SqlQuery<KHACHHANG>("Khachhang_ListAll").ToList();
            return list;
        }

        public int Create(string name, DateTime ns,int gt, string sdt, string mail, string tenDN, string MK, int maQuyen)
        {
            Object[] parameters =
            {
                new SqlParameter("@Name", name),
                new SqlParameter("@NS", ns),
                new SqlParameter("@GT", gt),
                new SqlParameter("@SDT", sdt),
                new SqlParameter("@Email", mail),
                new SqlParameter("@TenDN", tenDN),
                new SqlParameter("@MK", MK),
                new SqlParameter("@MaQuyen", maQuyen)
            };

            int res = context.Database.ExecuteSqlCommand("Khachhang_Insert", parameters);
            return res;
        }

        public long Insert(KHACHHANG entity)
        {
            context.KHACHHANGs.Add(entity);
            context.SaveChanges();
            return entity.MaKH;
        }

        internal int Create(string tenKH, DateTime? ngaySinh, int? gioiTinh, string sDT, string email, string tenDN, string mK, int? maQuyen)
        {
            throw new NotImplementedException();
        }

        public KHACHHANG GetByID(string username)
        {
            return context.KHACHHANGs.SingleOrDefault(x => x.TenDN == username);
        }

        public KHACHHANG ViewDetail(int id)
        {
            return context.KHACHHANGs.Find(id);
        }

        public bool Update(KHACHHANG entity)
        {
            try
            {
                var user = context.KHACHHANGs.Find(entity.MaKH);
                user.TenKH = entity.TenKH;
                user.NgaySinh = entity.NgaySinh;
                user.GioiTinh = entity.GioiTinh;
                user.SDT = entity.SDT;
                user.Email = entity.Email;
                //user.TenDN = entity.TenDN;
                //user.MK = entity.MK;
                user.MaQuyen = entity.MaQuyen;
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        //public bool Delete(int id)
        //{
        //    try
        //    {
        //        var user = context.KHACHHANGs.Find(id);
        //        context.KHACHHANGs.Remove(user);
        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        public int Delete(int id)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-P5SQIP5;integrated security=True;DataBase=DULICHVIETNAM");
            SqlCommand cmd = new SqlCommand("Delete From KHACHHANG Where MaKH=" + id, cn);
            cn.Open();
            return cmd.ExecuteNonQuery();
        }

    }
}