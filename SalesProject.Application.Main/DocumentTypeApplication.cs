using AutoMapper;
using SalesProject.Application.DTO.document.documentType;
using SalesProject.Application.Interface;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.Main
{
    public class DocumentTypeApplication : IDocumentTypeApplication
    {
        private readonly IDocumentTypeDomain _documentTypeDomain;
        private readonly IMapper _mapper;

        public DocumentTypeApplication(IDocumentTypeDomain documentTypeDomain, IMapper mapper)
        {
            _documentTypeDomain = documentTypeDomain;
            _mapper = mapper;
        }

        public async Task<Response<bool>> InsertAsync(DocumentTypeCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var documentType = _mapper.Map<DocumentType>(obj);
                response.Data = await _documentTypeDomain.InsertAsync(documentType);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register added successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(int id, DocumentTypeUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var documentType = _mapper.Map<DocumentType>(obj);
                response.Data = await _documentTypeDomain.UpdateAsync(id, documentType);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register updated successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _documentTypeDomain.DeleteAsync(id);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register deleted successfully.";
                }
            }
            catch (Exception ex)
            { 
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<DocumentTypeDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<DocumentTypeDTO>>();
            try
            {
                var documentsType = await _documentTypeDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<DocumentTypeDTO>>(documentsType);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<DocumentTypeDTO>>> GetAllTthatContainsNameAsync(string name)
        {
            var response = new Response<IEnumerable<DocumentTypeDTO>>();
            try
            {
                var documentsType = await _documentTypeDomain.GetAllTthatContainsNameAsync(name);
                response.Data = _mapper.Map<IEnumerable<DocumentTypeDTO>>(documentsType);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<DocumentTypeDTO>> GetByIdAsync(int id)
        {
            var response = new Response<DocumentTypeDTO>();
            try
            {
                var documentType = await _documentTypeDomain.GetByIdAsync(id);
                response.Data = _mapper.Map<DocumentTypeDTO>(documentType);
                response.IsSuccess = true;
                response.Message = "Query successfully.";

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<DocumentTypeDTO>> GetByNameAsync(string name)
        {
            var response = new Response<DocumentTypeDTO>();
            try
            {
                var documentType = await _documentTypeDomain.GetByNameAsync(name);
                response.Data = _mapper.Map<DocumentTypeDTO>(documentType);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                throw;
            }
            return response;
        }
    }
}
