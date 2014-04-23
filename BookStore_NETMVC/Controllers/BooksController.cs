using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore_NETMVC.Models;

namespace BookStore_NETMVC.DAL
{
    public class BooksController : Controller
    {

        private BookContext db = new BookContext();

        public SelectList GetCategoryList()
        {
            return new SelectList(db.Category.ToArray(),"iCategoryID","strCategoryName");
        }

        // GET: /Books/Manage
        public ActionResult Index()
        {
            return View(db.Book.ToList());
        }

        // GET: /Books/
        public ActionResult Manage()
        {
            return View(db.Book.ToList());
        }

        // GET: /Books/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: /Books/Create
        public ActionResult Create()
        {
            ViewBag.Category = GetCategoryList();
            return View();
        }

        // POST: /Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book, HttpPostedFileBase strImagePath)
        {
            if (ModelState.IsValid)
            {
                if (strImagePath != null && strImagePath.ContentLength > 0)
                {
                    int lastId = 0;
                    try
                    {
                        lastId = db.Book.ToList().Last().iBookID;
                    }
                    catch { }

                    var pic = (lastId + 1) + ".jpg";
                    var path = System.IO.Path.Combine(
                                           Server.MapPath("~/Content/BookImage"), pic);
                    strImagePath.SaveAs(path);
                    book.strImagePath = pic;
                }
                db.Book.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: /Books/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.iCategoryID = new SelectList(db.Category, "iCategoryID", "strCategoryName", book.iCategoryID);
            return View(book);
        }

        // POST: /Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Category, "iCategoryID", "strCategoryName", book.iCategoryID);
            return View(book);
        }

        // GET: /Books/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: /Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Book.Find(id);
            db.Book.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Manage");
        }

        public ActionResult GetBookByCategoryID(int id)
        {
            var books = db.Book.Where(b => b.iCategoryID == id);
            return (View(books));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
