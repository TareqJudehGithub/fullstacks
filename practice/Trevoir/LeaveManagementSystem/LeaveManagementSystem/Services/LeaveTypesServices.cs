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

        #endregion
        public LeaveTypesServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Methods
        public async Task<List<LeaveTypeReadOnlyVM>> GetAll()
        {
            var data = await _context.LeaveTypes.ToListAsync();
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
        public async Task Edit(int id, LeaveTypeEditVM model)
        {
            var leaveType = _mapper.Map<LeaveType>(model);
            _context.Update(leaveType);
            await _context.SaveChangesAsync();

        }

        public async Task Create(int id, LeaveTypeCreateVM model)
        {
            var leaveType = _mapper.Map<LeaveType>(model);
            _context.Add(leaveType);
            await _context.SaveChangesAsync();
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