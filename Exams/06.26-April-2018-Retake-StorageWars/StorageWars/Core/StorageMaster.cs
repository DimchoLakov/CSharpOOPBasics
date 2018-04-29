using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private Vehicle currentVehicle;
        private List<Storage> storageRegistry;
        private List<Product> productsPool;
        private ProductFactory productFactory;
        private StorageFactory storageFactory;

        public StorageMaster()
        {
            this.storageRegistry = new List<Storage>();
            this.productsPool = new List<Product>();
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
        }


        public string AddProduct(string type, double price)
        {
            var product = this.productFactory.CreateProduct(type, price);

            this.productsPool.Add(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = this.storageFactory.CreateStorage(type, name);

            this.storageRegistry.Add(storage);

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);

            var vehicle = storage.GetVehicle(garageSlot);

            this.currentVehicle = vehicle;

            return $"Selected {vehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;

            foreach (var productName in productNames)
            {
                if (!this.productsPool.Exists(p => p.GetType().Name == productName))
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }

                if (!this.currentVehicle.IsFull)
                {
                    var product = this.productsPool.Last(p => p.GetType().Name == productName);
                    this.currentVehicle.LoadProduct(product);
                    this.productsPool.Remove(product);
                    loadedProductsCount++;
                }
            }

            return
                $"Loaded {loadedProductsCount}/{productNames.Count()} products into {this.currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            var sourceStorage = this.storageRegistry.FirstOrDefault(s => s.Name == sourceName);
            var destinationStorage = this.storageRegistry.FirstOrDefault(s => s.Name == destinationName);

            if (sourceStorage == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            if (destinationStorage == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            int destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);
            var vehicle = destinationStorage.GetVehicle(destinationGarageSlot);

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);

            if (storage == null)
            {
                throw new InvalidOperationException("");
            }

            var totalCount = storage.GetVehicle(garageSlot).Trunk.Count;

            var unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{totalCount} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            var storage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);
            
            var allProducts = storage
                .Products
                .GroupBy(p => p.GetType().Name)
                .Select(p => new
                {
                    Name = p.Key,
                    Count = p.Count(),
                })
                .OrderByDescending(p => p.Count)
                .ThenBy(p => p.Name)
                .Select(p => $"{p.Name} ({p.Count})")
                .ToList();
            
            string productsResult = string.Join(", ", allProducts);

            var sumWeight = storage.Products.Sum(p => p.Weight);
            var storageCapacity = storage.Capacity;

            string stockFormat = string.Format("Stock ({0}/{1}): [{2}]", sumWeight, storageCapacity, productsResult);

            var vehicleNames = storage.Garage.Select(v => v?.GetType().Name ?? "empty").ToList();
            var joinedVehicles = string.Join("|", vehicleNames);

            var garageFormat = string.Format($"Garage: [{joinedVehicles}]");

            return stockFormat + Environment.NewLine + garageFormat;
        }

        public string GetSummary()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Storage storage in this.storageRegistry.OrderByDescending(s => s.Products.Sum(p => p.Price)))
            {
                sb.AppendLine(storage.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
