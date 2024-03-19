using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly DataContext dataContext;

        public AlunoController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(this.dataContext.Alunos);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = this.dataContext.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string Sobrenome)
        {
            var aluno = this.dataContext.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(Sobrenome));
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }


        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {

            this.dataContext.Add(aluno);
            this.dataContext.SaveChanges(); 

            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {

           var alu = this.dataContext.Alunos.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if(alu == null)
              return BadRequest("Aluno não encontrado");

            this.dataContext.Update(aluno);
            this.dataContext.SaveChanges(); 
            
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {

            var alu = this.dataContext.Alunos.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if(alu == null)
              return BadRequest("Aluno não encontrado");
  
            this.dataContext.Update(aluno);
            this.dataContext.SaveChanges();  
            return Ok(aluno);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

           var aluno = this.dataContext.Alunos.FirstOrDefault(x => x.Id == id);
            if(aluno == null)
              return BadRequest("Aluno não encontrado");

             this.dataContext.Remove(aluno);
            this.dataContext.SaveChanges(); 

            return Ok();
        }

    }
}