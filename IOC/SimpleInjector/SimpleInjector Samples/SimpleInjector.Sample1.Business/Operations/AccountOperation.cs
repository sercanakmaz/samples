using SimpleInjector.Sample1.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector.Sample1.Business.Operations
{
    public class AccountOperation: IAccountOperation
    {
        public LoginResult Login(string userName, string password)
        {
            throw new NotImplementedException();
            return new LoginResult
            {
                FullName = "Sir John"
            };
        }
    }
    public interface IAccountOperation: IBusinessOperation
    {
        [HandleError(LogLevel.Fatal)]
        LoginResult Login(string userName, string password);
    }
}
