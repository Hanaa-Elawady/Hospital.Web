using AutoMapper;
using Hospital.Data.Entities.HospitalData.DrugStorage;
using Hospital.Service.Dto_s.Drugs;

namespace Hospital.Service.Dto_s.Profiles
{
	public class DrugProfile : Profile
	{
		public DrugProfile()
		{
			CreateMap<Drug, DrugDto>().ForMember(dest => dest.DrugTypeName, options => options.MapFrom(src => src.DrugType.DrugTypeName)).ReverseMap();
		}
	}
}
