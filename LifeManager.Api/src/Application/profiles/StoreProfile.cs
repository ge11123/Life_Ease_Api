using AutoMapper;
using LifeManage.src.Domain.Entities;

namespace LifeManage.src.Application.profiles
{
	public class StoreProfile : Profile
	{
        public StoreProfile()
        {
			CreateMap<Store, Store>();
		}
	}
}
