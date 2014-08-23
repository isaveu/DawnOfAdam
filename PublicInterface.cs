using UnityEngine;
using System.Collections;

public interface IPlayerItem
{
    string GetName();
    void UseItem();
    void ItemFound();
}

public enum PLAYERHEADING 
{ 
    Up, 
    Down, 
    Left, 
    Right 
};