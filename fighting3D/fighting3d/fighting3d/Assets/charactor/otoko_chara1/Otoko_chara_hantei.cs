using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Otoko_chara_hantei : MonoBehaviour
{
    //�e�X�g�p�̃f�R�C�i�Q�[���I�u�W�F�N�g�j���擾
    dekoi dekoi;

    public UnityEvent Onhit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Onhit.Invoke();
        }
    }
}
