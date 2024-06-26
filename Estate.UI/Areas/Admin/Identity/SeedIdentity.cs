﻿

using Entity.Concrete;
using Microsoft.AspNetCore.Identity;

namespace Estate.UI.Areas.Admin.Identity
{
	public static class SeedIdentity
	{
		public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
		{
			using var scopedService = app.ApplicationServices.CreateScope();
			var serviceProvider = scopedService.ServiceProvider;
			await Seed(serviceProvider);
			return app;


		}
		public static async Task Seed(IServiceProvider serviceProvider)
		{
			var userManager = serviceProvider.GetRequiredService<UserManager<UserAdmin>>();
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var user = new UserAdmin()
			{
				FullName = "Admin Admin",
				UserName = "admin",
				Email = "harunkaragoz1@gmail.com"
			};
			if (await userManager.FindByNameAsync("Admin Admin")== null)
			{
				var identityResult = await userManager.CreateAsync(user,"admin123456");
			}
			if (await roleManager.FindByNameAsync("Admin") == null)
			{
				IdentityRole role = new IdentityRole()
				{
					Name = "Admin"
				};

				var identityResult = await roleManager.CreateAsync(role);
				var result = await userManager.AddToRoleAsync(user,role.Name);


			}
		}
	}
}
