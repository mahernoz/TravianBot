namespace TravianBot
{
    public struct VillageData
    {
        /// <summary>
        ///     Creates a new copy of VillageData struct.
        /// </summary>
        /// <param name="id">Village id.</param>
        /// <param name="name">Village name.</param>
        /// <param name="pop">Village population.</param>
        /// <param name="ownerName">Owner player's name.</param>
        /// <param name="central">Central village or not.</param>
        public VillageData(
            int id,
            string name,
            int pop,
            string ownerName,
            bool central = false)
            : this()
        {
            Id = id;
            Name = name;
            Pop = pop;
            OwnerName = ownerName;
            Central = central;
        }

        /// <summary>
        ///     Gets id.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        ///     Gets owner player's name.
        /// </summary>
        public int OwnerId { get; private set; }

        /// <summary>
        ///     Gets owner player's name.
        /// </summary>
        public string OwnerName { get; private set; }

        /// <summary>
        ///     Gets village name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///     Gets village population.
        /// </summary>
        public int Pop { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether village is central or not.
        /// </summary>
        public bool Central { get; private set; }
    }
}