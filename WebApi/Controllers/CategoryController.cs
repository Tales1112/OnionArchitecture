using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategories();

            if (categories == null)
                return NotFound();

            return Ok(categories);
        }
        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            await _categoryService.Add(categoryDTO);
            return new CreatedAtRouteResult("GetCategory",
                new { id = categoryDTO.Id }, categoryDTO);
        }
        [HttpPut("id")]
        public async Task<ActionResult> Put(int id,[FromBody] CategoryDTO categoryDTO)
        {
            if(id != categoryDTO.Id)
            {
                return BadRequest();
            }
            await _categoryService.Update(categoryDTO);

            return Ok(categoryDTO);
        }
        [HttpDelete("id")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var categoryDTO = await _categoryService.GetById(id);
            if (categoryDTO == null)
            {
                return NotFound();
            }
            await _categoryService.Remove(categoryDTO);
            return Ok(categoryDTO);
        }
    }
}
