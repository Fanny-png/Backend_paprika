using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Backend.Models;

namespace Backend.Data
{
	public class DbInitializer
	{
		public static void Initialize(EcommerceContext context)
		{
			if (context.Admins.Any())
			{
				return;
			}
			var admins = new Admin[]
			{
				new Admin {admin_username="test Username", admin_password="test PWD"}
			};

			foreach (Admin a in admins)
			{
				context.Admins.Add(a);
			}

			context.SaveChanges();

		}

	}


}

