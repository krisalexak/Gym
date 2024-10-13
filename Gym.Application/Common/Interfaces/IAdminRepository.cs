using GymManagement.Domain.Admins;
using System;
using System.Threading.Tasks;

namespace GymManagement.Application.Common.Interfaces;

public interface IAdminsRepository
{
    Task<Admin?> GetByIdAsync(Guid adminId);
    Task UpdateAsync(Admin admin);
}