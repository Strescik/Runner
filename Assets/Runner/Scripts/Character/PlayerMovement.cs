using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Runner.Scripts.Character
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpPower;
        [SerializeField] private float bendDown;
        [SerializeField] private float slipDistance;
        [SerializeField] private float slipSpeed;

        private Rigidbody rigidbody;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Runing();
            Jump();
            Bend();
            Slip();
        }

        private void Runing()
        {
            var runPos = Vector3.forward * moveSpeed;

            transform.Translate(runPos * Time.deltaTime);
        }
        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                transform.localScale = Vector3.one;
                rigidbody.velocity = Vector3.up * jumpPower;
            }
        }
        private void Bend()
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                //Zýplama durumundaysa oyuncuyu zemine gönderme yapýlacak.
                StartCoroutine(BendCoroutine());
            }
        }
        private void Slip()
        {
            var position = transform.position;

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (position.x < slipDistance)
                    StartCoroutine(SlipCoroutine(true));
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (position.x > -slipDistance)
                    StartCoroutine(SlipCoroutine(false));
            }
        }

        IEnumerator SlipCoroutine(bool direction)
        {
            var plusDirection = slipDistance / 10;

            if (!direction)
                plusDirection *= -1;

            var plusPos = new Vector3(plusDirection, 0, 0);

            for (float i = 0; i < slipDistance; i += (slipDistance / 10))
            {
                transform.Translate(plusPos);
                yield return new WaitForEndOfFrame();
            }

            transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, transform.position.z);
        }
        IEnumerator BendCoroutine()
        {
            transform.localScale = new Vector3(1, bendDown, 1);
            yield return new WaitForSeconds(1);

            transform.localScale = Vector3.one;
        }
    }
}