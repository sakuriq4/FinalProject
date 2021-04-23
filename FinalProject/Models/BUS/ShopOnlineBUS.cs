using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FinalProject.Models.BUS
{
    public class ShopOnlineBUS
    {
        public static IEnumerable<DienThoai> DanhSach()
        {
            var db = new ShopConnectionDB();
            return db.Query<DienThoai>("select * from DienThoai where TinhTrang = '0         '");

        }
        public static DienThoai ChiTiet(String a)
        {
            var db = new ShopConnectionDB();
            return db.SingleOrDefault<DienThoai>("select * from DienThoai where MaSanPham = @0", a);
        }
        public static IEnumerable<DienThoai> Top4New()
        {
            var db = new ShopConnectionDB();
            return db.Query<DienThoai>("select Top 4 * from DienThoai where Luotview < '100' AND TinhTrang = '0         '");
        }
        public static IEnumerable<DienThoai> TopHot()
        {
            var db = new ShopConnectionDB();
            return db.Query<DienThoai>("select Top 4 * from DienThoai Where LuotView > '1000' AND TinhTrang = '0         ' ORDER BY LuotView desc");
        }

        public static void CapNhatLuotView(string masp)
        {
            var db = new ShopConnectionDB();
            var a = ChiTiet(masp);
            a.LuotView = a.LuotView + 1;
            db.Update(a, masp);
        }

        //----------------------------------------------admin----------
        public static IEnumerable<DienThoai> DanhSachSP()
        {
            var db = new ShopConnectionDB();
            return db.Query<DienThoai>("select * from DienThoai");
            //foreach (var item in ds)
            //{
            //    item.HinhChinh = LoadAvartaImg(item.MaSanPham);
            //}
            //return ds;
        }
        public static void InsertSP(DienThoai sp)
        {
            var db = new ShopConnectionDB();
            db.Insert(sp);
        }
        public static void UpdateSP(String id, DienThoai sp)
        {
            var db = new ShopConnectionDB();
            db.Update(sp, id);
        }

        //----------------------------------update images---------------
        public static void UpdateImages(string id, string images)
        {
            var db = new ShopConnectionDB();
            var sp = ShopOnlineBUS.ChiTiet(id);
            sp.MoreImages = images;
            db.Update(sp, id);
        }
        //------------------------Loai ảnh đại diện cho hình ảnh-------------
    }
}