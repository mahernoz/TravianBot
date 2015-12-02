namespace TravianBot.Structs
{
    /// <summary>
    ///     Represents a research.
    /// </summary>
    public struct Research
    {
        /// <summary>
        ///     Initializes a new copy of the <see cref="Research" /> struct.
        /// </summary>
        /// <param name="troop">Troop type.</param>
        /// <param name="trainable">Researched or not.</param>
        /// <param name="armoury">Armoury level.</param>
        /// <param name="blacksmith">Blacksmith level.</param>
        public Research(
            TroopType troop,
            bool trainable,
            int armoury,
            int blacksmith)
            : this()
        {
            TroopType = troop;
            Trainable = trainable;
            Armoury = armoury;
            Blacksmith = blacksmith;
        }

        /// <summary>
        ///     Gets troop type.
        /// </summary>
        public TroopType TroopType { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether type of
        ///     troop can be trained or not.
        /// </summary>
        public bool Trainable { get; private set; }

        /// <summary>
        ///     Gets armour level.
        /// </summary>
        public int Armoury { get; private set; }

        /// <summary>
        ///     Gets blacksmith level.
        /// </summary>
        public int Blacksmith { get; private set; }
    }
}