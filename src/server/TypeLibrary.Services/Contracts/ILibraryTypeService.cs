﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Mimirorg.Common.Enums;
using Mimirorg.TypeLibrary.Models.Application;
using Mimirorg.TypeLibrary.Models.Client;
using Mimirorg.TypeLibrary.Models.Data;

namespace TypeLibrary.Services.Contracts
{
    public interface ILibraryTypeService
    {
        Task<LibraryTypeLibDm> GetLibraryTypeById(string id, bool ignoreNotFound = false);
        Task<LibraryTypeLibCm> GetLibraryType(string searchString);
        IEnumerable<LibraryTypeLibAm> GetAllLibraryTypes();
        Task<IEnumerable<LibraryTypeLibDm>> CreateLibraryTypes(ICollection<LibraryTypeLibAm> typeAmList);
        Task<T> CreateLibraryType<T>(LibraryTypeLibAm libraryTypeAm) where T : class, new();
        Task<T> UpdateLibraryType<T>(string id, LibraryTypeLibAm libraryTypeAm, bool updateMajorVersion, bool updateMinorVersion) where T : class, new();
        Task DeleteLibraryType(string id);
        Task<LibraryTypeLibAm> ConvertToCreateLibraryType(string id, LibraryFilter @enum);

        Task<SimpleLibDm> CreateSimpleType(SimpleLibAm simpleAm);
        Task CreateSimpleTypes(ICollection<SimpleLibAm> simpleAmList);
        IEnumerable<SimpleLibDm> GetSimpleTypes();
        
        Task<IEnumerable<NodeLibCm>> GetNodes();
        Task<IEnumerable<TransportLibCm>> GetTransports();
        Task<IEnumerable<InterfaceLibCm>> GetInterfaces();
        Task<IEnumerable<SubProjectLibCm>> GetSubProjects(string searchString = null);

        void ClearAllChangeTracker();

    }
}