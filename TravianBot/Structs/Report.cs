namespace TravianBot.Structs
{
    public struct Report
    {
        int _attacker;
        int _defender;
        int _attackerVillage;
        int _defenderVillage;
        Troop[] _attackerTroops;
        Troop[] _defenderTroops;
        Troop[] _supportTroops;

        public Report(
            int attacker,
            int attackerVillage,
            int defender,
            int defenderVillage,
            Troop[] attackerTroops,
            Troop[] defenderTroops,
            Troop[] supportTroops) 
            : this()
        {
            _attacker = attacker;
            _defender = defender;
            _attackerVillage = attackerVillage;
            _defenderVillage = defenderVillage;
            _attackerTroops = attackerTroops;
            _defenderTroops = defenderTroops;
            _supportTroops = supportTroops;
        }
    }
}
