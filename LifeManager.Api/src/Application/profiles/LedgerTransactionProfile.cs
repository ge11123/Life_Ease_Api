using AutoMapper;
using LifeManage.src.Application.Handlers.Ledger;
using LifeManage.src.Domain.Entities;

namespace LifeManage.src.Application.profiles
{
	public class LedgerTransactionProfile : Profile
	{
        public LedgerTransactionProfile()
        {
			CreateMap<LedgerTransaction, LedgerTransaction>();
			CreateMap<CreateLedgerCommand, LedgerTransaction>()
				.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => 1))
				.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
				.ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));

			//CreateMap<CreateLedgerCommand, LedgerTransaction>()
			//	.ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now))
			//	.ConstructUsing(src => new LedgerTransaction
			//	{
			//		CategoryId = src.CategoryId,
			//		Amount = src.Amount,
			//		Note = src.Note,
			//		Date = src.Date,
			//	}).ReverseMap();

		}
	}
}
