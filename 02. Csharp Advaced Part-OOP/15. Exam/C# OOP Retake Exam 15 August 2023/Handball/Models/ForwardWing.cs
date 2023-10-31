namespace Handball.Models
{
    public class ForwardWing : Player
    {
        private const double initialRating = 5.5;
        private const double increaseRating = 1.25;
        private const double decreaseRating = 0.75;
        public ForwardWing(string name)
            : base(name, initialRating)
        {
        }

        public override void DecreaseRating()
        {
            this.Rating -= decreaseRating;
            if (this.Rating < 1)
            {
                this.Rating = 1;
            }
        }

        public override void IncreaseRating()
        {
            this.Rating += increaseRating;
            if (this.Rating > 10)
            {
                this.Rating = 10;
            }
        }
    }
}
