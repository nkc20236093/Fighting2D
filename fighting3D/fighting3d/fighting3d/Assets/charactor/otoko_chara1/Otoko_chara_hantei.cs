using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otoko_chara_hantei : MonoBehaviour
{
    //�e�X�g�p�̃f�R�C�i�Q�[���I�u�W�F�N�g�j���擾
    dekoi dekoi;
    //�e�I�u�W�F�N�g�̃X�N���v�g���擾
    Otoko_chara_Controller oyascript;
    // Start is called before the first frame update
    void Start()
    {
        dekoi = GameObject.Find("dekoi").GetComponent<dekoi>();
        oyascript = GameObject.Find("���_�j�L�����P").GetComponent<Otoko_chara_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            oyascript.Attack_and_hidan();
        }
    }
}
