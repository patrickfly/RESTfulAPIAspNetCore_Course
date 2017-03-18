using Library.API.Entities;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    public class AuthorsController : Controller
    {
        private IPropertyMappingService _propertyMappingService;

        public AuthorsController(IPropertyMappingService propertyMappingService)
        {
            _propertyMappingService = propertyMappingService;
        }
        public IActionResult GetAuthors(AuthorsResourceParameters authorsResourceParameters)
        {
            if (!_propertyMappingService.ValidMappingExistsFor<AuthorDto, Author>(
                authorsResourceParameters.OrderBy))
            {
                return BadRequest();
            }

            //....
            return null;
        }


        private string CreateAuthorsResourceUri(
            AuthorsResourceParameters authorsResourceParameters,
            ResourceUriType type)
        {
            return null;
        }
    }
}
