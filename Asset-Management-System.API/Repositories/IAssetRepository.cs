using Asset_Management_System.API.Dtos;
using Asset_Management_System.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asset_Management_System.API.Repositories
{
    public interface IAssetRepository
    {
        Task<List<Vendors>> GetVendorsAsync();
        Task<List<Hardware>> GetHardwaresAsync();
        Task<Assets> AddAsync(Assets asset);
        void Delete(string id);
        Task<Assets> GetAsync(string id);
        Task<Assets> UpdateAsync(Assets asset);
        Task<List<AssetSummaryDto>> GetAssetSummaryAsync();
    }
}