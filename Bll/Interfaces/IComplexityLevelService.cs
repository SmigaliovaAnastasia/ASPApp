using ASPApp.Common.Dtos.GameDtos;

namespace ASPApp.Bll.Interfaces
{
    public interface IComplexityLevelService
    {
        Task<ComplexityLevelDto> GetComplexityLevelAsync(Guid id);
        Task<IEnumerable<ComplexityLevelDto>> GetAllComplexityLevelsAsync();
    }
}
