using TravianBot.Enums;

namespace TravianBot.Structs
{
    public struct BuildingData
    {
        /// <summary>
        /// Initializes a new copy of <see cref="BuildingData"/> struct.
        /// </summary>
        /// <param name="id">Id value.</param>
        /// <param name="type">Structure type.</param>
        /// <param name="level">Level value</param>
        public BuildingData(
            int id,
            BuildingType type,
            int level)
            : this()
        {
            Id = id;
            Type = type;
            Level = level;
        }

        /// <summary>
        /// Gets id.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets structure type.
        /// </summary>
        public BuildingType Type { get; private set; }

        /// <summary>
        /// Gets level value.
        /// </summary>
        public int Level { get; private set; }
    }
}