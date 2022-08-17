namespace Participant.Application.Contracts.Services.Shared
{
    public interface IMapperServices
    {
        TOutput MapObjects<TInput, TOutput>(TInput input);
        TOutput MapObjects<TInput, TOutput>(TInput input, TOutput output);
    }
}
