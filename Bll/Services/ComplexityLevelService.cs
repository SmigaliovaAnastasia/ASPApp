using ASPApp.Bll.Interfaces;
using ASPApp.Common.Dtos.GameDtos;
using ASPApp.Common.Exceptions;
using ASPApp.Dal.Repository.Interfaces;
using ASPApp.Domain.Entities;
using AutoMapper;

namespace ASPApp.Bll.Services
{
    public class ComplexityLevelService : IComplexityLevelService
    {
        private readonly IRepository<ComplexityLevel> _repository;
        private readonly IMapper _mapper;

        public ComplexityLevelService(IRepository<ComplexityLevel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ComplexityLevelDto>> GetAllComplexityLevelsAsync()
        {
            var complexityLevels = await _repository.GetAllAsync();
            if (complexityLevels == null || complexityLevels.Count() == 0)
            {
                throw new EntryNotFoundException("No complexity levels found.");
            }
            var complexityLevelDtos = _mapper.Map<IEnumerable<ComplexityLevel>, IEnumerable<ComplexityLevelDto>>(complexityLevels);
            return complexityLevelDtos;
        }

        public async Task<ComplexityLevelDto> GetComplexityLevelAsync(Guid id)
        {
            var complexityLevel = await _repository.GetByIdAsync(id);
            if (complexityLevel == null)
            {
                throw new EntryNotFoundException("The genre you are requesting doesn't exist");
            }
            return _mapper.Map<ComplexityLevelDto>(complexityLevel);
        }
    }
}
