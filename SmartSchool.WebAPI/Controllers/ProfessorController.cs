using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        
       private readonly DataContext _dataContext;

        public ProfessorController(DataContext dataContext)
        {
            _dataContext = dataContext;
        } 

        [HttpGet]
        public IActionResult Get()
        {
            var professores = _dataContext.Professores;
            return Ok(professores);
        }
       
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var professor = _dataContext.Professores.FirstOrDefault(x => x.Id == id);  
            if(professor == null)
                return BadRequest("Professor não encontrado");
        
            return Ok(professor);
        }
          

        [HttpPost]
        public IActionResult Post(Professor professor)
        {

            _dataContext.Add(professor);
            _dataContext.SaveChanges();

            return Ok(professor);
        }
          

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            var professor = _dataContext.Professores.AsNoTracking().FirstOrDefault(x=> x.Id == id);
            if(professor == null) 
                   return BadRequest("Professor não encontrado");

            _dataContext.Update(professor);
            _dataContext.SaveChanges();

            return Ok(professor);
        }
          
        
        [HttpPatch("{id}")]
        public IActionResult Patch(int id)
        {
            var professor = _dataContext.Professores.AsNoTracking().FirstOrDefault(x=> x.Id == id);
            if(professor == null)
                return BadRequest("Professor não encontrado");

                _dataContext.Update(professor);
                _dataContext.SaveChanges();

            return Ok(professor);
        }
        
          
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _dataContext.Professores.AsNoTracking().FirstOrDefault(x=> x.Id == id);
             if(professor == null)
               return BadRequest("Professor não encontrado");

            _dataContext.Remove(professor);
            _dataContext.SaveChanges();

            return Ok("Professor deletado com sucesso");
        }
        

    }
}