using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LanoiraM_6th.Models;
using AutoMapper;
using LanoiraM_6th.Dtos;

namespace LanoiraM_6th.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly LanoiraSchoolDbContext _context;
        private readonly IMapper _mapper;

        public StudentsController(LanoiraSchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //[GET] api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentReadDto>>> GetStudents()
        {
            var students = await _context.Students.ToListAsync();
            return _mapper.Map<List<StudentReadDto>>(students);
        }

        //[GET] api/Students/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentReadDto>> GetStudentById(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return _mapper.Map<StudentReadDto>(student);
        }

        //[POST] api/Students
        [HttpPost]
        public async Task<ActionResult<StudentCreateDto>> CreateStudent(StudentCreateDto studentCreateDto)
        {
            var student = _mapper.Map<Student>(studentCreateDto);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            var readDto = _mapper.Map<StudentReadDto>(student);
            return CreatedAtAction(nameof(GetStudentById), new {id = student.Id}, readDto);
        }

        //[PUT] api/Students/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentUpdateDto>> UpdateStudent(int id, StudentUpdateDto studentUpdateDto)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            try
            {
                _mapper.Map(studentUpdateDto, student);
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id)) {
                    return Conflict();
                } else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //[DELETE] api/Students/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(x => x.Id == id);
        }
    }
}
