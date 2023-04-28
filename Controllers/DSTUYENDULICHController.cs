using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTDL22.Models;
namespace QLTDL22.Controllers
{
    public class DSTUYENDULICHController : Controller
    {
        // GET: DSTUYENDULICH
        public ActionResult ShowList()
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            List<tbTUYENDULICH> dstuyendulich = db.tbTUYENDULICHes.ToList();
            return View(dstuyendulich);
        }
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(tbTUYENDULICH themtuyendulich)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            db.tbTUYENDULICHes.Add(themtuyendulich);
            return RedirectToAction("ShowList");
        }
        public ActionResult Edit(String id)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbTUYENDULICH edit = db.tbTUYENDULICHes.Find(id);
            return View(edit);
        }
        [HttpPost]
        public ActionResult Edit(tbTUYENDULICH edit)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            var updatemodel = db.tbTUYENDULICHes.Find(edit.MaTuyen);
            updatemodel.TenTuyen = edit.TenTuyen;
            updatemodel.SoNgay = edit.SoNgay;
            db.SaveChanges();
            return RedirectToAction("ShowList");
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbTUYENDULICH tim = db.tbTUYENDULICHes.Find(id);
            return View(tim);
        }
        public ActionResult Delete(tbTUYENDULICH tim)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbTUYENDULICH xoa = db.tbTUYENDULICHes.Find(tim.MaTuyen);
            db.tbTUYENDULICHes.Remove(xoa);
            db.SaveChanges();
            return RedirectToAction("ShowList");
        }
        public ActionResult Details(string id)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbTUYENDULICH chitiet = db.tbTUYENDULICHes.Find(id);
            return View(chitiet);
        }
    }
}