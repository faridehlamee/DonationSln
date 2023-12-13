using Microsoft.AspNetCore.Identity;

namespace DonationModel.Data
{
    /*************************************************/
    // We are not using this class at all since we commented the code inside Program.cs . 
    // It will work if we uncomment the code.
    /*************************************************/
    public class IdentitySeedData {
    public static async Task Initialize(DonationContext context,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager) {
        context.Database.EnsureCreated();

        string adminRole = "Admin";
        string financeRole = "Finance";
        string password4all = "P@$$w0rd";

        if (await roleManager.FindByNameAsync(adminRole) == null) {
            await roleManager.CreateAsync(new IdentityRole(adminRole));
        }

        if (await roleManager.FindByNameAsync(financeRole) == null) {
            await roleManager.CreateAsync(new IdentityRole(financeRole));
        }

        if (await userManager.FindByNameAsync("aa@aa.aa") == null){
            var user = new IdentityUser {
                UserName = "aa@aa.aa",
                Email = "aa@aa.aa",
                PhoneNumber = "6902341234"
            };

            var result = await userManager.CreateAsync(user);
            if (result.Succeeded) {
                await userManager.AddPasswordAsync(user, password4all);
                await userManager.AddToRoleAsync(user, adminRole);
            }
        }

        if (await userManager.FindByNameAsync("bb@bb.bb") == null) {
            var user = new IdentityUser {
                UserName = "bb@bb.bb",
                Email = "bb@bb.bb",
                PhoneNumber = "7788951456"
            };

            var result = await userManager.CreateAsync(user);
            if (result.Succeeded) {
                await userManager.AddPasswordAsync(user, password4all);
                await userManager.AddToRoleAsync(user, adminRole);
            }
        }

        if (await userManager.FindByNameAsync("mm@mm.mm") == null) {
            var user = new IdentityUser {
                UserName = "mm@mm.mm",
                Email = "mm@mm.mm",
                PhoneNumber = "6572136821"
            };

            var result = await userManager.CreateAsync(user);
            if (result.Succeeded) {
                await userManager.AddPasswordAsync(user, password4all);
                await userManager.AddToRoleAsync(user, financeRole);
            }
        }

        if (await userManager.FindByNameAsync("dd@dd.dd") == null) {
            var user = new IdentityUser {
                UserName = "dd@dd.dd",
                Email = "dd@dd.dd",
                PhoneNumber = "6041234567"
            };

            var result = await userManager.CreateAsync(user);
            if (result.Succeeded) {
                await userManager.AddPasswordAsync(user, password4all);
                await userManager.AddToRoleAsync(user, financeRole);
            }
        }

        if (await userManager.FindByNameAsync("hh@hh.hh") == null) {
            var user = new IdentityUser {
                UserName = "hh@hh.hh",
                Email = "hh@hh.hh",
                PhoneNumber = "6099234567"
            };

            var result = await userManager.CreateAsync(user);
            if (result.Succeeded) {
                await userManager.AddPasswordAsync(user, password4all);
                await userManager.AddToRoleAsync(user, financeRole);
            }
        }
    }
}

}