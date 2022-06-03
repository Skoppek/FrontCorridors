
public class HealthAndSanity
{
    public float MaxHealth;
    public float MaxSanity;
    private float health;
    private float sanity;
    
    public HealthAndSanity(float mh , float ms)
    {
        this.MaxHealth = mh;
        this.MaxSanity = ms;
        this.health = MaxHealth;
        this.sanity = MaxSanity;
    } 

    public void IncreaseMaxHelth(float update)
    {
        if (update < 0)
        {

        }
        else
        {
            MaxHealth += update;
        }
        
    }

    public void DecreseMaxHelth(float update)
    {

        if (MaxHealth <= 20.0f)
        {
            MaxHealth = 20.0f;
        }
        else if (update < 0) 
        {

        }
        else{
            MaxHealth -= update;
        }
        
    }

    public float GetHealth()
    {
        return health;
    }
    public float GetSanity() 
    {
        return sanity;
    }

    public void HealthDamage(float damageAmount)
    {
        
        health -= damageAmount;
        if (health < 0.0f) health = 0.0f;
    }

    public void SanityDamage(float damegeAmount)
    {
        sanity -= damegeAmount;
        if (sanity < 0.0f) sanity = 0.0f;
    }

    public void HealthHeal(float healeAmount)
    {
        
        health += healeAmount;
        if (health >= MaxHealth) health = MaxHealth;
    }

    public void SanityHeal(float healeAmount)
    {
        sanity += healeAmount;
        if (sanity >= MaxSanity) sanity = MaxSanity;
    }

    public float GetHealthPercent()
    {
        return health / MaxHealth;
    }
    public float GetSanityPercent()
    {
        return sanity / MaxSanity;
    }
}
