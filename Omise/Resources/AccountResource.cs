using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class AccountResource : BaseResource<Account>,
        IListRetrievable<Account>
    {
        public AccountResource(IRequester requester)
        : base(requester, Endpoint.Api, "/account")
        {
        }
    }
}