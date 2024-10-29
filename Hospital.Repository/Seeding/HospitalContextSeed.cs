using Hospital.Data.Contexts;
using Hospital.Data.Entities.HospitalData.DrugStorage;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Hospital.Repository.Seeding
{
	public class HospitalContextSeed
	{
		public static async Task SeedAsync(HospitalDbContext context , ILoggerFactory loggerFactory)
		{
			try
			{
				if(context.DrugTypes !=null || !context.DrugTypes.Any())
				{
					var DrugsTypesData = File.ReadAllText("../Hospital.Repository/Seeding/SeedData/Drugs/DrugTypesData.json");
					var DrugTypes = JsonSerializer.Deserialize<List<DrugType>>(DrugsTypesData);
					if(DrugTypes != null)
					{
						await context.DrugTypes.AddRangeAsync(DrugTypes);
						await context.SaveChangesAsync();

					}
				}
				if(context.Drugs !=null || !context.Drugs.Any())
				{
					var DrugsData = File.ReadAllText("../Hospital.Repository/Seeding/SeedData/Drugs/DrugsData.json");
					var Drugs = JsonSerializer.Deserialize<List<Drug>>(DrugsData);
					if(Drugs != null)
					{
						await context.Drugs.AddRangeAsync(Drugs);
						await context.SaveChangesAsync();

					}
				}
				if(context.Inventories !=null || !context.Inventories.Any())
				{
					var inventoryData = File.ReadAllText("../Hospital.Repository/Seeding/SeedData/Drugs/InventoryData.json");
					var inventories = JsonSerializer.Deserialize<List<Inventory>>(inventoryData);
					if (inventories != null)
					{
						await context.Inventories.AddRangeAsync(inventories);
						await context.SaveChangesAsync();

					}
				}
				if (context.Suppliers !=null || !context.Suppliers.Any())
				{
					var SuppliersData = File.ReadAllText("../Hospital.Repository/Seeding/SeedData/Drugs/SuppliersData.json");
					var suppliers = JsonSerializer.Deserialize<List<Supplier>>(SuppliersData);
					if	(suppliers != null)
					{
						await context.Suppliers.AddRangeAsync(suppliers);
						await context.SaveChangesAsync();

					}
				}
				if(context.Orders  !=null || !context.Orders.Any())
				{
					var OrdersData = File.ReadAllText("../Hospital.Repository/Seeding/SeedData/Drugs/OrdersData.json");
					var Orders = JsonSerializer.Deserialize<List<Order>>(OrdersData);
					if(Orders is not null)
					{
						await context.Orders.AddRangeAsync(Orders);
						await context.SaveChangesAsync();

					}
				}
				if (context.OrderDetails !=null || !context.OrderDetails.Any())
				{
					var OrderDetailsData = File.ReadAllText("../Hospital.Repository/Seeding/SeedData/Drugs/OrderDetailsData.json");
					var OrderDetails = JsonSerializer.Deserialize<List<OrderDetail>>(OrderDetailsData);
					if(!OrderDetails.Any())
					{
						await context.OrderDetails.AddRangeAsync(OrderDetails);
						await context.SaveChangesAsync();

					}
				}

			}
			catch (Exception ex) 
			{
				var logger = loggerFactory.CreateLogger<HospitalContextSeed>();
				logger.LogError(ex.Message);
			}
		}
	}
}
