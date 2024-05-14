﻿using AwesomeRequestTrackerApi.Contexts;
using AwesomeRequestTrackerApi.Exeptions;
using AwesomeRequestTrackerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AwesomeRequestTrackerApi.Repos;

public class EmployeeRepository : IReposiroty<int, Employee>
{
    private readonly AwesomeRequestTrackerContext _context;

    public EmployeeRepository(AwesomeRequestTrackerContext context)
    {
        _context = context;
    }

    public async Task<Employee> Add(Employee item)
    {
        _context.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<Employee> Delete(int key)
    {
        var employee = await Get(key);
        if (employee != null)
        {
            _context.Remove(employee);
            _context.SaveChangesAsync(true);
            return employee;
        }

        throw new NoSuchEmployeeException();
    }

    public Task<Employee> Get(int key)
    {
        var employee = _context.Employees.FirstOrDefaultAsync(e => e.Id == key);
        return employee;
    }

    public async Task<IEnumerable<Employee>> Get()
    {
        var employees = await _context.Employees.ToListAsync();
        return employees;
    }

    public async Task<Employee> Update(Employee item)
    {
        var employee = await Get(item.Id);
        if (employee != null)
        {
            _context.Update(item);
            _context.SaveChangesAsync(true);
            return employee;
        }

        throw new NoSuchEmployeeException();
    }
}