using AutoMapper;
using DC = ApiJenkinsCC.ApiV2.API.DataContracts;
using S = ApiJenkinsCC.ApiV2.Services.Model;

namespace ApiJenkinsCC.ApiV2.IoC.Configuration.Profiles
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<S.User, DC.User>();
            CreateMap<S.Adress, DC.Adress>();
        }
    }
}
