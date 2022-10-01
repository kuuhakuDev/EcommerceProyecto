using AutoMapper;
using Data.Models.Repository;
using Dominio.Utils.Mapper;
using System.Linq.Expressions;

namespace Dominio.Utils
{
    public abstract class GeneralService<TData, TDto> where TData : class where TDto : class
    {
        protected readonly IRepository _repository;
        protected readonly IMapper _mapper;
        public GeneralService(IRepository respository)
        {
            _repository = respository;
            _mapper = MapperService.InitializeAutoMapper().CreateMapper();
        }

        public virtual IQueryable<TDto> GetData(Expression<Func<TDto, bool>> expression)
        {
            var expressionData = _mapper.Map<Expression<Func<TData, bool>>>(expression);
            var data = _repository.LoadAsNoTracking<TData>().Where(expressionData);
            return _mapper.ProjectTo<TDto>(data);
        }
        public virtual IQueryable<TDto> GetData()
            => GetData(data => true);

        public virtual async Task<TDto> Insert(TDto value)
        {
            var data = _mapper.Map<TData>(value);
            _repository.Create(data);
            await _repository.SaveChangesAsync();
            var dto = _mapper.Map<TDto>(data);
            return dto;
        }
        public virtual async Task<TDto> Update(TDto value)
        {
            var data = _mapper.Map<TData>(value);
            _repository.Update(data);
            await _repository.SaveChangesAsync();
            var dto = _mapper.Map<TDto>(data);
            return dto;
        }
        public virtual async Task<TDto> Delete(TDto value)
        {
            var data = _mapper.Map<TData>(value);
            _repository.Delete(data);
            await _repository.SaveChangesAsync();
            return value;
        }

        public void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
