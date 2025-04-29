using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Data;
using Movies.Api.Models;

namespace Movies.Api.Controllers;

[ApiController]
[Route("/api")]
public class MovieController : ControllerBase
{
    private readonly MovieContext _movieContext;

    public MovieController(MovieContext movieContext)
    {
        _movieContext = movieContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Movie>> GetMovie()
    {
        MovieContextSeed.SeedAsync(_movieContext);
        return Ok(_movieContext.Movies.ToList());
    }
}