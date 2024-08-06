using AutoMapper;
using LifeManage.src.Application.Handlers.Ledger;
using LifeManage.src.Domain.Entities;

namespace LifeManage.src.Application.profiles
{
	public class LedgerCategoryProfile : Profile
	{
        public LedgerCategoryProfile()
        {
			CreateMap<LedgerCategory, LedgerCategory>();
			CreateMap<CreateLedgerCategoryCommand, LedgerCategory>()
				.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => 1));


		}
	}
}
