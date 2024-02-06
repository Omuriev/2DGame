using UnityEngine;

public class Coin : MonoBehaviour 
{
    [SerializeField]private int _value = 1;

    public int Value => _value;
}
