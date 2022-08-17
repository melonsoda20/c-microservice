using AutoMapper;
using Participant.Application.Contracts.Services.Shared;

namespace Participant.Application.Services.Shared
{
    public class MapperServices : IMapperServices
    {
        private readonly IMapper _mapper;

        public MapperServices(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TOutput MapObjects<TInput, TOutput>(TInput input)
        {
            return _mapper.Map<TInput, TOutput>(input);
        }

        public TOutput MapObjects<TInput, TOutput>(TInput input, TOutput output)
        {
            _mapper.Map(input, output, typeof(TInput), typeof(TOutput));
            return output;
        }
    }
}
