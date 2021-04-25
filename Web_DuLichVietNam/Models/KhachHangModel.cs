using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_DuLichVietNam.EF;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;

namespace Web_DuLichVietNam.Models
{   
    public class KhachHangModel
    {
        DuLichVietNamDbContext db = new DuLichVietNamDbContext();

        public int Insert(KHACHHANG entity)
        {
            db.KHACHHANGs.Add(entity);
            db.SaveChanges();
            return entity.MaKH;
        }
        public bool CheckUserName(string userName)
        {
            return db.KHACHHANGs.Count(x => x.TenDN == userName) > 0;
        }

        public bool CheckEmail(string email)
        {
            return db.KHACHHANGs.Count(x => x.Email == email) > 0;
        }

        public string EncodePassword(string originalPassword)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes);
        }

        public KHACHHANG GetByUsername(string TenDN)
        {
            return db.KHACHHANGs.SingleOrDefault(x => x.TenDN == TenDN);
        }

        public bool Login(string tendangnhap, string matkhau)
        {
            object[] sqlParams =
            {
                new SqlParameter("@tendangnhap", tendangnhap),
                new SqlParameter("@matkhau", matkhau),
            };
            var res = db.Database.SqlQuery<bool>("KIEMTRAKHACHHANG @tendangnhap, @matkhau", sqlParams).SingleOrDefault();

            return res;
        }
    }
}