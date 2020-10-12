using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.API.Domain.Models;
using WebAPI.API.Domain.Repositories;
using WebAPI.API.Domain.Services.Communication;

namespace WebAPI.API.Domain.Services
{
    public class YEntitieservice : IYEntitieservice
    {
        private readonly IYEntityRepository _yEntityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public YEntitieservice(IYEntityRepository yEntityRepository, IUnitOfWork unitOfWork)
        {
            _yEntityRepository = yEntityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<YEntityResponse> DeleteAsync(int id)
        {
            var existingYEntity = await _yEntityRepository.FindByIdAsync(id);
            if (null == existingYEntity)
            {
                return new YEntityResponse($"YEntity with id={id} not found.");
            }
            try
            {
                 _yEntityRepository.Remove(existingYEntity);
                 await _unitOfWork.CompleteAsync();

                 return new YEntityResponse(existingYEntity); 
            }
            catch(System.Exception ex)
            {
                return new YEntityResponse($"An error occurred when deleting the yEntity, {existingYEntity}: {ex.Message}");
            }
        }

        public async Task<YEntityResponse> FindByIdAsync(int id)
        {
            var existingYEntity = await _yEntityRepository.FindByIdAsync(id);
            if (null == existingYEntity)
            {
                return new YEntityResponse($"YEntity with id={id} not found.");
            }

            return new YEntityResponse(existingYEntity);

        }

        public async Task<IEnumerable<YEntity>> ListAsync()
        {
            return await _yEntityRepository.ListAsync();
        }

        public async Task<YEntityResponse> SaveAsync(YEntity yEntity)
        {
            try
            {
                await _yEntityRepository.AddAsync(yEntity);
                await _unitOfWork.CompleteAsync();

                return new YEntityResponse(yEntity);
            }
            catch (System.Exception ex)
            {
                return new YEntityResponse($"An error occurred when saving the yEntity, {yEntity}: {ex.Message}");                
            }
        }

        public async Task<YEntityResponse> UpdateAsync(int id, YEntity yEntity)
        {
            var existingYEntity = await _yEntityRepository.FindByIdAsync(id);
            if (null == existingYEntity)
            {
                return new YEntityResponse($"YEntity with id={id} not found.");
            }

            existingYEntity.Name = yEntity.Name;
            //TODO add other properties.
            try
            {
                _yEntityRepository.Update(yEntity);
                await _unitOfWork.CompleteAsync();

                return new YEntityResponse(existingYEntity);
            }
            catch (System.Exception ex)
            {
                return new YEntityResponse($"An error occurred when updating the yEntity, {existingYEntity}: {ex.Message}");
            }
        }
    }
}