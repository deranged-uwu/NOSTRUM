using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int Gear;
    public int Spring;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddGear(int amount = 1)
    {
        Gear += amount;
    }

    public void AddSpring(int amount = 1)
    {
        Spring += amount;
    }
}