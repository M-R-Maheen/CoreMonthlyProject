using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core_Project.Models
{
    public class Guest
    {
        public Guest()
        {
            this.BookingEntries = new List<BookingEntry>();
        }
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public DateTime CheckIn { get; set; }
        public string Phone { get; set; }
        public string Picture { get; set; }
        public bool MaritialStatus { get; set; }
        //nav
        public virtual ICollection<BookingEntry> BookingEntries { get; set; }

    }
    public class Room
    {
        public Room()
        {
            this.GuestEntries = new List<BookingEntry>();
        }
        public int RoomId { get; set; }
        public string RoomType { get; set; }
        //nav
        public virtual ICollection<BookingEntry> GuestEntries { get; set; }
    }
    public class BookingEntry
    {
        public int BookingEntryId { get; set; }
        [ForeignKey("Guest")]
        public int GuestId { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        //nav
        public virtual Guest Guest { get; set; }
        public virtual Room Room { get; set; }
    }
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {

        }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<BookingEntry> BookingEntries { get; set; }
    }
}
