using QLTDL22.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTDL22.Controllers
{
    public class DSPHUONGTIENDICHUYENController : Controller
    {
        // GET: DSPHUONGTIENDICHUYEN
        public ActionResult ShowList()
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            List<tbPHUONGTIENDICHUYEN> dsphuongtien = db.tbPHUONGTIENDICHUYENs.ToList();
            return View(dsphuongtien);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbPHUONGTIENDICHUYEN themphuongtien)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            db.tbPHUONGTIENDICHUYENs.Add(themphuongtien);
            
            db.SaveChanges();
            return RedirectToAction("ShowList");
        }
        public ActionResult Edit(string id)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbPHUONGTIENDICHUYEN edit = db.tbPHUONGTIENDICHUYENs.Find(id);
            return View(edit);
        }
        [HttpPost]
        public ActionResult Edit(tbPHUONGTIENDICHUYEN edit)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            var updatemodel = db.tbPHUONGTIENDICHUYENs.Find(edit.MaPhuongTien);
            updatemodel.TenPhuongTien = edit.MaPhuongTien;
            updatemodel.GiaTien1DonVi = edit.GiaTien1DonVi;
            updatemodel.GhiChu = edit.GhiChu;
            db.SaveChanges();
            return RedirectToAction("ShowList");
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbPHUONGTIENDICHUYEN tim = db.tbPHUONGTIENDICHUYENs.Find(id);
            return View(tim);
        }
        [HttpPost]
        public ActionResult Delete(tbPHUONGTIENDICHUYEN tim)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbPHUONGTIENDICHUYEN xoa = db.tbPHUONGTIENDICHUYENs.Find(tim.MaPhuongTien);
            db.tbPHUONGTIENDICHUYENs.Remove(xoa);
            db.SaveChanges();
            return RedirectToAction("ShowList");
        }
        public ActionResult Details(string id)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            tbPHUONGTIENDICHUYEN chitiet = db.tbPHUONGTIENDICHUYENs.Find(id);
            return View(chitiet);
        }
    }
}