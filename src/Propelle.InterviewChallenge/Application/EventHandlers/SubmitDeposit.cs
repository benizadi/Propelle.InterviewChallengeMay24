using Polly;
using Propelle.InterviewChallenge.Application.Domain;
using Propelle.InterviewChallenge.Application.Domain.Events;
using Propelle.InterviewChallenge.EventHandling;

namespace Propelle.InterviewChallenge.Application.EventHandlers
{
    public class SubmitDeposit : IEventHandler<DepositMade>
    {
        private readonly PaymentsContext _context;
        private readonly ISmartInvestClient _smartInvestClient;
        private readonly IAsyncPolicy _retryPolicy =
            Policy
                .Handle<Exception>() // Ideally we should tailor the type of exception 
                .RetryAsync(5);

        public SubmitDeposit(PaymentsContext context, ISmartInvestClient smartInvestClient)
        {
            _context = context;
            _smartInvestClient = smartInvestClient;
        }

        public async Task Handle(DepositMade @event)
        {
            var deposit = await _context.Deposits.FindAsync(@event.Id);

            await _retryPolicy.ExecuteAsync(()=> _smartInvestClient.SubmitDeposit(deposit.UserId, deposit.Amount));
        }
    }
}
