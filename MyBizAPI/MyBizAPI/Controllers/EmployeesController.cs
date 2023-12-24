using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBizAPI.DATA;

namespace MyBizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly MyBizDbContext _context;
        private readonly IMapper _mapper;
        public EmployeesController(MyBizDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee=_context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null) return NotFound();
            employee.IsDeleted=!employee.IsDeleted;
            _context.SaveChanges();
            return Ok();
        }
    }
}
