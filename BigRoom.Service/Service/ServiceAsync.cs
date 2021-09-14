using AutoMapper;
using BigRoom.Repository.Common;
using BigRoom.Repository.IRepository;
using BigRoom.Service.Common.Models;
using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.Service
{
    public class ServiceAsync<TEntity, TDto> : IServiceAsync<TEntity,TDto> where TDto : EntityDto where TEntity : Entity
    {
        private readonly IUniteOfWork _unitOfWork;
        private readonly IRepositoryAsync<TEntity> _repository;
        private readonly IMapper _mapper;
        public ServiceAsync(IUniteOfWork unitOfWork, IRepositoryAsync<TEntity> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(TDto tDto)
        {
            var entity = _mapper.Map<TEntity>(tDto);
            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(await _repository.GetByIdAsync(id));
            await _unitOfWork.SaveChangesAsync();
        }


        public  IEnumerable<TDto> GetAll(Func<TDto, bool> expression = null)
        {
            var predicate = _mapper.Map<Expression<Func<TEntity,bool>>>(expression);
            return  _repository.GetAll(predicate).Select(_mapper.Map<TDto>).ToList(); ;
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var entity =await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<int> UpdateAsync(TDto entityTDto)
        {
            var entity = _mapper.Map<TEntity>(entityTDto);
            await _repository.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity.Id;
        }
    }
}
