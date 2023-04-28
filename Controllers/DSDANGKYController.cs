using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTDL22.Models;
namespace QLTDL22.Controllers
{
    public class DSDANGKYController : Controller
    {
        // GET: DSDANGKY
        public ActionResult ShowList()
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            List<tbDANGKY> dsdangky = db.tbDANGKies.ToList();
            return View(dsdangky);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbDANGKY themdangky)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            if (ModelState.IsValid)
            {
                if (themdangky.SoDangKy == null || themdangky.SoDangKy == default(int))
                {
                    ModelState.AddModelError("SoDangKy", "Số đăng ký không được để trống!");
                }
                else if (db.tbDANGKies.Any(them => them.SoDangKy == themdangky.SoDangKy))
                {
                    ModelState.AddModelError("SoDangKy", "Số đăng ký đã tồn tại!");
                }
                else
                {
                    db.tbDANGKies.Add(themdangky);
                    db.SaveChanges();
                    return RedirectToAction("ShowList");
                }
            }
            return View(themdangky);
        }

        public ActionResult Edit(int id)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbDANGKY edit = db.tbDANGKies.Find(id);
            return View(edit);
        }
        [HttpPost]
        public ActionResult Edit(tbDANGKY edit)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            var updatemodel = db.tbDANGKies.Find(edit.SoDangKy);
            updatemodel.MaKhach = edit.MaKhach;
            updatemodel.MaChuyen = edit.MaChuyen;
            updatemodel.NgayDangKy = edit.NgayDangKy;
            updatemodel.TienDatCoc = edit.TienDatCoc;
            updatemodel.TienTraLan2 = edit.TienTraLan2;
            db.SaveChanges();
            return RedirectToAction("ShowList");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbDANGKY tim = db.tbDANGKies.Find(id);
            return View(tim);
        }
        [HttpPost]
        public ActionResult Delete(tbDANGKY tim)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbDANGKY xoa = db.tbDANGKies.Find(tim.MaChuyen);
            db.tbDANGKies.Remove(xoa);
            db.SaveChanges();
            return RedirectToAction("showList");
        }
        public ActionResult Details(int id)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbDANGKY chitiet = db.tbDANGKies.Find(id);
            return View(chitiet);
        }

    }
}