using Microsoft.EntityFrameworkCore;

namespace NTF_BE.Models.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly AplicationDbContext _context;

        public EmployeeRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetListEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var employeeItem = await _context.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);

            if (employeeItem != null)
            {
                employeeItem.Name = employee.Name;
                employeeItem.Position = employee.Position;
                employeeItem.Salary = employee.Salary;
                employeeItem.HiringDate = employee.HiringDate;
                employeeItem.IsActive = employee.IsActive;

                await _context.SaveChangesAsync();
            }

        }

    }
}
