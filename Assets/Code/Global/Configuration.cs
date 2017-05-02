using UnityEngine;

namespace Player
{
    namespace Settings
    {
        public class Movement 
        {
            public static readonly float Speed = .05f;
        }
    }
}

namespace Item
{
    namespace Settings
    {
        public class Sword : ScriptableObject
        {
            public static float Speed = 12f;
            public static float Radius = .1f;
            public static float Time = .25f;
            public static Vector3 GetPositionOffset(int heading)
            {
                switch (heading)
                {
                    case Heading.North: return new Vector2(-.4f, 0);
                    case Heading.NorthEast: return new Vector2(0, .4f);
                    case Heading.East: return new Vector2(.25f,.45f);
                    case Heading.SouthEast: return new Vector2();
                    case Heading.South: return new Vector2(.3f, .1f);
                    case Heading.SouthWest: return new Vector2(.2f,-.3f);
                    case Heading.West: return new Vector2(0, -.4f);
                    case Heading.NorthWest: return new Vector2(-.3f, -.3f);
                    default: throw new System.Exception("Invalid Heading");
                }
            }
        }
    }
    namespace Db
    {
        public class Sword
        {
            public static readonly int Id = 0;
        }
    }

    public class Sword : ScriptableObject, IItem
    {
        private GameObject _go;
        private float _currentSwingTime, _currentAngle;
        public void Init(GameObject g)
        {
            _go = g;
        }
        public void Update()
        {
            if (_currentSwingTime > 0)
            {
                Debug.Log(_currentAngle);
                _currentAngle += Settings.Sword.Speed * Time.deltaTime;
                var offset = new Vector3(Mathf.Sin(_currentAngle), Mathf.Cos(_currentAngle)) * Settings.Sword.Radius;
                _go.transform.position = _go.transform.position + offset;
                _currentSwingTime -= Time.deltaTime;
            }
            if (_currentSwingTime <= 0) _go.SetActive(false);
        }
        public void Use(int dir)
        {
            _go.SetActive(true);
            _go.transform.position = _go.transform.parent.transform.position + Settings.Sword.GetPositionOffset(dir);
            _currentAngle = dir;
            _currentSwingTime = Settings.Sword.Time;
        }
        public int GetId()
        {
            return Db.Sword.Id;
        }

    }



    

}
