using System;
using UnityEngine;

namespace Tarodev
{

    public class MissileScript : MonoBehaviour
    {
        [Header("REFERENCES")]
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private GameObject _target;
        [SerializeField] private GameObject _explosionPrefab;

        [Header("MOVEMENT")]
        float _currentspeed = 100;
        float _rotateSpeed = 100;
        private Vector3 _standardPrediction, _deviatedPrediction;
        public float AutoDestructionTime = 8;

        GameObject[] PossibleEnemy;
        GameObject ChoosedEnemy;
        public AnimationCurve AccellerationCurve;
        public float AccellerationSpeed = 1;
        public float AccellerationMultiplier = 140;
        float AccellerationTimer;




        private void Start()
        {
            _rb = GetComponent<Rigidbody>();

            PossibleEnemy = GameObject.FindGameObjectsWithTag("Enemy");

            for (int i = 0; i < PossibleEnemy.Length; i++)
            {
                if (ChoosedEnemy != null)
                {
                    if(PossibleEnemy[i].transform.position.z > transform.position.z)
                    {
                        if (PossibleEnemy[i].transform.position.z < ChoosedEnemy.transform.position.z)
                        {
                            ChoosedEnemy = PossibleEnemy[i];
                        }
                    }

                    
                }
                else
                {
                    if(PossibleEnemy[i].transform.position.z > transform.position.z)
                    {
                        ChoosedEnemy = PossibleEnemy[i];
                    }                    

                }
            }

            _target = ChoosedEnemy;
        }


        private void Update()
        {
            AutoDestructionTime -= Time.deltaTime;
            if(AutoDestructionTime <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void FixedUpdate()
        {
            AccellerationTimer += Time.deltaTime * AccellerationSpeed;

            _currentspeed = (AccellerationCurve.Evaluate(AccellerationTimer)*AccellerationMultiplier);

            _rb.velocity = transform.forward * _currentspeed;

            RotateRocket();
        }

        private void RotateRocket()
        {
            _standardPrediction = _target.GetComponent<Rigidbody>().position + _target.GetComponent<Rigidbody>().velocity;
            var heading = _standardPrediction - transform.position;

            var rotation = Quaternion.LookRotation(heading);
            _rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, _rotateSpeed * Time.deltaTime));
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_explosionPrefab) Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            if (collision.transform.TryGetComponent<IExplode>(out var ex)) ex.Explode();
            if(collision.gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);
            }
 
            Destroy(gameObject);
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, _standardPrediction);
        }
    }
}