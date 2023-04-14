using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTDL22.Models;
namespace QLTDL22.Controllers
{
    public class DSKHACHController : Controller
    {
        // Thao tác hiện danh sách
        public ActionResult ShowList()
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            List<tbKHACH> dsKhach = db.tbKHACHes.ToList();
            return View(dsKhach);
        }
        // Thao tác thêm
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbKHACH themkhach)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();       
            db.tbKHACHes.Add(themkhach);
            // lưu lại thay đổi
            db.SaveChanges();
            return RedirectToAction("ShowList");
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
        public ActionResult Delete(tbKHACH xoa)
        {
            QLTourDuLichBaLoEntities db = new QLTourDuLichBaLoEntities();
            // tìm đối tượng
            tbKHACH xoadl = db.tbKHACHes.Find(xoa.MaKhach);
            // lệnh xóa
            db.tbKHACHes.Remove(xoadl);
            // lưu lại
            db.SaveChanges();
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