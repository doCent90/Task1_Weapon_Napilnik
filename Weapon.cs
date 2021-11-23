class Weapon
{
    private int _bullets;
    private int _damage;
        
    public Weapon(int bullets, int damage)
    {
        _damage = damage;
        _bullets = bullets;
    }
        
    public void Fire(Player player)
    {
        if (_bullets <= 0)
            return;
        else
        {
            player.TakeDamage(_damage);
            _bullets--;
        }
    }
}

class Player
{
    private int _health;
        
    public event Action Died;

    public Player(int health)
    {
        if (health <= 0)
            throw new InvalidArgumentExeption();
        else
            _health = health;
    }

    public void TakeDamage(int damage)
    {
        if (_health > 0)
        {
            if (damage > _health)
                _health = 0;
            else
                _health -= damage;
        }

        CheckHealth();
    }
        
    private void CheckHealth()
    {
        if (_health > 0)
            return;
        else
            Die();
    }    
    
    private void Die()
    {
        Died?.Invoke();
    }
}

class Bot
{
    private Weapon _weapon;
    
    public Bot(Weapon weapon)
    {
        _weapon = weapon;
    }

    public void OnSeePlayer(Player player)
    {
        _weapon.Fire(player);
    }
}