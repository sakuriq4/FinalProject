using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.BUS
{
    public class NhaSanXuatBUS
    {
        public static IEnumerable<NhaSanXuat> DanhSach()
        {
            var db = new ShopConnectionDB();
            return db.Query<NhaSanXuat>("select * from NhaSanXuat where TinhTrang = 0");

        }
        public static IEnumerable<DienThoai> ChiTiet(String id)
        {
            var db = new ShopConnectionDB();
            return db.Query<DienThoai>("select * from DienThoai where MaNhaSanXuat = '" + id + "'");
        }

        //---------------- Admin
        public static void ThemNSX(NhaSanXuat nsx)
        {
            var db = new ShopConnectionDB();
            db.Insert(nsx);
        }
        public static IEnumerable<NhaSanXuat> DanhSachAdmin()
        {
            var db = new ShopConnectionDB();
            return db.Query<NhaSanXuat>("select * from NhaSanXuat");
        }
        public static NhaSanXuat ChiTietAdmin(String id)
        {
            var db = new ShopConnectionDB();
            return db.SingleOrDefault<NhaSanXuat>("select * from NhaSanXuat where MaNhaSanXuat = '" + id + "'");

        }

        public static void UpdateNSX(String id, NhaSanXuat nsx)
        {
            var db = new ShopConnectionDB();
            db.Update(nsx, id);
        }
    }
}