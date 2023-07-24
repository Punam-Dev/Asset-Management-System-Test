using Asset_Management_System.API.Dtos;
using Asset_Management_System.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asset_Management_System.API.Services
{
    public interface IAssetService
    {
        Task<List<Hardware>> GetHardwaresAsync();
        Task<List<Vendors>> GetVendorsAsync();
        Task<Assets> GetAssetAsync(string id);
        Task<Assets> CreateAssetAsync(Assets asset);
        Task<Assets> UpdateAssetAsync(Assets asset);
        void Delete(string id);
        Task<List<AssetSummaryDto>> GetAssetSummariesASync();
    }
}
