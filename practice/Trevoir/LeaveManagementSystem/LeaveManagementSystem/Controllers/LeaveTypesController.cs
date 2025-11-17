using AutoMapper;
using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models.LeaveTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LeaveTypesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var data = await _context.LeaveTypes.ToListAsync();
            // Convert data model to View Model (VM) by creating a new  VM object from it's VM class.

            // Option 1. Manual mapping/conversion
            var manualViewData = data.Select(q => new LeaveTypeReadOnlyVM
            {
                Id = q.Id,
                Name = q.Name,
                NumberOfDays = q.NumberOfDays
            });

            // Option 2. using AutoMapper 
            // Here we are mapping from a collection (data variable)
            var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);

            // return the View Model to the View
            return View(viewData);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveType == null)
            {
                return NotFound();
            }

            // Manual mapping
            var manualViewData = new LeaveTypeReadOnlyVM
            {
                Id = leaveType.Id,
                Name = leaveType.Name,
                NumberOfDays = leaveType.NumberOfDays
            };

            // We r mapping from an obj (not a collection)
            var viewData = _mapper.Map<LeaveTypeReadOnlyVM>(leaveType);



            return View(viewData);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        // Before View Models
        //public async Task<IActionResult> Create([Bind("Id,Name,NumberOfDays")] LeaveType leaveType)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(leaveType);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(leaveType);
        //}

        public async Task<IActionResult> Create(LeaveTypeCreateVM model)
        {
            // Reference: Adding custom validation and model state error
            //if (model.Name.Contains("vacation"))
            //{
            //    ModelState.AddModelError(
            //        nameof(model.Name),
            //        errorMessage: "Leave Type should not contain word 'vacation'"
            //        );
            //}

            // Check if leave type exists
            if (await CheckIfLeaveTypesExists(model.Name))
            {
                ModelState.AddModelError(
                    key: nameof(model.Name),
                    errorMessage: $"{model.Name} already exists in the database."
                    );
            }

            if (ModelState.IsValid)
            {

                // Convert data from LeaveTypeCreateVM to LeaveType using AutoMapper
                var leaveType = _mapper.Map<LeaveType>(model);
                _context.Add(leaveType);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }

            // Manual mapping
            //var viewData = new LeaveTypeEditVM
            //{
            //    Id = leaveType.Id,
            //    Name = leaveType.Name,
            //    NumberOfDays = leaveType.NumberOfDays
            //};

            // using AutoMapper
            var viewData = _mapper.Map<LeaveTypeEditVM>(leaveType);

            return View(viewData);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        // Edit post method using Bind()
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NumberOfDays")] LeaveType leaveType)

        // Edit post method using DTO (Data Transfer Object (overposting))
        public async Task<IActionResult> Edit(int id, LeaveTypeEditVM leaveTypeEdit)
        {
            if (id != leaveTypeEdit.Id)
            {
                return NotFound();
            }
            // Check if the Leave Type name entered is already in the database
            if (await CheckIfLeaveTypeExistsOnEdit(leaveTypeEdit))
            {
                ModelState.AddModelError(
                    key: nameof(leaveTypeEdit.Name),
                    errorMessage: $"{leaveTypeEdit.Name} already exists in the database."
                    );
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var viewData = _mapper.Map<LeaveType>(leaveTypeEdit);
                    _context.Update(viewData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveTypeExists(leaveTypeEdit.Id))
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
            return View(leaveTypeEdit);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var viewData = _mapper.Map<LeaveTypeReadOnlyVM>(leaveType);
            return View(viewData);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType != null)
            {
                _context.LeaveTypes.Remove(leaveType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveTypeExists(int id)
        {
            return _context.LeaveTypes.Any(e => e.Id == id);
        }

        // Check if Leave Type exists in the database before adding a new one
        private async Task<bool> CheckIfLeaveTypesExists(string leaveType)

        {
            var leaveTypeToLower = leaveType.ToLower();

            return await _context.LeaveTypes
                .AnyAsync(q => q.Name.Equals(leaveTypeToLower));
        }
        private async Task<bool> CheckIfLeaveTypeExistsOnEdit(LeaveTypeEditVM leaveType)
        {
            var leaveTypeToLower = leaveType.Name.ToLower();

            return await _context.LeaveTypes
                .AnyAsync(q => q.Name.ToLower().Equals(leaveTypeToLower) &&
                q.Id != leaveType.Id);
        }
    }
}
