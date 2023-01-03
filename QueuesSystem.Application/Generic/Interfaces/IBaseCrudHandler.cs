using QueuesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesSystem.Application.Generic.Interfaces
{
    public interface IBaseCrudHandler<TEntity> where TEntity : BaseEntity
    {
        Task<IQueryable<TEntity>> Query();
        Task<List<TDto>> GetAll<TDto>(int top = 50);
        Task<TDto> GetById<TDto>(int id);
        Task<TResponseDto> Create<TResponseDto, TRequestDto>(TRequestDto dto);
        Task<TResponseDto> Update<TResponseDto, TRequestDto>(TRequestDto dto);
        Task<bool> Delete(int id);
    }
}
