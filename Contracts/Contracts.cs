﻿using static Contracts.Contracts;

namespace Contracts
{
    public class Contracts
    {
        public interface IstudentRepository
        {

        }
        public interface IayditoryaRepository
        {

        }
        public interface ICompanyRepository
        {
            void AnyMethodFromCompanyRepository();
        }
        public interface IEmployeeRepository
        {
            void AnyMethodFromEmployeeRepository();
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
        IstudentRepository student { get; }
        IayditoryaRepository ayditorya { get; }
        ILoggerManager LoggerManager { get; }
        void Save();
    }

}