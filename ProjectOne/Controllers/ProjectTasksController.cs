#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectOne.Models;

namespace ProjectOne.Controllers
{
    public class ProjectTasksController : Controller
    {
        private readonly ProjectDBexaContext _context;
       

        public ProjectTasksController(ProjectDBexaContext context)
        {
            _context = context;
            
            
        }

        // GET: ProjectTasks
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["DescriptionSort"] = String.IsNullOrEmpty(sortOrder) ? "desc_sort" : "";
            ViewData["StatusSort"] = sortOrder == "Status" ? "status_desc" : "Status";
            ViewData["ProjectSort"] = sortOrder == "Project" ? "project_desc" : "Project";
            ViewData["ResourceSort"] = sortOrder == "Resource" ? "resource_desc" : "Resource";
            var projecttasks = (from s in _context.ProjectTasks select s).Include(p => p.Project).Include(p => p.Resource).ToList();
            switch (sortOrder)
            {
                case "desc_sort":
                    projecttasks = projecttasks.OrderByDescending(s => s.Description).ToList();
                    break;
                case "Status":
                    projecttasks = projecttasks.OrderBy(s => s.Status).ToList();
                    break;
                case "status_desc":
                    projecttasks = projecttasks.OrderByDescending(s => s.Status).ToList();
                    break;
                case "Project":
                    projecttasks = projecttasks.OrderBy(s => s.Projectid).ToList();
                    break;
                case "project_desc":
                    projecttasks = projecttasks.OrderByDescending(s => s.Projectid).ToList();
                    break;

                case "Resource":
                    projecttasks = projecttasks.OrderBy(s => s.Resourceid).ToList();
                    break;
                case "resource_desc":
                    projecttasks = projecttasks.OrderByDescending(s => s.Resourceid).ToList();
                    break;
                default:
                    projecttasks = projecttasks.OrderBy(s => s.Description).ToList();
                    break;
            }
            return View(projecttasks.ToList());
        }

        // GET: ProjectTasks/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTask = await _context.ProjectTasks
                .Include(p => p.Project)
                .Include(p => p.Resource)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectTask == null)
            {
                return NotFound();
            }

            return View(projectTask);
        }

        // GET: ProjectTasks/Create
        public IActionResult Create()
        {
            ViewData["Projectid"] = new SelectList(_context.Projects, "Id", "Id");
            ViewData["Resourceid"] = new SelectList(_context.Resources, "Id", "Id");
            return View();
        }

        // POST: ProjectTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Resourceid,Projectid,Description,Status,Id")] ProjectTask projectTask)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(projectTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Projectid"] = new SelectList(_context.Projects, "Id", "Id", projectTask.Projectid);
            ViewData["Resourceid"] = new SelectList(_context.Resources, "Id", "Id", projectTask.Resourceid);
            return View(projectTask);
        }

        // GET: ProjectTasks/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTask = await _context.ProjectTasks.FindAsync(id);
            if (projectTask == null)
            {
                return NotFound();
            }
            ViewData["Projectid"] = new SelectList(_context.Projects, "Id", "Id", projectTask.Projectid);
            ViewData["Resourceid"] = new SelectList(_context.Resources, "Id", "Id", projectTask.Resourceid);
            return View(projectTask);
        }

        // POST: ProjectTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Resourceid,Projectid,Description,Status,Id")] ProjectTask projectTask)
        {
            if (id != projectTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectTaskExists(projectTask.Id))
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
            ViewData["Projectid"] = new SelectList(_context.Projects, "Id", "Id", projectTask.Projectid);
            ViewData["Resourceid"] = new SelectList(_context.Resources, "Id", "Id", projectTask.Resourceid);
            return View(projectTask);
        }

        // GET: ProjectTasks/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTask = await _context.ProjectTasks
                .Include(p => p.Project)
                .Include(p => p.Resource)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectTask == null)
            {
                return NotFound();
            }

            return View(projectTask);
        }

        // POST: ProjectTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var projectTask = await _context.ProjectTasks.FindAsync(id);
            _context.ProjectTasks.Remove(projectTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectTaskExists(long id)
        {
            return _context.ProjectTasks.Any(e => e.Id == id);
        }
    }
}
