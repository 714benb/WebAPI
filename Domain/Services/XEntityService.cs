using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.API.Domain.Models;
using WebAPI.API.Domain.Repositories;
using WebAPI.API.Domain.Services.Communication;

namespace WebAPI.API.Domain.Services
{
    public class XEntityService : IXEntityService
    {
        private readonly IXEntityRepository _xEntityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public XEntityService(IXEntityRepository xEntityRepository, IUnitOfWork unitOfWork)
        {
            _xEntityRepository = xEntityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<XEntityResponse> DeleteAsync(int id)
        {
            var existingXEntity = await _xEntityRepository.FindByIdAsync(id);
            if (null == existingXEntity)
            {
                return new XEntityResponse($"XEntity with id={id} not found.");
            }
            try
            {
                 _xEntityRepository.Remove(existingXEntity);
                 await _unitOfWork.CompleteAsync();

                 return new XEntityResponse(existingXEntity); 
            }
            catch(System.Exception ex)
            {
                return new XEntityResponse($"An error occurred when deleting the xEntity, {existingXEntity}: {ex.Message}");
            }
        }

        public async Task<XEntityResponse> FindByIdAsync(int id)
        {
            var existingXEntity = await _xEntityRepository.FindByIdAsync(id);
            if (null == existingXEntity)
            {
                return new XEntityResponse($"XEntity with id={id} not found.");
            }

            return new XEntityResponse(existingXEntity);

        }

        public async Task<IEnumerable<XEntity>> ListAsync()
        {
            return await _xEntityRepository.ListAsync();
        }

        public async Task<XEntityResponse> SaveAsync(XEntity xEntity)
        {
            try
            {
                await _xEntityRepository.AddAsync(xEntity);
                await _unitOfWork.CompleteAsync();

                return new XEntityResponse(xEntity);
            }
            catch (System.Exception ex)
            {
                return new XEntityResponse($"An error occurred when saving the xEntity, {xEntity}: {ex.Message}");                
            }
        }

        public async Task<XEntityResponse> UpdateAsync(int id, XEntity xEntity)
        {
            var existingXEntity = await _xEntityRepository.FindByIdAsync(id);
            if (null == existingXEntity)
            {
                return new XEntityResponse($"XEntity with id={id} not found.");
            }

            existingXEntity.Name = xEntity.Name;
            try
            {
                _xEntityRepository.Update(xEntity);
                await _unitOfWork.CompleteAsync();

                return new XEntityResponse(existingXEntity);
            }
            catch (System.Exception ex)
            {
                return new XEntityResponse($"An error occurred when updating the xEntity, {existingXEntity}: {ex.Message}");
            }
        }
    }
}