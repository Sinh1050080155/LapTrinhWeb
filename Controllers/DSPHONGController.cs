using QLTDL22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTDL22.Controllers
{
    public class DSPHONGController : Controller
    {
        // GET: DSPHONG
        public ActionResult ShowList()
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            List<tbPHONG> dsphong = db.tbPHONGs.ToList();
            return View(dsphong);
            
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbPHONG themphong)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            db.tbPHONGs.Add(themphong);
            db.SaveChanges();
            return RedirectToAction("ShowList");

        }
        public ActionResult Edit(string id)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbPHONG edit = db.tbPHONGs.Find(id);
            return View(edit);
        }
        [HttpPost]
        public ActionResult Edit(tbPHONG edit)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            var updatemodel = db.tbPHONGs.Find(edit.MaLoaiPhong);
            updatemodel.KhachSan = edit.KhachSan;
            updatemodel.Gia1Ngay = edit.Gia1Ngay;
            updatemodel.CacTrangBiChoPhong = edit.CacTrangBiChoPhong;
            db.SaveChanges();
            return RedirectToAction("ShowList");
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbPHONG tim = db.tbPHONGs.Find(id);
            return View(tim);
        }
        [HttpPost]
        public ActionResult Delete(tbPHONG tim)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbPHONG xoa = db.tbPHONGs.Find(tim.MaLoaiPhong);
            db.tbPHONGs.Remove(xoa);
            db.SaveChanges();
            return RedirectToAction("ShowList");
        }
        public ActionResult Details(string id)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbPHONG chitiet = db.tbPHONGs.Find(id);
            return View(chitiet);
        }
    }
}