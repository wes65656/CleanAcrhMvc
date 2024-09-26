using System;
using System.Threading.Tasks;
using CleanArchMvc.Aplication.DTOs;
using CleanArchMvc.Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;
    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet]
    public async Task <IActionResult> Index()
    {
        var categories = await _categoryService.GetCategories();
        return View(categories);
    }

    [HttpGet()]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryDto category)
    {
        if (ModelState.IsValid)
        {
            await _categoryService.Add(category);
            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null) return NotFound();
        
        var categoryDto = await _categoryService.GetById(id);

        if (categoryDto is null) return NotFound();
        return View(categoryDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoryDto categoryDto)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _categoryService.Update(categoryDto);
            }
            catch (Exception problemException)
            {
                Console.WriteLine(problemException);
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(categoryDto);
    }

    [HttpGet()]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null) return NotFound();

        var categoryDto = await _categoryService.GetById(id);

        if (categoryDto is null) return NotFound();

        return View(categoryDto);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> ConfirmedDelete(int id)
    {
        await _categoryService.Remove(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null) 
            return NotFound();

        var categoryDto = await _categoryService.GetById(id);

        if (categoryDto is null) 
            return NotFound();
        
        return View(categoryDto);
    }
}