using AutoMapper;
using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Services
{
    public class LeaveTypesServices : ILeaveTypesServices
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public LeaveTypesServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<List<LeaveTypeReadOnlyVM>> GetAll()
        {
            // Convert data model to View Model (VM) by creating a new  VM object from it's VM class.
            var data = await _context.LeaveTypes.ToListAsync();

            // Here we are mapping from a collection (the data variable above)
            // Reference: Option 1. Manual mapping/conversion
            var manualViewData = data.Select(q => new LeaveTypeReadOnlyVM
            {
                Id = q.Id,
                Name = q.Name,
                NumberOfDays = q.NumberOfDays
            });

            // Using AutoMapper 
            var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);
            return viewData;
        }
        public async Task<T?> Get<T>(int id) where T : class
        {
            var data = await _context.LeaveTypes.FirstOrDefaultAsync(q => q.Id == id);
            if (data == null)
            {
                return null;
            }
            // We r mapping from an obj (not a collection)
            var viewData = _mapper.Map<T>(data);
            return viewData;
        }
        public async Task Remove(int id)
        {
            var data = await _context.LeaveTypes
                .FirstOrDefaultAsync(q => q.Id == id);

            if (data != null)
            {
                _context.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Edit(LeaveTypeEditVM model)
        {
            var leaveType = _mapper.Map<LeaveType>(model);
            _context.Update(leaveType);
            await _context.SaveChangesAsync();


            // Manual mapping
            //var viewData = new LeaveTypeEditVM
            //{
            //    Id = leaveType.Id,
            //    Name = leaveType.Name,
            //    NumberOfDays = leaveType.NumberOfDays
            //};

        }

        public async Task Create(LeaveTypeCreateVM model)
        {
            var leaveType = _mapper.Map<LeaveType>(model);
            _context.Add(leaveType);
            await _context.SaveChangesAsync();
        }

        // Check if Leave Type exists in the database before adding a new one
        public async Task<bool> CheckIfLeaveTypeNameExists(string leaveType)

        {
            var leaveTypeToLower = leaveType.ToLower();

            return await _context.LeaveTypes
                .AnyAsync(q => q.Name.Equals(leaveTypeToLower));
        }
        public async Task<bool> CheckIfLeaveTypeNameExistsOnEdit(LeaveTypeEditVM leaveType)
        {
            var leaveTypeToLower = leaveType.Name.ToLower();

            return await _context.LeaveTypes
                .AnyAsync(q => q.Name.ToLower().Equals(leaveTypeToLower) &&
                q.Id != leaveType.Id);
        }
        public bool LeaveTypeExists(int id)
        {
            return _context.LeaveTypes.Any(q => q.Id == id);
        }
        #endregion
    }
}


// Details
//public async Task<LeaveTypeReadOnlyVM> LeaveTypeDetails(int Id)
//{
//    var data = await _context.LeaveTypes
//        .FirstOrDefaultAsync(q => q.Id == Id);
//    var viewData = _mapper.Map<LeaveTypeReadOnlyVM>(data);

//    return viewData;
//}