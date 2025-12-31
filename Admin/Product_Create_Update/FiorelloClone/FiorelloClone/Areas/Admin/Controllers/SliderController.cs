using FiorelloClone.Areas.Admin.ViewModels.SliderVMs;
using FiorelloClone.Data;
using FiorelloClone.Helpers;
using FiorelloClone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloClone.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Slider> sliders = await _context.Sliders.Where(m => !m.IsDeleted).ToListAsync();

            IEnumerable<GetAllSliderVM> getAllSliderVMs = sliders.Select(s => new GetAllSliderVM
            {
                Id = s.Id,
                Image = s.Image
            });

            return View(getAllSliderVMs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSliderVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!request.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "File type must be image");
                return View();
            }

            if (request.Photo.CheckFileSize(2000))
            {
                ModelState.AddModelError("Photo", "Image size must be max 2MB");
                return View();
            }

            string fileName = request.Photo.GenerateFileName();
            string path = _env.WebRootPath.GetFilePath("img", fileName);

            request.Photo.SaveFile(path);

            Slider slider = new Slider
            {
                Image = fileName
            };
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            Slider? slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
            if (slider is null)
            {
                return NotFound();
            }
            UpdateSliderVM updateSliderVM = new UpdateSliderVM
            {
                Image = slider.Image
            };
            return View(updateSliderVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, UpdateSliderVM request)
        {
            if (id is null)
            {
                return BadRequest();
            }
            Slider? slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
            if (slider is null)
            {
                return NotFound();
            }

            if (request.Photo != null)
            {
                if (!request.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "File type must be image");
                    return View(request);
                }
                if (request.Photo.CheckFileSize(2000))
                {
                    ModelState.AddModelError("Photo", "Image size must be max 2MB");
                    request.Image = slider.Image;
                    return View(request);
                }
                string oldPath = _env.WebRootPath.GetFilePath("img", slider.Image);
                oldPath.DeleteFile();
                string fileName = request.Photo.GenerateFileName();
                string newPath = _env.WebRootPath.GetFilePath("img", fileName);
                request.Photo.SaveFile(newPath);
                slider.Image = fileName;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            Slider? slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
            if (slider is null)
            {
                return NotFound();
            }

            DetailSliderVM detailSliderVM = new()
            {
                Image = slider.Image
            };

            return View(detailSliderVM);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            Slider? slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);

            if (slider == null) return NotFound();

            string path = _env.WebRootPath.GetFilePath("img", slider.Image);

            path.DeleteFile();

            _context.Sliders.Remove(slider);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

}