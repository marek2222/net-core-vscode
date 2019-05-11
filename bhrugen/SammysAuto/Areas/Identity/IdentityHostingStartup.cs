using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SammysAuto.Areas.Identity.Data;

[assembly : HostingStartup (typeof (SammysAuto.Areas.Identity.IdentityHostingStartup))]
namespace SammysAuto.Areas.Identity {
	public class IdentityHostingStartup : IHostingStartup {
		public void Configure (IWebHostBuilder builder) {

			builder.ConfigureServices ((context, services) => {
			
				services.AddDbContext<ApplicationDbContext> (options =>
					options.UseSqlServer (context.Configuration.GetConnectionString ("DefaultConnection")));

				services.AddDefaultIdentity<IdentityUser> ()
					.AddEntityFrameworkStores<ApplicationDbContext> ();
			});
		}
	}
}