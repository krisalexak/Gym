using System.Threading.Tasks;

namespace GymManagement.Application.Common.Interfaces;

public interface IUnitOfWork
{
    Task CommitChangesAsync();
}