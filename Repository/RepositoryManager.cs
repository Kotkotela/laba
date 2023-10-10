using Contracts;
using Entities;
using Repository;
using static Contracts.Contracts;
public class RepositoryManager : IRepositoryManager
{
    private RepositoryContext _repositoryContext;
    private ICompanyRepository _companyRepository;
    private IEmployeeRepository _employeeRepository;
    private IayditoryaRepository _ayditoryaRepository;
    private IstudentRepository _studentRepository;
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
    public IayditoryaRepository ayditorya
    {
        get
        {
            if (_ayditoryaRepository == null)
                _ayditoryaRepository = new ayditoryaRepository(_repositoryContext);
            return _ayditoryaRepository;
        }
    }
    public IstudentRepository student
    {
        get
        {
            if (_studentRepository == null)
                _studentRepository = new studentRepostiory(_repositoryContext);
            return _studentRepository;
        }
    }

    ILoggerManager IRepositoryManager.LoggerManager => throw new NotImplementedException();

    public void Save() => _repositoryContext.SaveChanges();
}