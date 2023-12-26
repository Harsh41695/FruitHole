using UnityEngine;

public class HY_SaveSystem : MonoBehaviour
{
    public static HY_SaveSystem instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public int GetSavedData(string keyName)
    {
        return PlayerPrefs.GetInt(keyName);
    }
    public void SaveData(string name, int value)
    {
        PlayerPrefs.SetInt(name,value);
    }
}
