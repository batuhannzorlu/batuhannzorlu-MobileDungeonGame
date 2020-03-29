using UnityEngine;
using System.Collections;

namespace UIHealthAlchemy
{
    public class RotateGear : MonoBehaviour
    {

        public enum TypeRot { ROT, SINROT }
        public TypeRot type;

        [SerializeField] private float speed;
        [SerializeField] private float periodIndex = 1;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            switch (type)
            {
                case TypeRot.ROT:
                    transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
                    break;
                case TypeRot.SINROT:
                    transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime * Mathf.Cos(Time.time * periodIndex)));
                    break;
            }
        }
    }
}
