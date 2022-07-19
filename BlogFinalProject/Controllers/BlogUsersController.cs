using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogFinalProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace BlogFinalProject.Controllers
{
    public class BlogUsersController : Controller
    {
        private readonly BlogUserContext _context;

        public BlogUsersController(BlogUserContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult More1()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult More()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Lifestories() 
        { return View(); 
        }
        // GET: BlogUsers
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.BlogUsers.ToListAsync());
        }

        // GET: BlogUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogUser = await _context.BlogUsers
                .FirstOrDefaultAsync(m => m.blogid == id);
            if (blogUser == null)
            {
                return NotFound();
            }

            return View(blogUser);
        }

        // GET: BlogUsers/Create
   
        public IActionResult Create()
        {
            return View();
        }

        // POST: BlogUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("blogid,title,content,TimeStamp")] BlogUser blogUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogUser);
        }

        // GET: BlogUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogUser = await _context.BlogUsers.FindAsync(id);
            if (blogUser == null)
            {
                return NotFound();
            }
            return View(blogUser);
        }

        // POST: BlogUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("blogid,title,content,TimeStamp")] BlogUser blogUser)
        {
            if (id != blogUser.blogid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogUserExists(blogUser.blogid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blogUser);
        }

        // GET: BlogUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogUser = await _context.BlogUsers
                .FirstOrDefaultAsync(m => m.blogid == id);
            if (blogUser == null)
            {
                return NotFound();
            }

            return View(blogUser);
        }

        // POST: BlogUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogUser = await _context.BlogUsers.FindAsync(id);
            _context.BlogUsers.Remove(blogUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogUserExists(int id)
        {
            return _context.BlogUsers.Any(e => e.blogid == id);
        }
    }
}
