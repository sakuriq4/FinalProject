using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.BUS
{
    public class LoaiSanPhamBUS
    {
        //------------------Khach hang
        public static IEnumerable<LoaiSanPham> DanhSach()
        {
            var db = new ShopConnectionDB();
            return db.Query<LoaiSanPham>("select * from LoaiSanPham where TinhTrang =0");

        }
        public static IEnumerable<DienThoai> ChiTiet(String id)
        {
            var db = new ShopConnectionDB();
            return db.Query<DienThoai>("select * from DienThoai where MaLoaiSanPham = '"+id+"'");

        }
        //--------------- ADMIN
        public static IEnumerable<LoaiSanPham> DanhSachAdmin()
        {
            var db = new ShopConnectionDB();
            return db.Query<LoaiSanPham>("select * from LoaiSanPham");
        }
        public static void InsertLSP(LoaiSanPham lsp)
        {
            var db = new ShopConnectionDB();
            db.Insert(lsp);
        }
        public static LoaiSanPham ChiTietAdmin(String id)
        {
            var db = new ShopConnectionDB();
            return db.SingleOrDefault<LoaiSanPham>("select * from LoaiSanPham where MaLoaiSanPham = '" + id + "'");
        }
        public static void EditLSP(String id, LoaiSanPham lsp)
        {
            var db = new ShopConnectionDB();
            db.Update(lsp, id);
        }
        public static void DeleteLSP(String id, LoaiSanPham lsp)
        {
            var db = new ShopConnectionDB();
            db.Update(lsp, id);
        }
    }
}