using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core_Project.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Core_Project.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Core_Project.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class GuestsController : Controller
    {
        private readonly BookingDbContext _context;
        private readonly IWebHostEnvironment _he;

        public GuestsController(BookingDbContext context, IWebHostEnvironment he)
        {
            _context = context;
            _he = he;
        }
        public IActionResult Index()
        {
            return View(_context.Guests.Include(x => x.BookingEntries).ThenInclude(b => b.Room).ToList());
        }
        public IActionResult AddNewRoom(int? id)
        {
            ViewBag.Rooms = new SelectList(_context.Rooms.ToList(), "RoomId", "RoomType", id.ToString() ?? "");
            return PartialView("_addNewRoom");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(GuestVM guestVM, int[] GuestId)
        {
            if (ModelState.IsValid)
            {
                Guest guest = new Guest()
                {
                    GuestName = guestVM.GuestName,
                    CheckIn = guestVM.CheckIn,
                    Phone = guestVM.Phone,
                    MaritialStatus = guestVM.MaritialStatus
                };
                //Img
                string webroot = _he.WebRootPath;
                string folder = "Images";
                string imgFileName = Path.GetFileName(guestVM.PictureFile.FileName);
                string fileToWrite = Path.Combine(webroot, folder, imgFileName);

                using (var stream = new FileStream(fileToWrite, FileMode.Create))
                {
                    await guestVM.PictureFile.CopyToAsync(stream);
                    guest.Picture = "/" + folder + "/" + imgFileName;
                }
                foreach (var item in GuestId)
                {
                    BookingEntry bookingEntry = new BookingEntry()
                    {
                        Guest = guest,
                        GuestId = guest.GuestId,
                        RoomId = item
                    };
                    _context.BookingEntries.Add(bookingEntry);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            Guest guest = _context.Guests.First(x => x.GuestId == id);
            var diseseList = _context.BookingEntries.Where(x => x.GuestId == id).Select(x => x.RoomId).ToList();

            GuestVM guestVM = new GuestVM
            {
                GuestId = guest.GuestId,
                GuestName = guest.GuestName,
                CheckIn = DateTime.Now,
                Phone = guest.Phone,
                MaritialStatus = guest.MaritialStatus,
                RoomList = diseseList,
                Picture = guest.Picture,
            };
            return View(guestVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(GuestVM guestVM, int[] RoomId)
        {
            if (ModelState.IsValid)
            {
                Guest guest = new Guest()
                {
                    GuestId = guestVM.GuestId,
                    GuestName = guestVM.GuestName,
                    CheckIn = guestVM.CheckIn,
                    Phone = guestVM.Phone,
                    MaritialStatus = guestVM.MaritialStatus,
                    Picture = guestVM.Picture,
                };
                //img
                if (guestVM.PictureFile != null)
                {

                    string webroot = _he.WebRootPath;
                    string folder = "Images";
                    string imgFileName = Path.GetFileName(guestVM.PictureFile.FileName);
                    string fileToWrite = Path.Combine(webroot, folder, imgFileName);

                    using (var stream = new FileStream(fileToWrite, FileMode.Create))
                    {
                        await guestVM.PictureFile.CopyToAsync(stream);
                        guest.Picture = "/" + folder + "/" + imgFileName;
                    }
                }
                //exists diseselist
                var existsDisese = _context.BookingEntries.Where(x => x.GuestId == guestVM.GuestId).ToList();
                foreach (var item in existsDisese)
                {
                    _context.BookingEntries.Remove(item);
                }
                //add new diseseList
                foreach (var item in RoomId)
                {
                    BookingEntry bookingEntry = new BookingEntry()
                    {
                        GuestId = guest.GuestId,
                        RoomId = item
                    };
                    _context.BookingEntries.Add(bookingEntry);
                }
                _context.Entry(guest).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();

        }
        public async Task<IActionResult> Delete(int? id)
        {
            Guest guest = _context.Guests.First(x => x.GuestId == id);
            var roomList = _context.BookingEntries.Where(x => x.GuestId == id).ToList();
            foreach (var item in roomList)
            {
                _context.BookingEntries.Remove(item);
            }
            _context.Entry(guest).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}