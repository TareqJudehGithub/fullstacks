using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models.LeaveTypes;
using AutoMapper;

namespace LeaveManagementSystem.MappingProfiles
{
    // Profile parent class is from AutoMapper libary
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapping from LeaveType to IndexVM
            CreateMap<LeaveType, LeaveTypeReadOnlyVM>();
            // In case we needed to change destination property name to match the prop in original
            //   .ForMember(dest => dest.NumberOfDays, opt => opt.MapFrom(src => src.NumberOfDays));

            // Covert data coming from LeaveTypeCreateVM to LeaveType, then send it to the DB.
            CreateMap<LeaveTypeCreateVM, LeaveType>();
        }
    }
}
