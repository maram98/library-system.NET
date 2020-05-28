using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Maram_sTask.Models;
using Maram_sTask.ViewModels;

namespace Maram_sTask.Controllers
{
    public class booksController : Controller
    {
        private BooksEntities1 db = new BooksEntities1();

        // GET: books
        public ActionResult Index(string searchBy, string searchValue)
        {
            if(searchBy == "authorName")
            {
                var booksByAuthor = db.books.Where(value => value.author.authorName == searchValue).Include(b => b.author).Include(b => b.category);
                return View(booksByAuthor.ToList());
            } 
            else if (searchBy == "categoryName")
            {
                var booksByCategory = db.books.Where(value => value.category.categroyName == searchValue).Include(b => b.author).Include(b => b.category);
                return View(booksByCategory.ToList());
            }

            var books = db.books.Include(b => b.author).Include(b => b.category);
            return View(books.ToList());
        }

        // GET: books/Create
        public ActionResult Create()
        {
            ViewBag.authorId = new SelectList(db.authors, "Id", "authorName");
            ViewBag.categoryId = new SelectList(db.categories, "Id", "categroyName");
            return View();
        }

        // POST: books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,bookName,Description,PublicationYear,authorId,categoryId")] book book)
        {
            BookViewModel bookVm = new BookViewModel();
            if (ModelState.IsValid)
            {
                bookVm.Name = book.bookName;
                bookVm.Description = book.Description;
                bookVm.PublicationYear = book.PublicationYear;
                bookVm.AuthorId = book.authorId;
                bookVm.CategoryId = book.categoryId;
                db.books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.authorId = new SelectList(db.authors, "Id", "authorName", book.authorId);
            ViewBag.categoryId = new SelectList(db.categories, "Id", "categroyName", book.categoryId);
            return View(bookVm);
        }

        // GET: books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.authorId = new SelectList(db.authors, "Id", "authorName", book.authorId);
            ViewBag.categoryId = new SelectList(db.categories, "Id", "categroyName", book.categoryId);
            return View(book);
        }

        // POST: books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,bookName,Description,PublicationYear,authorId,categoryId")] book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.authorId = new SelectList(db.authors, "Id", "authorName", book.authorId);
            ViewBag.categoryId = new SelectList(db.categories, "Id", "categroyName", book.categoryId);
            return View(book);
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
