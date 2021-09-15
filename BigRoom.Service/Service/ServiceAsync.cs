using AutoMapper;
using BigRoom.Repository.Common;
using BigRoom.Repository.IRepository;
using BigRoom.Service.Common.Models;
using BigRoom.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BigRoom.Service.Service
{
    public class ServiceAsync<TEntity, TDto> : IServiceAsync<TEntity, TDto> 
        where TDto : EntityDto where TEntity : Entity
    {
        private readonly IRepositoryAsync<TEntity> _repository;
        private readonly IMapper _mapper;

        public ServiceAsync(IRepositoryAsync<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(TDto tDto)
        {
            var entity = _mapper.Map<TEntity>(tDto);
            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(await _repository.GetByIdAsync(id));
        }

        public IEnumerable<TDto> GetAll(Expression<Func<TDto, bool>> expression = null)
        {
            var predicate = _mapper.Map<Expression<Func<TEntity, bool>>>(expression);
            return _repository.GetAll(predicate).Select(_mapper.Map<TDto>).ToList();
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> GetFirstAsync(Expression<Func<TDto, bool>> expression)
        {
            var predicate = _mapper.Map<Expression<Func<TEntity, bool>>>(expression);
            var entity = await _repository.GetFirstAsync(predicate);
            return _mapper.Map<TDto>(entity);
        }

        public async Task UpdateAsync(TDto entityTDto)
        {
            var entity = _mapper.Map<TEntity>(entityTDto);
            await _repository.UpdateAsync(entity);
        }
    }
}