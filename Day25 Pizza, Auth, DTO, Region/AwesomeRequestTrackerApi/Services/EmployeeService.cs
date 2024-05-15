﻿using AwesomeRequestTrackerApi.Exeptions;
using AwesomeRequestTrackerApi.Models;
using AwesomeRequestTrackerApi.Repos;

namespace AwesomeRequestTrackerApi.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IReposiroty<int, Employee> _repository;


    public EmployeeService(IReposiroty<int, Employee> reposiroty)
    {
        _repository = reposiroty;
    }

    public async Task<Employee> GetEmployeeByPhone(string phoneNumber)
    {
        var employee = (await _repository.Get()).FirstOrDefault(e => e.Phone == phoneNumber);
        if (employee == null)
            throw new NoSuchEmployeeException();
        return employee;
    }

    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        var employees = await _repository.Get();
        if (employees.Count() == 0)
            throw new NoEmployeeFoundException();
        return employees;
    }

    public async Task<Employee> UpdateEmployeePhone(int id, string phoneNumber)
    {
        var employee = await _repository.Get(id);
        if (employee == null)
            throw new NoSuchEmployeeException();
        employee.Phone = phoneNumber;
        employee = await _repository.Update(employee);
        return employee;
    }
}