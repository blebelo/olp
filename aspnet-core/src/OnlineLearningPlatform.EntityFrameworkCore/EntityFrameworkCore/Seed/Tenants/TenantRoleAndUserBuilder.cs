using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using OnlineLearningPlatform.Authorization;
using OnlineLearningPlatform.Authorization.Roles;
using OnlineLearningPlatform.Authorization.Users;

namespace OnlineLearningPlatform.EntityFrameworkCore.Seed.Tenants
{
    public class TenantRoleAndUserBuilder
    {
        private readonly OnlineLearningPlatformDbContext _context;
        private readonly int _tenantId;

        public TenantRoleAndUserBuilder(OnlineLearningPlatformDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            // Admin role

            var adminRole = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == _tenantId && r.Name == StaticRoleNames.Tenants.Admin);
            if (adminRole == null)
            {
                adminRole = _context.Roles.Add(new Role(_tenantId, StaticRoleNames.Tenants.Admin, StaticRoleNames.Tenants.Admin) { IsStatic = true }).Entity;
                _context.SaveChanges();
            }

            // Grant all permissions to admin role

            var grantedPermissions = _context.Permissions.IgnoreQueryFilters()
                .OfType<RolePermissionSetting>()
                .Where(p => p.TenantId == _tenantId && p.RoleId == adminRole.Id)
                .Select(p => p.Name)
                .ToList();

            var permissions = PermissionFinder
                .GetAllPermissions(new OnlineLearningPlatformAuthorizationProvider())
                .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Tenant) &&
                            !grantedPermissions.Contains(p.Name))
                .ToList();

            if (permissions.Any())
            {
                _context.Permissions.AddRange(
                    permissions.Select(permission => new RolePermissionSetting
                    {
                        TenantId = _tenantId,
                        Name = permission.Name,
                        IsGranted = true,
                        RoleId = adminRole.Id
                    })
                );
                _context.SaveChanges();
            }

            // Admin user

            var adminUser = _context.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == _tenantId && u.UserName == AbpUserBase.AdminUserName);
            if (adminUser == null)
            {
                adminUser = User.CreateTenantAdminUser(_tenantId, "admin@defaulttenant.com");
                adminUser.Password = new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions())).HashPassword(adminUser, "123qwe");
                adminUser.IsEmailConfirmed = true;
                adminUser.IsActive = true;

                _context.Users.Add(adminUser);
                _context.SaveChanges();

                // Assign Admin role to admin user
                _context.UserRoles.Add(new UserRole(_tenantId, adminUser.Id, adminRole.Id));
                _context.SaveChanges();
            }

            // Instructor Role Seeding
            var instructorRole = _context.Roles.IgnoreQueryFilters()
                .FirstOrDefault(r => r.TenantId == _tenantId && r.Name == StaticRoleNames.Tenants.Instructor);

            if (instructorRole == null)
            {
                instructorRole = _context.Roles
                    .Add(new Role(null,"Instructor", "Instructor") { IsStatic = true })
                    .Entity;
                _context.SaveChanges();
            }

            //  Grant specific permissions to Instructor
            var grantedInstructorPermissions = _context.Permissions.IgnoreQueryFilters()
                .OfType<RolePermissionSetting>()

                .Where(p => p.TenantId == _tenantId && p.RoleId == instructorRole.Id)
                .Select(p => p.Name)
                .ToList();

            var instructorPermissions = PermissionFinder
                .GetAllPermissions(new OnlineLearningPlatformAuthorizationProvider())
                .Where(p =>
                    p.MultiTenancySides.HasFlag(MultiTenancySides.Tenant) &&
                    p.Name.StartsWith("Pages.Instructors") && // Only instructor-related permissions
                    !grantedInstructorPermissions.Contains(p.Name))
                .ToList();

            if (instructorPermissions.Any())
            {
                _context.Permissions.AddRange(
                    instructorPermissions.Select(permission => new RolePermissionSetting
                    {
                        TenantId = _tenantId,
                        Name = permission.Name,
                        IsGranted = true,
                        RoleId = instructorRole.Id
                    })
                );
                _context.SaveChanges();
            }

            // Student Role Seeding
            var studentRole = _context.Roles.IgnoreQueryFilters()
                .FirstOrDefault(r => r.TenantId == _tenantId && r.Name == StaticRoleNames.Tenants.Student);

            if (studentRole == null)
            {
                studentRole = _context.Roles
                    .Add(new Role(null, "Student", "Student") { IsStatic = true })
                    .Entity;
                _context.SaveChanges();
            }

        }
    }
}
