using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EtoIgra;
namespace EtoIgra
{
    public class CameraHandler : MonoBehaviour
    {
        [SerializeField] Transform Ball;
        Vector3 Delta;
        void Start()
        {
            Delta = transform.position - Ball.position;
            Debug.Log(Delta.ToString());
            Debug.Log(Ball.ToString());
            Debug.Log(gameObject.ToString());
            int[] a = new int[10] { 0,1,2,3,4,5,6,7,8, 9};
            string s = "";
            for(int i=0;i<10;i++)
            {
                s += a[i].ToString();
            }
            Debug.Log(s);
            transform.rotation = Quaternion.LookRotation(Ball.transform.position - transform.position);
        }
        private void Reset()
        {
            Debug.Log("Ya Reset");
        }
        // Update is called once per frame
        void Update()
        {
            transform.position = Ball.position + Delta;
        }
        public void Restart()
        {
            BallHandler.CurrentLevelPosition = new Vector3(1.689702f, -0.5875826f, 7.171316f);
            SceneManager.LoadScene("SampleScene");
        }
    }
}