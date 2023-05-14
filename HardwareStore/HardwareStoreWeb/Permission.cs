using HardwareStoreWeb.Models;
using System.Collections;

namespace HardwareStoreWeb
{
	public struct PermissionOptions
	{
		public BitArray BitArray { get; set; } = new BitArray(4);

		public PermissionOptions(int bitField)
		{
			BitArray[0] = (bitField & (1 << 3)) != 0;
			BitArray[1] = (bitField & (1 << 2)) != 0;
			BitArray[2] = (bitField & (1 << 1)) != 0;
			BitArray[3] = (bitField & (1 << 0)) != 0;
		}

		public readonly bool CanCreate => BitArray[0];
		public readonly bool CanEdit => BitArray[1];
		public readonly bool CanDelete => BitArray[2];
		public readonly bool CanView => BitArray[3];
	}

	public class Permission
	{
		public static Dictionary<Group, Permission> permissions = new()
		{
			{
				Group.Consultant, new Permission
				{
					Components = new(0b1111),
					ComponentDetails = new(0b1111),
					ComponentStorages = new(0b0101),
					ComponentTypes = new(0b0001),
					Configurations = new(0b1111),
					DetailTypes = new(0b0001),
					Orders = new(0b1111),
					OrderComponents = new(0b1111),
					Suppliers = new(0b0001),
					Supplies = new(0b0001),
					Warehouses = new(0b0001),
					Users = new(0b0000)
				}
			},
			{
				Group.PurchasingManager, new Permission
				{
					Components = new(0b0001),
					ComponentDetails = new(0b0001),
					ComponentStorages = new(0b0001),
					ComponentTypes = new(0b0001),
					Configurations = new(0b0001),
					DetailTypes = new(0b0001),
					Orders = new(0b0001),
					OrderComponents = new(0b0001),
					Suppliers = new(0b1111),
					Supplies = new(0b1111),
					Warehouses = new(0b0001),
					Users = new(0b0000)
				}
			},
			{
				Group.WarehouseWorker, new Permission
				{
					Components = new(0b0001),
					ComponentDetails = new(0b0001),
					ComponentStorages = new(0b1111),
					ComponentTypes = new(0b0001),
					Configurations = new(0b0001),
					DetailTypes = new(0b0001),
					Orders = new(0b0001),
					OrderComponents = new(0b0001),
					Suppliers = new(0b0001),
					Supplies = new(0b0001),
					Warehouses = new(0b1111),
					Users = new(0b0000)
				}
			},
			{
				Group.Analyst, new Permission
				{
					Components = new(0b0001),
					ComponentDetails = new(0b0001),
					ComponentStorages = new(0b0001),
					ComponentTypes = new(0b0001),
					Configurations = new(0b0001),
					DetailTypes = new(0b0001),
					Orders = new(0b0001),
					OrderComponents = new(0b0001),
					Suppliers = new(0b0000),
					Supplies = new(0b0000),
					Warehouses = new(0b0001),
					Users = new(0b0000)
				}
			},
			{
				Group.Admin, new Permission
				{
					Components = new(0b1111),
					ComponentDetails = new(0b1111),
					ComponentStorages = new(0b1111),
					ComponentTypes = new(0b1111),
					Configurations = new(0b1111),
					DetailTypes = new(0b1111),
					Orders = new(0b1111),
					OrderComponents = new(0b1111),
					Suppliers = new(0b1111),
					Supplies = new(0b1111),
					Warehouses = new(0b1111),
					Users = new(0b1111)
				}
			}
		};

		public PermissionOptions Components { get; set; }
		public PermissionOptions ComponentDetails { get; set; }
		public PermissionOptions ComponentStorages { get; set; }
		public PermissionOptions ComponentTypes { get; set; }
		public PermissionOptions Configurations { get; set; }
		public PermissionOptions DetailTypes { get; set; }
		public PermissionOptions Orders { get; set; }
		public PermissionOptions OrderComponents { get; set; }
		public PermissionOptions Suppliers { get; set; }
		public PermissionOptions Supplies { get; set; }
		public PermissionOptions Warehouses { get; set; }
		public PermissionOptions Users { get; set; }
	}
}
