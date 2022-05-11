using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class PlayerService
    {
        public PlayerService(AppDbContext context)
        {
            _context = context;

        }

        private readonly AppDbContext _context;

        public IEnumerable<Player> GetTenPlayers()
        {
            var result = _context.Players.OrderBy(x => x.AverageAttempts).Take(10);
            return result;
        }
        public IEnumerable<Player> GetPlayers()
        {
            var result = _context.Players.OrderBy(x => x.AverageAttempts);
            return result;
        }

        public void Update(string? name, int score)
        {
            if (score < 1 || score > 6)
            {
                throw new ArgumentException("Score must be between 1 and 6, and the admin password is 'password123''");
            }
            var player = _context.Players.FirstOrDefault(x => x.Name == name);

            if (player is not null)
            {
                player.AverageAttempts = (player.AverageAttempts * player.GameCount + score) / ++player.GameCount;
            }
            else
            {
                _context.Add(new Player()
                {
                    Name = name,
                    GameCount = 1,
                    AverageAttempts = score
                });
            }
            _context.SaveChanges();
        }

        public static void Seed(AppDbContext context)
        {
            if (!context.Players.Any())
            {
                context.Players.Add(new Player()
                {
                    Name = "First",
                    GameCount = 100,
                    AverageAttempts = 1.1,
                });

            }
            context.SaveChanges();
        }
    }
}
