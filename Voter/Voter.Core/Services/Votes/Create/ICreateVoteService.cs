namespace Voter.Core.Services.Votes
{
    public partial interface IVoteService
    {
        CreateVoteOutputModel Create(CreateVoteInputModel model);
    }
}