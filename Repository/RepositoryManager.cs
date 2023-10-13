using Contracts;
using Entities;
using Repository;
using static Contracts.Contracts;
public class RepositoryManager : IRepositoryManager
{
    private RepositoryContext _repositoryContext;
    private ICompanyRepository _companyRepository;
    private IEmployeeRepository _employeeRepository;
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

    ILoggerManager IRepositoryManager.LoggerManager => throw new NotImplementedException();

    ICompanyRepository IRepositoryManager.Company => throw new NotImplementedException();

    IEmployeeRepository IRepositoryManager.Employee => throw new NotImplementedException();

    Contracts.Contracts.IstudentRepository IRepositoryManager.student => throw new NotImplementedException();

    Contracts.Contracts.IayditoryaRepository IRepositoryManager.ayditorya => throw new NotImplementedException();

    public void Save() => _repositoryContext.SaveChanges();

    void IRepositoryManager.Save()
    {
        throw new NotImplementedException();
    }
}

internal class EmployeeRepository : IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext repositoryContext)
    {
        RepositoryContext = repositoryContext;
    }

    public RepositoryContext RepositoryContext { get; }

    public void AnyMethodFromEmployeeRepository()
    {
        throw new NotImplementedException();
    }
}