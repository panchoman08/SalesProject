using AutoMapper;
using SalesProject.Application.DTO.document.document;
using SalesProject.Application.DTO.document.documentType;
using SalesProject.Application.Interface;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Main
{
    public class DocumentApplication : IDocumentApplication
    {
        private readonly IDocumentDomain _documentDomain;
        private readonly IMapper _mapper;

        public DocumentApplication(IDocumentDomain documentDomain, IMapper mapper) 
        {
            _documentDomain = documentDomain;
            _mapper = mapper;
        }

        public async Task<Response<bool>> InsertAsync(DocumentCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var documentType = _mapper.Map<Document>(obj);
                response.Data = await _documentDomain.InsertAsync(documentType);
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

        public async Task<Response<bool>> UpdateAsync(int id, DocumentUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var documentType = _mapper.Map<Document>(obj);
                response.Data = await _documentDomain.UpdateAsync(id, documentType);
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
                response.Data = await _documentDomain.DeleteAsync(id);
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

        public async Task<Response<IEnumerable<DocumentDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<DocumentDTO>>();
            try
            {
                var documentsType = await _documentDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<DocumentDTO>>(documentsType);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<DocumentDTO>>> GetAllTthatContainsNameAsync(string name)
        {
            var response = new Response<IEnumerable<DocumentDTO>>();
            try
            {
                var documentsType = await _documentDomain.GetAllTthatContainsNameAsync(name);
                response.Data = _mapper.Map<IEnumerable<DocumentDTO>>(documentsType);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<DocumentDTO>> GetByIdAsync(int id)
        {
            var response = new Response<DocumentDTO>();
            try
            {
                var documentType = await _documentDomain.GetByIdAsync(id);
                response.Data = _mapper.Map<DocumentDTO>(documentType);
                response.IsSuccess = true;
                response.Message = "Query successfully.";

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<DocumentDTO>> GetByNameAsync(string name)
        {
            var response = new Response<DocumentDTO>();
            try
            {
                var documentType = await _documentDomain.GetByNameAsync(name);
                response.Data = _mapper.Map<DocumentDTO>(documentType);
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
