using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web_DuLichVietNam.Framework;

namespace Web_DuLichVietNam.Areas.Admin.Models
{
    public class HDVModel
    {
        private DuLichVNDbContext context = null;

        public HDVModel()
        {
            context = new DuLichVNDbContext();
        }

        public List<HUONGDANVIEN> ListAll()
        {
            var list = context.Database.SqlQuery<HUONGDANVIEN>("HDV_ListAll").ToList();
            return list;
        }

        public long Insert(HUONGDANVIEN entity)
        {
            context.HUONGDANVIENs.Add(entity);
            context.SaveChanges();
            return entity.MaHDV;
        }

        public HUONGDANVIEN GetByID(string username)
        {
            return context.HUONGDANVIENs.SingleOrDefault(x => x.TenHDV == username);
        }

        public HUONGDANVIEN ViewDetail(int id)
        {
            return context.HUONGDANVIENs.Find(id);
        }

        public bool Update(HUONGDANVIEN entity)
        {
            try
            {
                var user = context.HUONGDANVIENs.Find(entity.MaHDV);
                user.TenHDV = entity.TenHDV;
                user.SDT = entity.SDT;
                user.DiaChi = entity.DiaChi;
                //user.TenDN = entity.TenDN;
                //user.MK = entity.MK;              
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int Delete(int id)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-P5SQIP5;integrated security=True;DataBase=DULICHVIETNAM");
            SqlCommand cmd = new SqlCommand("Delete From HUONGDANVIEN Where MaHDV=" + id, cn);
            cn.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}