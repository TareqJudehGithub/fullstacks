using LeaveManagementSystem.Models.LeaveTypes;
using LeaveManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Controllers
{
    public class LeaveTypesController : Controller
    {
        #region Fields
        private readonly ILeaveTypesServices _leaveTypesService;
        #endregion

        #region Constructors
        public LeaveTypesController(
            ILeaveTypesServices leaveTypesService
            )
        {
            _leaveTypesService = leaveTypesService;
        }
        #endregion

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var viewData = await _leaveTypesService.GetAll();
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
            var leaveType = await _leaveTypesService.Get<LeaveTypeReadOnlyVM>(id: id.Value);

            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeCreateVM leaveTypeCreate)
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
            if (await _leaveTypesService.CheckIfLeaveTypeNameExists(leaveTypeCreate.Name))
            {
                ModelState.AddModelError(
                    key: nameof(leaveTypeCreate.Name),
                    errorMessage: $"{leaveTypeCreate.Name} already exists in the database."
                    );
            }

            if (ModelState.IsValid)
            {
                // Convert data from LeaveTypeCreateVM to LeaveType using AutoMapper
                await _leaveTypesService.Create(leaveTypeCreate);

                return RedirectToAction(nameof(Index));
            }

            return View(leaveTypeCreate);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var leaveType = await _leaveTypesService.Get<LeaveTypeEditVM>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        // Edit post method using DTO (Data Transfer Object (overposting))
        public async Task<IActionResult> Edit(int id, LeaveTypeEditVM leaveTypeEdit)
        {
            if (id != leaveTypeEdit.Id)
            {
                return NotFound();
            }
            // Check if the Leave Type name entered is already in the database
            if (await _leaveTypesService.CheckIfLeaveTypeNameExistsOnEdit(leaveTypeEdit))
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
                    await _leaveTypesService.Edit(leaveTypeEdit);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_leaveTypesService.LeaveTypeExists(leaveTypeEdit.Id))
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

            var leaveType = await _leaveTypesService.Get<LeaveTypeReadOnlyVM>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _leaveTypesService.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        // Reference: Controller code BEFORE implementing Service Layer
        //private void oldCrudActions()
        //{

        // GET: LeaveTypes
        // public async Task<IActionResult> Index()
        //{
        // var data = await _context.LeaveTypes.ToListAsync();
        // Convert data model to View Model (VM) by creating a new  VM object from it's VM class.

        // Option 1. Manual mapping/conversion
        //var manualViewData = data.Select(q => new LeaveTypeReadOnlyVM
        //// {
        //     Id = q.Id,
        //     Name = q.Name,
        //     NumberOfDays = q.NumberOfDays
        // });

        //    // Option 2. using AutoMapper 
        //    // Here we are mapping from a collection (data variable)
        //    var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);

        //    // return the View Model to the View
        //    return View(viewData);
        //}

        //// GET: LeaveTypes/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var leaveType = await _context.LeaveTypes
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (leaveType == null)
        //    {
        //        return NotFound();
        //    }

        //    // Manual mapping
        //    var manualViewData = new LeaveTypeReadOnlyVM
        //    {
        //        Id = leaveType.Id,
        //        Name = leaveType.Name,
        //        NumberOfDays = leaveType.NumberOfDays
        //    };

        //    // We r mapping from an obj (not a collection)
        //    var viewData = _mapper.Map<LeaveTypeReadOnlyVM>(leaveType);



        //    return View(viewData);
        //}

        //// GET: LeaveTypes/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: LeaveTypes/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> Create(LeaveTypeCreateVM model)
        //{
        //    // Reference: Adding custom validation and model state error
        //    //if (model.Name.Contains("vacation"))
        //    //{
        //    //    ModelState.AddModelError(
        //    //        nameof(model.Name),
        //    //        errorMessage: "Leave Type should not contain word 'vacation'"
        //    //        );
        //    //}

        //    // Check if leave type exists
        //    if (await CheckIfLeaveTypesExists(leaveTypeCreate.Name))
        //    {
        //        ModelState.AddModelError(
        //            key: nameof(leaveTypeCreate.Name),
        //            errorMessage: $"{leaveTypeCreate.Name} already exists in the database."
        //            );
        //    }

        //    if (ModelState.IsValid)
        //    {

        //        // Convert data from LeaveTypeCreateVM to LeaveType using AutoMapper
        //        var leaveType = _mapper.Map<LeaveType>(leaveTypeCreate);
        //        _context.Add(leaveType);

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(leaveTypeCreate);
        //}

        //// GET: LeaveTypes/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var leaveType = await _leaveTypesService.Get<LeaveTypeEditVM>(id: id.Value);
        //    if (leaveType == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(leaveType);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //// Edit post method using Bind()
        ////public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NumberOfDays")] LeaveType leaveType)

        //// Edit post method using DTO (Data Transfer Object (overposting))
        //public async Task<IActionResult> Edit(int id, LeaveTypeEditVM leaveTypeEdit)
        //{
        //    if (id != leaveTypeEdit.Id)
        //    {
        //        return NotFound();
        //    }
        //    // Check if the Leave Type name entered is already in the database
        //    if (await CheckIfLeaveTypeExistsOnEdit(leaveTypeEdit))
        //    {
        //        ModelState.AddModelError(
        //            key: nameof(leaveTypeEdit.Name),
        //            errorMessage: $"{leaveTypeEdit.Name} already exists in the database."
        //            );
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            await _leaveTypesService.Edit(id: id, leaveTypeEdit);
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!LeaveTypeExists(leaveTypeEdit.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(leaveTypeEdit);
        //}

        //// GET: LeaveTypes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var leaveType = await _context.LeaveTypes
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (leaveType == null)
        //    {
        //        return NotFound();
        //    }
        //    var viewData = _mapper.Map<LeaveTypeReadOnlyVM>(leaveType);
        //    return View(viewData);
        //}

        //// POST: LeaveTypes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var leaveType = await _context.LeaveTypes.FindAsync(id);
        //    if (leaveType != null)
        //    {
        //        _context.LeaveTypes.Remove(leaveType);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}














    }
}
