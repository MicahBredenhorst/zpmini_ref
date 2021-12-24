using AutoMapper;
using ZPMini.API.ViewModel;
using ZPMini.Data.Entity;

namespace ZPMini.API
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            CreateMap<PatientViewModel, Patient>();
            CreateMap<PatientInformationViewModel, PatientInformation>();
            CreateMap<FacilityViewModel, HealthFacility>();
            CreateMap<Patient, HealthFacilityPatient>()
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(s => s.Id));
            CreateMap<HealthFacility, HealthFacilityPatient>()
                .ForMember(dest => dest.FacilityId, opt => opt.MapFrom(dest => dest.Id));
        }
    }
}
