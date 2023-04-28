using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using QLTDL22.Models;
using PagedList;
using PagedList.Mvc;
namespace QLTDL22.Controllers
{
    public class DSKHACHController : Controller
    {
        //Thao tác hiện danh sách
        public ActionResult ShowList(string filter, int? page)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();


            var dsKhach = from kh in db.tbKHACHes select kh;

            if (!string.IsNullOrEmpty(filter))
            {
                dsKhach = dsKhach.Where(kh => kh.TenKhachHang.Contains(filter) || kh.MaKhach.Contains(filter));
                ViewBag.Filter = filter;
            }

            return View(dsKhach.ToList());
        }   



            // Thao tác thêm
            public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbKHACH them)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            if (ModelState.IsValid)
            {
                if (them.MaKhach == null)
                {
                    ModelState.AddModelError("MaKhach", "Mã khách hàng không được để trống!");
                }
                else if (db.tbKHACHes.Any(khach => khach.MaKhach == them.MaKhach))
                {
                    ModelState.AddModelError("MaKhach", "Mã khách hàng đã tồn tại!");
                }
                else
                {
                    db.tbKHACHes.Add(them);
                    db.SaveChanges();
                    return RedirectToAction("ShowList");
                }
            }
            return View(them);
        }

        // Thao tác chỉnh sửa 
        [HttpGet]
        public ActionResult Edit(string id)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbKHACH edit = db.tbKHACHes.Find(id);
            return View(edit);
        }
        [HttpPost]
        public ActionResult Edit(tbKHACH edit)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            var updatemodel = db.tbKHACHes.Find(edit.MaKhach);           
            updatemodel.TenKhachHang = edit.TenKhachHang;
            updatemodel.SoCMND = edit.SoCMND;
            updatemodel.SoDienThoai = edit.SoDienThoai;
            updatemodel.DiaChi = edit.DiaChi;
            db.SaveChanges();
            return RedirectToAction("ShowList");
        }
        public ActionResult Delete_TB()
        {
            return View(); // Add 1 cái view 
        }
        // thao tác xóa
        [HttpGet]
        public ActionResult Delete(string id)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            // tìm đối tượng
            tbKHACH xoa = db.tbKHACHes.Find(id);
            return View(xoa);
        }
        [HttpPost]
        public ActionResult Delete(FormCollection f)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            string mk = f.Get("MaKhach");
            var khach = (from k in db.tbKHACHes where k.MaKhach == mk select  k).FirstOrDefault();
            if (khach == null)
            {
                // tìm đối tượng
                tbKHACH xoadl = db.tbKHACHes.Find(mk);
                // lệnh xóa
                db.tbKHACHes.Remove(xoadl);
                // lưu lại
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("Delete_TB");
            }
            return RedirectToAction("ShowList");
        }
        // Hiện thông tin chi tiết 
        public ActionResult Details( String id)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbKHACH chitiet = db.tbKHACHes.Find(id);
            return View(chitiet);
        }



    }
}