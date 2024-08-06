using AutoMapper;
using LifeManage.src.Application.Handlers.Ledger;
using LifeManage.src.Domain.Entities;

namespace LifeManage.src.Application.profiles
{
	public class StoreCategoryLinkProfile : Profile
	{
		public StoreCategoryLinkProfile()
		{
			CreateMap<StoreCategoryLink, StoreCategoryLink>();
			CreateMap<CreateLedgerCommand, StoreCategoryLink>()
				.ForMember(dest => dest.LedgerCategoryId, opt => opt.MapFrom(src => src.CategoryId));
		}
	}
}
