using FinalProject.Models.BUS;
using PagedList;
using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Areas.Admin.Controllers
{
    public class SanPhamAdminController : Controller
    {
        [Authorize (Roles="admin")]
        // GET: Admin/SanPhamAdmin
        public ActionResult Index()
        {
            return View(ShopOnlineBUS.DanhSachSP());
        }

        // GET: Admin/SanPhamAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/SanPhamAdmin/Create
        public ActionResult Create()
        {
            ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNhaSanXuat", "TenNhaSanXuat");
            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSanPham", "TenLoaiSanPham");
            return View();
        }

        // POST: Admin/SanPhamAdmin/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(DienThoai sp)
        {
            try
            {
                // TODO: Add insert logic here
                var hpf = HttpContext.Request.Files[0];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.HinhChinh;
                    string fullPathWithFileName = "~/Asset/images" + fileName + ".png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.HinhChinh = sp.TenSanPham + ".png";
                }
                //Hinh1
                hpf = HttpContext.Request.Files[1];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.Hinh1;
                    string fullPathWithFileName = "~/Asset/images" + fileName + ".png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh1 = sp.TenSanPham + "_1.png";
                }
                //
                hpf = HttpContext.Request.Files[2];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.Hinh2;
                    string fullPathWithFileName = "~/Asset/images" + fileName + ".png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh2 = sp.TenSanPham + "_2.png";
                }
                //
                hpf = HttpContext.Request.Files[3];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.Hinh3;
                    string fullPathWithFileName = "~/Asset/images" + fileName + ".png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh3 = sp.TenSanPham + "_3.png";
                }
                //
                hpf = HttpContext.Request.Files[4];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.Hinh4;
                    string fullPathWithFileName = "~/Asset/images" + fileName + ".png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh4 = sp.TenSanPham + "_4.png";
                }
                sp.TinhTrang = "0";
                sp.SoLuongDaBan = 0;
                sp.LuotView = 0;
                ShopOnlineBUS.InsertSP(sp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SanPhamAdmin/Edit/5
        public ActionResult Edit(String id)
        {
            ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNhaSanXuat", "TenNhaSanXuat",ShopOnlineBUS.ChiTiet(id).MaNhaSanXuat);
            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSanPham", "TenLoaiSanPham",ShopOnlineBUS.ChiTiet(id).MaLoaiSanPham);
            return View(ShopOnlineBUS.ChiTiet(id));
        }

        // POST: Admin/SanPhamAdmin/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(String id, DienThoai sp)
        {
            var tam = ShopOnlineBUS.ChiTiet(id);
            try
            {
                // TODO: Add insert logic here
                var hpf = HttpContext.Request.Files[0];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.HinhChinh;
                    string fullPathWithFileName = "~/Asset/images" + fileName + ".png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.HinhChinh = sp.TenSanPham + ".png";
                }
                else { sp.HinhChinh = tam.HinhChinh; }
                //Hinh1
                hpf = HttpContext.Request.Files[1];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.Hinh1;
                    string fullPathWithFileName = "~/Asset/images" + fileName + ".png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh1 = sp.TenSanPham + "_1.png";
                }
                else { sp.Hinh1 = tam.Hinh1; }
                //
                hpf = HttpContext.Request.Files[2];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.Hinh2;
                    string fullPathWithFileName = "~/Asset/images" + fileName + ".png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh2 = sp.TenSanPham + "_2.png";
                }else{ sp.Hinh2 = tam.Hinh2; }
                //
                hpf = HttpContext.Request.Files[3];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.Hinh3;
                    string fullPathWithFileName = "~/Asset/images" + fileName + ".png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh3 = sp.TenSanPham + "_3.png";
                }
                else { sp.Hinh3 = tam.Hinh3; }
                //
                hpf = HttpContext.Request.Files[4];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.Hinh4;
                    string fullPathWithFileName = "~/Asset/images" + fileName + ".png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh4 = sp.TenSanPham + "_4.png";
                }
                else { sp.Hinh4 = tam.Hinh4; }
                if (sp.SoLuongDaBan > 10000)
                {
                    sp.SoLuongDaBan = 0;
                }
                else { sp.SoLuongDaBan = tam.SoLuongDaBan; }
                if (sp.LuotView > 10000) { sp.LuotView = 0; } else { sp.LuotView = tam.LuotView; }
                sp.TinhTrang = tam.TinhTrang;
                ShopOnlineBUS.UpdateSP(id, sp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SanPhamAdmin/Delete/5
        public ActionResult Delete(String id)
        {
            return View(ShopOnlineBUS.ChiTiet(id));
        }

        // POST: Admin/SanPhamAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(String id, DienThoai sp)
        {
            var tam = ShopOnlineBUS.ChiTiet(id);
            try
            {
                // TODO: Add delete logic here
                sp.HinhChinh = tam.HinhChinh;
                sp.Hinh1 = tam.Hinh1;
                sp.Hinh2 = tam.Hinh2;
                sp.Hinh3 = tam.Hinh3;
                sp.Hinh4 = tam.Hinh4;
                if (tam.SoLuongDaBan > 10000)
                {
                    tam.SoLuongDaBan = 0;
                }
                if (tam.LuotView > 10000) { tam.LuotView = 0; } 
                if(tam.TinhTrang == "1         ") { tam.TinhTrang = "0         "; }
                else
                {
                    tam.TinhTrang = "0         ";
                }    
                ShopOnlineBUS.UpdateSP(id, tam);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
