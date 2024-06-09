using Framework.Core;
using Framework.Service.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Controller
{
    public class BaseController<TEntity> : ControllerBase where TEntity : BaseEntity
    {
        protected readonly IServiceProvider _serviceProvider;
        protected IBaseService<TEntity> _service;
        public BaseController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _service = _serviceProvider.GetRequiredService<IBaseService<TEntity>>();
        }

        [HttpPost("AddAsync")]
        public async Task AddAsync(TEntity entity)
        {
            await _service.AddAsync(entity);
        }

        [HttpPost("Delete")]
        public void Delete(TEntity entity)
        {
            _service.Delete(entity);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("GetById")]
        public async Task<TEntity> GetByIdAsync([FromQuery] int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpPut("Update")]
        public void Update(TEntity entity)
        {
            _service.Update(entity);
        }
    }
}
