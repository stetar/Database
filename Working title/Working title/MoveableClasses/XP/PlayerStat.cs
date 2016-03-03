namespace Working_title.MoveableClasses.XP
{
    public class PlayerStat
    {
        public int MaxHealth;
        public int Health;
        public int Mana;
        public int Damage;

        public PlayerStat()
        {
            
        }

        public PlayerStat(int health, int mana, int damage, int maxHealth)
        {
            Health = health;
            Mana = mana;
            Damage = damage;
            MaxHealth = maxHealth;
        }

        public static PlayerStat operator +(PlayerStat playerStat1, PlayerStat playerStat2)
        {
            return new PlayerStat(
                playerStat1.Health + playerStat2.Health,
                playerStat1.Mana + playerStat2.Mana,
                playerStat1.Damage + playerStat2.Damage,
                playerStat1.MaxHealth + playerStat2.MaxHealth);
        }

        public static PlayerStat operator -(PlayerStat playerStat1, PlayerStat playerStat2)
        {
            return new PlayerStat(
                playerStat1.Health - playerStat2.Health,
                playerStat1.Mana - playerStat2.Mana,
                playerStat1.Damage - playerStat2.Damage,
                playerStat1.MaxHealth - playerStat2.MaxHealth);
        }
    }
}