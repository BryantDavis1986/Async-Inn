﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab12_2.Data;
using Lab12_2.Models;
using Lab12_2.Models.Interfaces;

namespace Lab12_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomsController(IRoom room)
        {
            _room = room;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return await _room.GetRooms();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            return await _room.GetRoom(id);
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            var updatedRoom = await _room.Update(room);
            return Ok(updatedRoom);
        }



        // POST: api/Rooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            await _room.Create(room);

            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        [HttpPost]
        [Route("{roomId}/Amenity/{amenityId}")]
        // POST: api/Rooms/{RoomId}/Amenity/{AmenityId}}
        public async Task<IActionResult> AddAmenityToRoom(int roomId, int amenityId)
        {
            await _room.AddAmenity(roomId, amenityId);
            return Ok();
        }

        [HttpDelete]
        [Route("{roomId}/Amenity/{amenityId}")]
        // DELETE: api/Rooms/{RoomId}/Amenity/{AmenityId}}
        public async Task<IActionResult> RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            await _room.RemoveAmenityFromRoom(roomId, amenityId);
            return Ok();
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
            await _room.Delete(id);
            return NoContent();

        }




    }
}
