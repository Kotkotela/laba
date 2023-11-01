using Contracts;
using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Contracts.Contracts;

public class RepositoryManager : IRepositoryManager
{
    private RepositoryContext _repositoryContext;
    private ICompanyRepository _companyRepository;
    private IEmployeeRepository _employeeRepository;
    private IAyditoryaRepository _AyditoryaRepository;
    private IStudentRepository _studentRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }
    public ICompanyRepository Company
    {
        get
        {
            if (_companyRepository == null)
                _companyRepository = new CompanyRepository(_repositoryContext);
            return _companyRepository;
        }
    }
    public IEmployeeRepository Employee
    {
        get
        {
            if (_employeeRepository == null)
                _employeeRepository = new EmployeeRepository(_repositoryContext);
            return _employeeRepository;
        }
    }

    ICompanyRepository IRepositoryManager.Company => throw new NotImplementedException();

    IEmployeeRepository IRepositoryManager.Employee => throw new NotImplementedException();

    IAyditoryaRepository IRepositoryManager.Ayditorya => throw new NotImplementedException();

    IStudentRepository IRepositoryManager.Student => throw new NotImplementedException();

    public Task SaveAsync() => _repositoryContext.SaveChangesAsync();

    Task IRepositoryManager.SaveAsync()
    {
        throw new NotImplementedException();
    }
}