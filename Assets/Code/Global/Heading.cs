using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heading {
    public const int NoChange = -1;
    public const int North = 270;
    public const int NorthEast = 315;
    public const int East = 360;
    public const int SouthEast = 45;
    public const int South = 90;
    public const int SouthWest = 135;
    public const int West = 180;
    public const int NorthWest = 225;
    public static string ToString(int dir)
    {
        switch (dir)
        {
            case NoChange: return "NoChange";
            case North: return "North";
            case NorthEast: return "NorthEast";
            case East: return "East";
            case SouthEast: return "SouthEast";
            case South: return "South";
            case SouthWest: return "SouthWest";
            case West: return "West";
            case NorthWest: return "NorthWest";
            default: throw new System.Exception("Invalid Heading");
        };
    }
    public static int GetDirection(Vector2 v)
    {
        if (v == Vector2.zero) return NoChange;
        if (v.y == 0)
        {
            if (v.x < 0) return West;
            return East;
        }
        if (v.x == 0)
        {
            if (v.y > 0) return North;
            return South;
        }
        if (v.x > 0)
        {
            if (v.y > 0) return NorthEast;
            return SouthEast;
        }
        if (v.y > 0) return NorthWest;
        return SouthWest;
    }
}
