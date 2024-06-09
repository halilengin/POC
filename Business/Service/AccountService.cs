using Business.Interface;
using Data.Entity;
using Framework.Data.UnitOfWork;
using Framework.Service.Service;

namespace Business.Service
{
    public class AccountService : BaseService<Account>, IAccountService
    {
        public AccountService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
