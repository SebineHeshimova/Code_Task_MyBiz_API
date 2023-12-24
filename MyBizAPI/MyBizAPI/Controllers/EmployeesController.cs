using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBizAPI.DATA;
using MyBizAPI.DTOs.BookDTOs;
using MyBizAPI.DTOs.PositionDTOs;
using MyBizAPI.Entity;
using MyBizAPI.Extensions;

namespace MyBizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly MyBizDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public EmployeesController(MyBizDbContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }

        [HttpPost("")]
        public IActionResult CreateEmployee([FromForm]CreateEmployeeDTO createEmployeeDTO)
        {

            Employee employee = new Employee()
            {
                FullName = createEmployeeDTO.FullName,
                Description = createEmployeeDTO.Description,
                ImageUrl = Helper.SaveFile(_env.WebRootPath, "uploads/employee", createEmployeeDTO.ImageFile),
                RedirectUrl = createEmployeeDTO.RedirectUrl,
                PositionId = createEmployeeDTO.PositionId,
                CreatedDate = DateTime.UtcNow.AddHours(4),
                UpdatedDate = DateTime.UtcNow.AddHours(4),
            };

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok();
        }


        [HttpPut("")]
        public IActionResult UpdateEmployee([FromForm]UpdateEmployeeDTO employeeDTO)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == employeeDTO.Id);
            if (employee == null) return NotFound();
            string deletePath = Path.Combine(_env.WebRootPath, "uploads/employee", employee.ImageUrl);

            if (System.IO.File.Exists(deletePath))
            {
                System.IO.File.Delete(deletePath);
            }
            employee.ImageUrl = Helper.SaveFile(_env.WebRootPath, "uploads/employee", employeeDTO.ImageFile);
            employee.FullName= employeeDTO.FullName;
            employee.PositionId= employeeDTO.PositionId;
            employee.Description= employeeDTO.Description;
            employee.RedirectUrl= employeeDTO.RedirectUrl;
            employee.UpdatedDate = DateTime.UtcNow.AddHours(4);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            GetEmployeeDTO employeeDTO = _mapper.Map<GetEmployeeDTO>(employee);
            return Ok(employeeDTO);
        }

        [HttpGet("")]
        public IActionResult GetAllEmployee()
        {
            List<Employee> employees = _context.Employees.Where(x => x.IsDeleted == false).ToList();
            IEnumerable<GetEmployeeDTO> employeeDTOs = new List<GetEmployeeDTO>();
            employeeDTOs = employees.Select(x => new GetEmployeeDTO { FullName = x.FullName, Description = x.Description, PositionId = x.PositionId, CreatedDate = x.CreatedDate, UpdateDate = x.UpdatedDate });
            return Ok(employeeDTOs);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null) return NotFound();
            employee.IsDeleted = !employee.IsDeleted;
            _context.SaveChanges();
            return Ok();
        }
    }
}
