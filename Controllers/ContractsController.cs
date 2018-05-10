using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PublishingContractManager.Data;
using PublishingContractManager.Models;

namespace PublishingContractManager.Controllers
{
    public class ContractsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ContractsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Contracts
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var contracts = _context.Contracts.Include(c => c.Author).Include(c => c.Representative);

            if (!String.IsNullOrEmpty(searchString))
            {
                var selectedContracts = contracts.Where(c => c.Author.FullName.Contains(searchString)
                                                        || c.BookTitle.Contains(searchString)
                                                        || c.BookISBN.ToString().Contains(searchString)
                                                        || c.Id.ToString().Contains(searchString));
                return View(await selectedContracts.ToListAsync());
            }
            else
            {
                return View(await contracts.ToListAsync());
            }
        }

        // GET: Contracts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts
                .Include(c => c.Author)
                .Include(c => c.Representative)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // GET: Contracts/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "FullName" );
            ViewData["RepresentativeId"] = new SelectList(_context.Representatives, "Id", "FullName");
            TempData["Error"] = "None";
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookTitle,BookISBN,PageCount,CompletionDate,FixedPay,SalesForRoyalties,RoyaltyRate,Notes,CompanyApproval,CompanyApprovalDate,AuthorApproval,AuthorApprovalDate,CreationDate,AuthorId,RepresentativeId")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                
                if (contract.CompanyApprovalDate.Date >= contract.CreationDate.Date)
                {
                    if (contract.AuthorApprovalDate.Date >= contract.CreationDate.Date)
                    {
                        _context.Add(contract);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Error"] = "Author Approval Date cannot be earlier than Creation Date.";
                    }
                }
                else
                {
                    TempData["Error"] = "Company Approval Date cannot be earlier than Creation Date.";
                }
                
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "FullName", contract.AuthorId);
            ViewData["RepresentativeId"] = new SelectList(_context.Representatives, "Id", "FullName", contract.RepresentativeId);
            return View(contract);
        }
        

        // GET: Contracts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts.Include(c => c.Author).Include(c => c.Representative).SingleOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            TempData["Error"] = "None";
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookTitle,BookISBN,PageCount,CompletionDate,FixedPay,SalesForRoyalties,RoyaltyRate,Notes,CompanyApproval,CompanyApprovalDate,AuthorApproval,AuthorApprovalDate,CreationDate,AuthorId,RepresentativeId")] Contract contract)
        {
            if (id != contract.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (contract.CompanyApprovalDate.Date >= contract.CreationDate.Date)
                {
                    if (contract.AuthorApprovalDate.Date >= contract.CreationDate.Date)
                    {
                        try
                        {
                            _context.Update(contract);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!ContractExists(contract.Id))
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
                    else
                    {
                        TempData["Error"] = "Author Approval Date cannot be earlier than Creation Date.";
                    }
                }
                else
                {
                    TempData["Error"] = "Company Approval Date cannot be earlier than Creation Date.";
                }
            }
            
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts
                .Include(c => c.Author)
                .Include(c => c.Representative)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contract = await _context.Contracts.SingleOrDefaultAsync(m => m.Id == id);
            _context.Contracts.Remove(contract);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractExists(int id)
        {
            return _context.Contracts.Any(e => e.Id == id);
        }
    }
}
