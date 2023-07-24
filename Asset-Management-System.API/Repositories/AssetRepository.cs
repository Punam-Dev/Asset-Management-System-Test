using Asset_Management_System.API.Dtos;
using Asset_Management_System.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asset_Management_System.API.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly AppDbContext _dbContext;
        public AssetRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<List<Vendors>> GetVendorsAsync()
        {
            return await _dbContext.Vendors.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<List<Hardware>> GetHardwaresAsync()
        {
            return await _dbContext.Hardware.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<Assets> AddAsync(Assets asset)
        {
            var result = await _dbContext.Assets.AddAsync(asset);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public void Delete(string id)
        {
            var result = _dbContext.Assets.Where(x => x.Id == id).FirstOrDefault();

            _dbContext.Assets.Remove(result);
            _dbContext.SaveChanges();
        }

        public async Task<Assets> GetAsync(string id)
        {
            return await _dbContext.Assets.FindAsync(id);
        }

        public async Task<Assets> UpdateAsync(Assets asset)
        {
            var existingAsset = await GetAsync(asset.Id);

            if (existingAsset is null)
            {
                throw new Exception("Asset not found");
            }

            existingAsset.VendorId = asset.VendorId;
            existingAsset.DeliveryDate = asset.DeliveryDate;
            existingAsset.Address1 = asset.Address1;
            existingAsset.Address2 = asset.Address2;

            await _dbContext.SaveChangesAsync();
            return asset;
        }

        public async Task<List<AssetSummaryDto>> GetAssetSummaryAsync()
        {
            return await (from asset in _dbContext.Assets
                          join vendor in _dbContext.Vendors on asset.VendorId equals vendor.Id
                          select new AssetSummaryDto
                          {
                              Id = asset.Id,
                              CustomerName = asset.CustomerName,
                              CompanyName = asset.CustomerName,
                              Address = asset.Address1 + asset.Address2,
                              Vendor = vendor.Name,
                              DeliveryDate = asset.DeliveryDate
                          }).ToListAsync();
        }
    }
}
