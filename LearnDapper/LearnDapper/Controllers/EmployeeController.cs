using LearnDapper.DataAccessLayer;
using LearnDapper.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnDapper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IDataBatch _dataBatch;

        public EmployeeController(IDataBatch dataBatch)
        {
            _dataBatch = dataBatch;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = _dataBatch.GetAll<Employee>();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            try
            {
                await _dataBatch.InsertAsync(employee);
                return Ok("Employee created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var employee = _dataBatch.GetById<Employee>(id);
                if (employee == null)
                {
                    return NotFound($"Employee with ID {id} not found");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                var existingEmployee = _dataBatch.GetById<Employee>(id);
                if (existingEmployee == null)
                {
                    return NotFound($"Employee with ID {id} not found");
                }

                await _dataBatch.Update(employee);
                return Ok("Employee updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var existingEmployee = _dataBatch.GetById<Employee>(id);
                if (existingEmployee == null)
                {
                    return NotFound($"Employee with ID {id} not found");
                }

                await _dataBatch.Delete<Employee>(id);
                return Ok("Employee deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
