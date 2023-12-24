using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBizAPI.DATA;
using MyBizAPI.DTOs.BookDTOs;
using MyBizAPI.DTOs.PositionDTOs;
using MyBizAPI.Entity;

namespace MyBizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly MyBizDbContext _context;
        private readonly IMapper _mapping;

        public PositionsController(MyBizDbContext context, IMapper mapping = null)
        {
            _context = context;
            _mapping = mapping;
        }

        [HttpPost("")]
        public IActionResult CreatePosition(CreatePositionDTO positionDTO)
        {
            Position position = _mapping.Map<Position>(positionDTO);
            position.CreatedDate = DateTime.UtcNow.AddHours(4);
            position.UpdatedDate = DateTime.UtcNow.AddHours(4);
            position.IsDeleted = false;
            _context.Positions.Add(position);
            _context.SaveChanges();
            return Ok(position);
        }

        [HttpPut("")]
        public IActionResult UpdatePosition(UpdatePositionDTO positionDTO)
        {
            var position = _context.Positions.FirstOrDefault(x => x.Id == positionDTO.Id);
            if (position == null) return NotFound();
            position = _mapping.Map(positionDTO, position);
            position.UpdatedDate = DateTime.UtcNow.AddHours(4);
            _context.SaveChanges();
            return Ok(positionDTO);
        }

        [HttpGet("id")]
        public IActionResult GetPosition(int id)
        {
            var position = _context.Positions.FirstOrDefault(x => x.Id == id);
            GetPositionDTO positionDTO = _mapping.Map<GetPositionDTO>(position);
            return Ok(positionDTO);
        }
        [HttpGet("")]
        public IActionResult GetAllPosition()
        {
            List<Position> positions = _context.Positions.Where(x => x.IsDeleted == false).ToList();
            IEnumerable<GetPositionDTO> positionDTOs = new List<GetPositionDTO>();
            positionDTOs = positions.Select(x => new GetPositionDTO { Name = x.Name });
            return Ok(positionDTOs);
        }

        [HttpDelete("soft/{id}")]
        public IActionResult SoftDeletePosition(int id)
        {
            var position = _context.Positions.FirstOrDefault(x => x.Id == id);
            if (position == null) return NotFound();
            position.IsDeleted = !position.IsDeleted;
            _context.SaveChanges();
            return Ok();
        }

        //[HttpDelete("id")]
        //public IActionResult DeletePosition(int id)
        //{
        //    var position = _context.Positions.FirstOrDefault(x => x.Id == id);
        //    if (position == null) return NotFound();
        //    _context.Positions.Remove(position);
        //    _context.SaveChanges();
        //    return Ok();
        //}
    }
}
