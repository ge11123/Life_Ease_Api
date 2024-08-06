using AutoMapper;
using LifeManage.src.Application.Handlers.Ledger;
using LifeManage.src.Domain.Entities;

namespace LifeManage.src.Application.profiles
{
	public class StoreVisitProfile : Profile
	{
        public StoreVisitProfile()
        {
			CreateMap<StoreVisit, StoreVisit>();
			CreateMap<CreateLedgerCommand, StoreVisit>();
		}
	}
}
