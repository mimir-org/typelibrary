﻿using System;
using System.Linq;
using System.Threading.Tasks;
using TypeLibrary.Models.Application;
using TypeLibrary.Models.Data;
using Microsoft.Extensions.Logging;
using TypeLibrary.Data.Contracts;
using TypeLibrary.Services.Contracts;

namespace TypeLibrary.Services.Services
{
    public class SeedingService : ISeedingService
    {
        public const string AttributeFileName = "attribute";
        public const string BlobDataFileName = "blobdata";
        public const string ConditionFileName = "condition";
        public const string FormatFileName = "format";
        public const string LocationFileName = "location";
        public const string PredefinedAttributeFileName = "predefinedattribute";
        public const string PurposeFileName = "purpose";
        public const string QualifierFileName = "qualifier";
        public const string RdsFileName = "rds";
        public const string RdsCategoryFileName = "rdscategory";
        public const string SimpleTypeFileName = "simpletype";
        public const string SourceFileName = "source";
        public const string TerminalTypeFileName = "terminaltype";
        public const string TransportFileName = "transport";
        public const string UnitFileName = "unit";
        
        private readonly IAttributeTypeService _attributeTypeService;
        private readonly IBlobDataService _blobDataService;
        private readonly ITypePropertyService _typePropertyService;
        private readonly IRdsService _rdsService;
        private readonly ITerminalTypeService _terminalTypeService;
        private readonly ILibraryTypeService _libraryTypeService;
        private readonly IFileRepository _fileRepository;
        private readonly ILogger<SeedingService> _logger;
        
        public SeedingService(IAttributeTypeService attributeTypeService, IBlobDataService blobDataService, ITypePropertyService typePropertyService, IRdsService rdsService,
            ITerminalTypeService terminalTypeService, IFileRepository fileRepository, ILibraryTypeService libraryTypeService, ILogger<SeedingService> logger)
        {
            _attributeTypeService = attributeTypeService;
            _blobDataService = blobDataService;
            _typePropertyService = typePropertyService;
            _rdsService = rdsService;
            _terminalTypeService = terminalTypeService;
            _libraryTypeService = libraryTypeService;
            _fileRepository = fileRepository;
            _logger = logger;
        }
     
        public async Task LoadDataFromFiles()
        {
            try
            {
                var fileList = _fileRepository.ReadJsonFileList().ToList();

                if (!fileList.Any())
                    return;

                var conditionFiles = fileList.Where(x => x.ToLower().Equals(ConditionFileName)).ToList();
                var formatFiles = fileList.Where(x => x.ToLower().Equals(FormatFileName)).ToList();
                var qualifierFiles = fileList.Where(x => x.ToLower().Equals(QualifierFileName)).ToList();
                var sourceFiles = fileList.Where(x => x.ToLower().Equals(SourceFileName)).ToList();
                var locationFiles = fileList.Where(x => x.ToLower().Equals(LocationFileName)).ToList();
                var purposeFiles = fileList.Where(x => x.ToLower().Equals(PurposeFileName)).ToList();
                var rdsCategoryFiles = fileList.Where(x => x.ToLower().Equals(RdsCategoryFileName)).ToList();
                var unitFiles = fileList.Where(x => x.ToLower().Equals(UnitFileName)).ToList();

                var attributeFiles = fileList.Where(x => x.ToLower().Equals(AttributeFileName)).ToList();
                var terminalTypeFiles = fileList.Where(x => x.ToLower().Equals(TerminalTypeFileName)).ToList();
                var rdsFiles = fileList.Where(x => x.ToLower().Equals(RdsFileName)).ToList();
                var predefinedAttributeFiles = fileList.Where(x => x.ToLower().Equals(PredefinedAttributeFileName)).ToList();
                var blobDataFileNames = fileList.Where(x => x.ToLower().Equals(BlobDataFileName)).ToList();
                var simpleTypeFileNames = fileList.Where(x => x.ToLower().Equals(SimpleTypeFileName)).ToList();
                var transportFiles = fileList.Where(x => x.ToLower().Equals(TransportFileName)).ToList();
                
                
                var conditions = _fileRepository.ReadAllFiles<ConditionAm>(conditionFiles).ToList();
                var formats = _fileRepository.ReadAllFiles<FormatAm>(formatFiles).ToList();
                var qualifiers = _fileRepository.ReadAllFiles<QualifierAm>(qualifierFiles).ToList();
                var sources = _fileRepository.ReadAllFiles<SourceAm>(sourceFiles).ToList();
                var locations = _fileRepository.ReadAllFiles<LocationAm>(locationFiles).ToList();
                var purposes = _fileRepository.ReadAllFiles<PurposeAm>(purposeFiles).ToList();
                var rdsCategories = _fileRepository.ReadAllFiles<RdsCategoryAm>(rdsCategoryFiles).ToList();
                var units = _fileRepository.ReadAllFiles<UnitAm>(unitFiles).ToList();

                var attributes = _fileRepository.ReadAllFiles<AttributeTypeAm>(attributeFiles).ToList();
                var terminalTypes = _fileRepository.ReadAllFiles<CreateTerminalType>(terminalTypeFiles).ToList();
                var rds = _fileRepository.ReadAllFiles<CreateRds>(rdsFiles).ToList();
                var predefinedAttributes = _fileRepository.ReadAllFiles<PredefinedAttribute>(predefinedAttributeFiles).ToList();
                var blobData = _fileRepository.ReadAllFiles<BlobDataAm>(blobDataFileNames).ToList();
                var simpleTypes = _fileRepository.ReadAllFiles<SimpleTypeAm>(simpleTypeFileNames).ToList();
                var transports = _fileRepository.ReadAllFiles<CreateLibraryType>(transportFiles).ToList();
                
                await _typePropertyService.CreateConditions(conditions);
                await _typePropertyService.CreateFormats(formats);
                await _typePropertyService.CreateQualifiers(qualifiers);
                await _typePropertyService.CreateSources(sources);
                await _typePropertyService.CreateLocations(locations);
                await _typePropertyService.CreatePurposes(purposes);
                await _typePropertyService.CreateRdsCategories(rdsCategories);
                await _typePropertyService.CreateUnits(units);
                
                await _attributeTypeService.CreateAttributeTypes(attributes);
                await _terminalTypeService.CreateTerminalTypes(terminalTypes);
                await _rdsService.CreateRdsAsync(rds);
                await _attributeTypeService.CreatePredefinedAttributes(predefinedAttributes);
                await _blobDataService.CreateBlobData(blobData);
                await _libraryTypeService.CreateSimpleTypes(simpleTypes);

                var existingLibraryTypes = _libraryTypeService.GetAllTypes().ToList();
                transports = transports.Where(x => existingLibraryTypes.All(y => y.Key != x.Key)).ToList();
                _libraryTypeService.ClearAllChangeTracker();
                await _libraryTypeService.CreateLibraryTypes(transports);
            }
            catch (Exception e)
            {
                _logger.LogError($"Could not create initial data from file: error: {e.Message}");
            }
        }
    }
}