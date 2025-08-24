using AOWebApp.Data;
using AOWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AOWebApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly Data.AmazonOrdersContext _context;

        public CustomersController(Data.AmazonOrdersContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index(CustomerSearchVM vm)
        {
            #region SuburbQuery
            var SuburbList = _context.Set<Addresses>()
                .Select(a => a.Suburb)
                .Distinct()
                .OrderBy(a => a)
                .ToList();

            ViewBag.SuburbList = new SelectList(SuburbList, vm.Suburb);
            #endregion

            #region Customer Query
            List<Customers> customersList = new List<Customers>();
            if (!string.IsNullOrWhiteSpace(vm.SearchText))
            {
                var Query = _context.Customers
                    .Include(c => c.Address)
                    .Where(c => vm.SearchText.Split().Length > 1
                    ? c.FirstName.Equals(vm.SearchText.Split()[0]) && c.LastName.Equals(vm.SearchText.Split()[1])
                    : c.FirstName.StartsWith(vm.SearchText) || c.LastName.StartsWith(vm.SearchText));

                if (!string.IsNullOrEmpty(vm.Suburb))
                {
                    Query = Query.Where(c => c.Address.Suburb == vm.Suburb);
                }
                Query = Query.OrderBy(c => vm.SearchText.Split().Length > 1
                ? c.FirstName.StartsWith(vm.searchText.Split()[0])
                : c.FirstName.StartsWith(vm.SearchText))
                .ThenBy(c => vm.SearchText.Split().Length > 1
                ? c.LastNane.Startswith(vm.searchText.Split()[1])
                : c.LastName.StartsWith(vm.SearchText));

                vm.CustomerList = await Query.ToListAsync();
            }

            #endregion
            return View(vm)
    }
                

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .Include(c => c.Address)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Set<Addresses>(), "AddressId", "AddressId");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,Email,MainPhoneNumber,SecondaryPhoneNumber,AddressId")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Set<Addresses>(), "AddressId", "AddressId", customers.AddressId);
            return View(customers);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Set<Addresses>(), "AddressId", "AddressId", customers.AddressId);
            return View(customers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName,Email,MainPhoneNumber,SecondaryPhoneNumber,AddressId")] Customers customers)
        {
            if (id != customers.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomersExists(customers.CustomerId))
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
            ViewData["AddressId"] = new SelectList(_context.Set<Addresses>(), "AddressId", "AddressId", customers.AddressId);
            return View(customers);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .Include(c => c.Address)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customers = await _context.Customers.FindAsync(id);
            if (customers != null)
            {
                _context.Customers.Remove(customers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomersExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
