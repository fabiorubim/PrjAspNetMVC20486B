using DemoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoApi.Controllers
{
    public class LivrosController : ApiController
    {
        private readonly LivroDB _ctx = new LivroDB();
        public Livro Post(Livro livro)
        {
            if (ModelState.IsValid)
            {
                _ctx.Livros.Add(livro);
                _ctx.SaveChanges();                
            }

            return livro;
        }

        public IEnumerable<Livro> Get()
        {
            return _ctx.Livros.ToList();
        }

        public Livro Get(int Id)
        {
            return _ctx.Livros.Find(Id);
        }

        public HttpResponseMessage Put(int id, Livro livro)
        {
            if (id != livro.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                _ctx.Entry(livro).State = System.Data.EntityState.Modified;
                _ctx.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Accepted,livro);
            }
        }

        public void Delete(int id)
        {
            var livro = _ctx.Livros.Find(id);
            _ctx.Livros.Remove(livro);
            _ctx.SaveChanges();
        }


        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }

    }
}
