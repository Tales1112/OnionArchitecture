using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepositort, IMapper mapper)
        {
            _categoryRepository = categoryRepositort;
            _mapper = mapper;
        }

        public async Task Add(CategoryDTO category)
        {
            var mapCategory = _mapper.Map<Category>(category);
            await _categoryRepository.Create(mapCategory);
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var result = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDTO>(result);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var result = await _categoryRepository.GetCategories();
            return _mapper.Map<IEnumerable<CategoryDTO>>(result);
        }

        public async Task Remove(CategoryDTO category)
        {
            var mapProduct = await _categoryRepository.GetById(category.Id);
            await _categoryRepository.Remove(mapProduct);
        }

        public async Task Update(CategoryDTO category)
        {
            var mapCategory = _mapper.Map<Category>(category);
            await _categoryRepository.Update(mapCategory);
        }
    }
}
