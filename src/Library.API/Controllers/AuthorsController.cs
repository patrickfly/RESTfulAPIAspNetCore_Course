using AutoMapper;
using Library.API.Entities;
using Library.API.Helpers;
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
        private ITypeHelperService _typeHelperService;
        private ILibraryRepository _libraryRepository;

        public AuthorsController(IPropertyMappingService propertyMappingService,
            ITypeHelperService typeHelperService,
            ILibraryRepository libraryRepository)
        {
            _propertyMappingService = propertyMappingService;
            _typeHelperService = typeHelperService;
            _libraryRepository = libraryRepository;
        }


        public IActionResult GetAuthor(Guid id, [FromQuery] string fields)
        {
            if(!_typeHelperService.TypeHasProperties<AuthorDto>(fields))
            {
                return BadRequest();
            }

            var authorFromRepo = _libraryRepository.GetAuthor(id);

            if(authorFromRepo == null)
            {
                return NotFound();
            }

            var author = Mapper.Map<AuthorDto>(authorFromRepo);
            return Ok(author.ShapeData(fields));
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
