using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Preference.Data;
using Preference.Models;

namespace Preference.Controllers
{
    /// <summary>
    /// Issues controller class.
    /// </summary>
    public class IssuesController : Controller
    {
        /// <summary>
        /// Preference DbContext 
        /// </summary>
        private readonly PreferenceContext _context;

        public IssuesController(PreferenceContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: Issues.
        /// </summary>
        /// <returns>Index view.</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Issue.Include(i => i.Severity).Include(i => i.Status).ToListAsync());
        }

        /// <summary>
        /// GET: Issues/Details/5.
        /// </summary>
        /// <param name="id">Issue's Id.</param>
        /// <returns>Details view.</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issue = await _context.Issue.Include(i => i.Severity).Include(i => i.Status).FirstOrDefaultAsync(m => m.Id == id);

            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        /// <summary>
        /// GET: Issues/Create.
        /// </summary>
        /// <returns>Create view.</returns>
        public async Task<IActionResult> Create()
        {
            ViewData["Severities"] = new SelectList(await _context.Severity.ToListAsync(), "Id", "Description");
            ViewData["Statuses"] = new SelectList(await _context.Status.ToListAsync(), "Id", "Description");

            return View();
        }

        /// <summary>
        /// POST: Issues/Create.
        /// To protect from overposting attacks, enable the specific properties you want to bind to.
        /// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="issue">Issue's data.</param>
        /// <returns>Index view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,SeverityId,StatusId,Asignee")] Issue issue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(issue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(issue);
        }

        /// <summary>
        /// GET: Issues/Edit/5.
        /// </summary>
        /// <param name="id">Issue' Id.</param>
        /// <returns>Edit view.</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issue = await _context.Issue.FindAsync(id);

            if (issue == null)
            {
                return NotFound();
            }

            ViewData["Severities"] = new SelectList(await _context.Severity.ToListAsync(), "Id", "Description");
            ViewData["Statuses"] = new SelectList(await _context.Status.ToListAsync(), "Id", "Description");

            return View(issue);
        }

        /// <summary>
        /// POST: Issues/Edit/5.
        /// To protect from overposting attacks, enable the specific properties you want to bind to.
        /// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="id">Issue's Id.</param>
        /// <param name="issue">Issue`s data.</param>
        /// <returns>Index view.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,SeverityId,StatusId,Asignee")] Issue issue)
        {
            if (id != issue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(issue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssueExists(issue.Id))
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
            return View(issue);
        }

        /// <summary>
        /// GET: Issues/Delete/5.
        /// </summary>
        /// <param name="id">Issue's Id.</param>
        /// <returns>Delete view.</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issue = await _context.Issue.FirstOrDefaultAsync(m => m.Id == id);

            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        /// <summary>
        /// POST: Issues/Delete/5.
        /// </summary>
        /// <param name="id">Issue's Id.</param>
        /// <returns>Index view.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var issue = await _context.Issue.FindAsync(id);
            _context.Issue.Remove(issue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Check if exist issue.
        /// </summary>
        /// <param name="id">Issue's Id.</param>
        /// <returns><c>True</c> if exists.</returns>
        private bool IssueExists(int id)
        {
            return _context.Issue.Any(e => e.Id == id);
        }

        /// <summary>
        /// GET: Issues/VueList.
        /// </summary>
        /// <returns>VueList view.</returns>
        public async Task<IActionResult> VueList()
        {
            var vueListViewModel = new VueListViewModel
            {
                Issues = await _context.Issue.ToListAsync(),
                Severities = await _context.Severity.ToListAsync(),
                Statuses = await _context.Status.ToListAsync()
            };

            return View(vueListViewModel);
        }

        /// <summary>
        /// Auto save issue`s data.
        /// </summary>
        /// <param name="issue">Issue's data</param>
        /// <returns><c>True</c> if saved</returns>
        [HttpPost]
        public async Task<ActionResult> AutoSave([Bind("Id,Title,SeverityId,StatusId,Asignee")] Issue issue)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(issue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssueExists(issue.Id))
                    {
                        return Json(false);
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(true);
            }
            return Json(false);
        }

    }
}
