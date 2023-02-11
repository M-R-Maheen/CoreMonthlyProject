using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;

namespace Core_Project.Models.ViewModels
{
    public class GuestVM
    {
        public GuestVM()
        {
            this.RoomList = new List<int>();
        }
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public DateTime CheckIn { get; set; }
        public string Phone { get; set; }
        public string Picture { get; set; }
        public IFormFile PictureFile { get; set; }
        public bool MaritialStatus { get; set; }
        //nav
        public virtual List<int> RoomList { get; set; }
    }
}
