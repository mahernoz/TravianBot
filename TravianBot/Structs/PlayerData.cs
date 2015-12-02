using System.Diagnostics;

namespace TravianBot.Structs
{
    [DebuggerDisplay("Id = {Id}, Name = {Name}")]
    public struct PlayerData
    {
        /// <summary>
        /// Creates a new copy of PlayerData struct.
        /// </summary>
        /// <param name="id">Player id.</param>
        /// <param name="name">Player name.</param>
        /// <param name="ally">Player's ally's id.</param>
        /// <param name="isGold">Is player a gold club member?</param>
        /// <param name="isAdmin">Is player an admin?</param>
        public PlayerData(
            int id,
            string name,
            int ally,
            bool isGold = false,
            bool isAdmin = false) 
            : this()
        {
            Id = id;
            Name = name;
            Ally = ally;
            IsGold = isGold;
            IsAdmin = isAdmin;
        }

        /// <summary>
        ///     Gets id.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        ///     Gets name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///     Gets ally id.
        /// </summary>
        public int Ally { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether gold club player or not.
        /// </summary>
        public bool IsGold { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether player is admin or not.
        /// </summary>
        public bool IsAdmin { get; private set; }
    }
}