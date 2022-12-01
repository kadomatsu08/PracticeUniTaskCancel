using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace PracticeUniTaskCancel.Delay
{
    public class Delay : MonoBehaviour
    {

        void Awake()
        {
            DelayLog().Forget();
        }

        async UniTaskVoid DelayLog()
        {
            var delayTime = 3;
            await UniTask.Delay(delayTime * 1000);
            Debug.Log(delayTime + " sec passed");
        }
    }
}

