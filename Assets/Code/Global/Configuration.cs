using UnityEngine;

namespace Player
{
    namespace Settings
    {
        public class Movement 
        {
            public static readonly float BaseSpeed = .05f;
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
                    case Heading.North: return new Vector2(-.5f, .1f);
                    case Heading.NorthEast: return new Vector2(0, .45f);
                    case Heading.East: return new Vector2(.25f, .45f);
                    case Heading.SouthEast: return new Vector2(.45f, .2f);
                    case Heading.South: return new Vector2(.5f, -.2f);
                    case Heading.SouthWest: return new Vector2(.2f,-.45f);
                    case Heading.West: return new Vector2(-.25f, -.4f);
                    case Heading.NorthWest: return new Vector2(-.45f, -.2f);
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
        private bool _out = false;
        public void Init(GameObject g)
        {
            _go = g;
        }
        public void Update()
        {
            //if (_out)
            //{
            //    _currentAngle += Settings.Sword.Speed * Time.deltaTime;
            //    var offset = new Vector3(Mathf.Sin(_currentAngle), Mathf.Cos(_currentAngle)) * Settings.Sword.Radius;
            //    _go.transform.position = _go.transform.position + offset;
            //    Debug.LogFormat("current {0}, offset {1}, position {2}", _currentAngle, offset, _go.transform.localPosition);
            //    _out = !_out;
            //}

            if (_currentSwingTime > 0)
            {
              //  Debug.Log(_currentAngle);
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
            _currentAngle = dir * Mathf.Deg2Rad;
            _currentSwingTime = Settings.Sword.Time;
            _out = !_out;
        }
        public int GetId()
        {
            return Db.Sword.Id;
        }

    }



    

}
