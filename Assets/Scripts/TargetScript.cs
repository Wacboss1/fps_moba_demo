using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float Health = 100f;
    public enum Team {Red, Blue};

    [SerializeField] bool isImmune;
    [SerializeField] Team currentTeam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    private void Die()
    {
        if(Health <= 0)
        {
            if(this.gameObject.tag != "Player")
            {
                this.gameObject.SetActive(false);
            }
            print(this.gameObject.name + " has died");
        }
    }

    public void TakeDamage(float amount)
    {
        if (!isImmune)
        {
            Health -= amount;
        }
    }

    public void setImmune(bool immunity)
    {
        isImmune = immunity;
    }

    public Team getTeam()
    {
        return currentTeam;
    }
}
