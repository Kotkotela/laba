using Contracts;
using Entities.Models;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Contracts
{

    public class Contracts
    {


    }


}
public interface ILoggerManager
{
    void LogInfo(string message);
    void LogWarn(string message);
    void LogDebug(string message);
    void LogError(string message);

}
public interface IRepositoryManager
{
    ICompanyRepository Company { get; }
    IEmployeeRepository Employee { get; }
    IAyditoryaRepository Ayditorya { get; }
    IStudentRepository Student { get; }
    Task SaveAsync();
}





namespace Contracts
{
    public interface IStudentRepository
    {
        Task<PagedList<Student>> GetStudentsAsync(Guid ayditoryaId, StudentParameters studentParameters, bool trackChanges);
        Task<Student> GetStudentAsync(Guid ayditoryaId, Guid id, bool trackChanges);
        void CreateStudentForAyditorya(Guid ayditoryaId, Student student);
        void DeleteStudent(Student student);

    }


    public interface IAyditoryaRepository
    {
        Task<IEnumerable<Ayditorya>> GetAllAyditoryasAsync(bool trackChanges);
        Task<Ayditorya> GetAyditoryaAsync(Guid ayditoryaId, bool trackChanges);
        void CreateAyditorya(Ayditorya ayditorya);
        Task<IEnumerable<Ayditorya>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteAyditorya(Ayditorya ayditorya);
    }
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges);
        Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges);
        void CreateCompany(Company company);
        Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteCompany(Company company);
    }
}
namespace Contracts
{
    public interface IEmployeeRepository
    {
        Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges);
        Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges);
        void CreateEmployeeForCompany(Guid companyId, Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
public interface IDataShaper<T>
{
    IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entities, string fieldsString);
    ExpandoObject ShapeData(T entity, string fieldsString);
}
