using Asset_Management_System.API.Dtos;
using Asset_Management_System.API.Models;
using Asset_Management_System.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asset_Management_System.API.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;
        public AssetService(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public async Task<List<Hardware>> GetHardwaresAsync()
        {
            return await _assetRepository.GetHardwaresAsync();
        }

        public async Task<List<Vendors>> GetVendorsAsync()
        {
            return await _assetRepository.GetVendorsAsync();
        }

        public async Task<Assets> GetAssetAsync(string id)
        {
            return await _assetRepository.GetAsync(id);
        }

        public async Task<Assets> CreateAssetAsync(Assets asset)
        {
            if (asset.DeliveryDate <= DateTime.Now.Date)
            {
                throw new Exception("Delivery date should be greater than today's date");
            }

            asset.Id = Guid.NewGuid().ToString();
            asset.TotalAmount = asset.Quantity * asset.Price;

            return await _assetRepository.AddAsync(asset);
        }

        public async Task<Assets> UpdateAssetAsync(Assets asset)
        {
            var existingAsset = await GetAssetAsync(asset.Id);

            if (existingAsset is null)
            {
                throw new Exception("Asset not found");
            }

            if (existingAsset.DeliveryDate.Date >= DateTime.Now.Date)
            {
                throw new Exception("Asset can't be edited on or after delivery date");
            }

            asset.TotalAmount = asset.Quantity * asset.Price;

            return await _assetRepository.UpdateAsync(asset);
        }

        public void Delete(string id)
        {
            _assetRepository.Delete(id);
        }

        public async Task<List<AssetSummaryDto>> GetAssetSummariesASync()
        {
            return await _assetRepository.GetAssetSummaryAsync();
        }
    }
}