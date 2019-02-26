using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POCOi.Domain.OfertasContext.Repositories;
using Newtonsoft.Json;

namespace POCOi.Web.Controllers
{
    public class OfertasController : Controller
    {
        private readonly IOfertasRepository _repository;

        public OfertasController(IOfertasRepository repository)
        {
            _repository = repository;
        }
        
        public ActionResult CarregaOfertas()
        {
            return View("_ListOfertas", _repository.Get());
        }

    }
}