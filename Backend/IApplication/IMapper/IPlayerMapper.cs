

namespace IApplication.IMapper
{
    public interface IPlayerMapper
    {
        public PlayerDTO Map(Player player);
        public Player Map(PlayerDTO player);
    }
}
