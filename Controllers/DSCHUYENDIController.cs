using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTDL22.Models;
namespace QLTDL22.Controllers
{
    public class DSCHUYENDIController : Controller
    {
        // GET: DSCHUYENDI
        public ActionResult ShowList()
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            List<tbCHUYENDI> dschuyendi = db.tbCHUYENDIs.ToList();
            return View(dschuyendi);
        }
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbCHUYENDI themchuyendi)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            db.tbCHUYENDIs.Add(themchuyendi);        
            db.SaveChanges();
            return RedirectToAction("ShowList");          
        }
        public ActionResult Edit(string id)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbCHUYENDI edit = db.tbCHUYENDIs.Find(id);
            return View(edit);
        }
        [HttpPost]
        public ActionResult Edit(tbCHUYENDI edit)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            var updatemodel = db.tbCHUYENDIs.Find(edit.MaChuyen);
            updatemodel.MaTuyen = edit.MaTuyen;
            updatemodel.NgayKhoiHanh =  edit.NgayKhoiHanh;
            updatemodel.NgayKetThuc = edit.NgayKetThuc;
            updatemodel.MaLoaiPhong = edit.MaLoaiPhong;
            updatemodel.MaPhuongTien = edit.MaPhuongTien;
            updatemodel.TongTien = edit.TongTien;
            db.SaveChanges();
            return RedirectToAction("ShowList");
        }
        // Thao tác xóa
        [HttpGet]
        public ActionResult Delete(string id)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbCHUYENDI tim = db.tbCHUYENDIs.Find(id);
            return View(tim);
        }
        [HttpPost]
        public ActionResult Delete(tbCHUYENDI tim)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            // tìm đối tượng
            tbCHUYENDI xoa = db.tbCHUYENDIs.Find(tim.MaChuyen);
            // lệnh xóa
            db.tbCHUYENDIs.Remove(xoa);
            // lưu lại
            db.SaveChanges();
            return RedirectToAction("ShowList");
        }
        public ActionResult Details(string id)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbCHUYENDI chitiet = db.tbCHUYENDIs.Find(id);
            return View(chitiet);
        }
    }
}
