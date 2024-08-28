namespace HandloomElegance.Common.ViewModels
{
    public class AddReviewViewModel
    {
        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }

        public sbyte Rating { get; set; }

        public string? Comment { get; set; }

    }
}