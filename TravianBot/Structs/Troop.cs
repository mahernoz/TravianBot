namespace TravianBot.Structs
{
    /// <summary>
    ///     Represents troops.
    /// </summary>
    public struct Troop
    {
        /// <summary>
        ///     Initializes a new copy of the <see cref="Troop" /> struct.
        /// </summary>
        /// <param name="type">Troop type.</param>
        /// <param name="count">Troop count.</param>
        public Troop(TroopType type, int count) : this()
        {
            Type = type;
            Count = count;
        }

        /// <summary>
        ///     Gets troop type.
        /// </summary>
        public TroopType Type { get; private set; }

        /// <summary>
        ///     Gets troop count.
        /// </summary>
        public int Count { get; private set; }
    }
}