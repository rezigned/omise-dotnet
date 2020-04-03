using System.Threading.Tasks;
using Omise.Models;

namespace Omise.Resources
{
    public class DisputeResource : BaseResource<Dispute>,
        IListable<Dispute>,
        IRetrievable<Dispute>,
        ISearchable<Dispute>,
        IUpdatable<Dispute, UpdateDisputeParams>
    {
        public DisputeDocumentResource Documents { get; private set; }
        public SearchScope Scope => SearchScope.Dispute;

        public DisputeResource(IRequester requester)
        : base(requester, Endpoint.Api, "/disputes")
        {
        }

        public DisputeResource Dispute(string disputeId)
        {
            Documents = new DisputeDocumentResource(Requester, disputeId);

            return this;
        }

        public async Task<Dispute> Closed()
        {
            return await Requester.Request<Dispute>(
                Endpoint,
                "GET",
                $"{BasePath}/closed"
            );
        }

        public async Task<Dispute> Open()
        {
            return await Requester.Request<Dispute>(
                Endpoint,
                "GET",
                $"{BasePath}/open"
            );
        }

        public async Task<Dispute> Pending()
        {
            return await Requester.Request<Dispute>(
                Endpoint,
                "GET",
                $"{BasePath}/pending"
            );
        }
    }

    public class DisputeDocumentResource : BaseResource<Document>,
        ICreatable<Document, CreateDisputeDocumentParams>,
        IDestroyable<Document>,
        IListable<Document>,
        IRetrievable<Document>
    {
        public DisputeDocumentResource(IRequester requester, string disputeId)
        : base(requester, Endpoint.Api, $"/disputes/{disputeId}/documents")
        {
        }
    }
}