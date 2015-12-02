using System.Collections.Generic;
using System.Linq;

namespace TravianBot.Data
{
    public class MyPlayer : Player
    {
        private static readonly NLog.ILogger Logger =
            NLog.LogManager.GetCurrentClassLogger();

        private MyVillage _activeVillage;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="MyPlayer"/> class.
        /// </summary>
        /// <param name="id">Player id.</param>
        public MyPlayer(int id) : base(id)
        {
            MyVillages = new Dictionary<int, MyVillage>();
        }

        /// <summary>
        ///     Fires when the active village changes.
        /// </summary>
        public event MyVillageEventHandler OnVillageChanged;

        /// <summary>
        ///     Adds a new myvillage to account
        ///     and fires a new event.
        /// </summary>
        /// <param name="mv">Myvillage village.</param>
        public void AddVillage(MyVillage mv)
        {
            MyVillages.Add(mv.Id, mv);
        }

        /// <summary>
        ///     Gets my villages.
        /// </summary>
        public IDictionary<int, MyVillage> MyVillages { get; set; }

        /// <summary>
        ///     Gets the not initialized villages.
        /// </summary>
        public IList<MyVillage> NotSetVillages
        {
            get
            {
                return MyVillages
                    .Select(i => i.Value)
                    .Where(i => !i.IsSet)
                    .ToList();
            }
        }

        /// <summary>
        ///     Gets a value indicating whether all villages
        ///     are initialized or not.
        /// </summary>
        /// <returns>Initialized or not initialized.</returns>
        public bool CheckIfInitialied()
        {
            return MyVillages.All(i => i.Value.IsSet);
        }

        /// <summary>
        ///     Gets or sets the active village.
        /// </summary>
        public MyVillage ActiveVillage
        {
            get { return _activeVillage; }

            set
            {
                if (value != _activeVillage)
                {
                    _activeVillage = value;

                    if (OnVillageChanged != null)
                    {
                        OnVillageChanged.Invoke(value);
                    }
                }
            }
        }
    }
}