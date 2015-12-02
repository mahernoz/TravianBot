namespace TravianBot.Structs
{
    public struct Resources
    {
        /// <summary>
        ///     Creates a new copy of the Resources struct.
        /// </summary>
        /// <param name="wood">Wood amount.</param>
        /// <param name="clay">Clay amount.</param>
        /// <param name="iron">Iron amount.ç</param>
        /// <param name="crop">Crop amount.</param>
        public Resources(
            ulong wood,
            ulong clay,
            ulong iron,
            ulong crop)
            : this()
        {
            Wood = wood;
            Clay = clay;
            Iron = iron;
            Crop = crop;
        }

        /// <summary>
        ///     Gets the amount of wood.
        /// </summary>
        public ulong Wood { get; private set; }

        /// <summary>
        ///     Gets the amount of clay.
        /// </summary>
        public ulong Clay { get; private set; }

        /// <summary>
        ///     Gets the amount if iron.
        /// </summary>
        public ulong Iron { get; private set; }

        /// <summary>
        ///     Gets the amount of crop.
        /// </summary>
        public ulong Crop { get; private set; }
    }
}
