namespace TravianBot
{
    /// <summary>
    ///     Troops sending method.
    /// </summary>
    public enum SendingMethod
    {
        /// <summary>
        ///     Sends settlers to make a new village.
        /// </summary>
        NEWVILLAGE = 1,

        /// <summary>
        ///     Send as a support.
        /// </summary>
        SUPPORT = 2,

        /// <summary>
        ///     Send as a normal attack.
        /// </summary>
        NORMAL = 3,

        /// <summary>
        ///     Send as a raid attack.
        /// </summary>
        RAID = 4
    }
}