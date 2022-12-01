using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace PracticeUniTaskCancel.Delay
{
    public class DelayAndInstantKill : MonoBehaviour
    {
        void Awake()
        {
            DelayLog().Forget();
            Destroy(this.gameObject);
        }

        async UniTaskVoid DelayLog()
        {
            var delayTime = 5;
            await UniTask.Delay(delayTime * 1000);
            Debug.Log(delayTime + " sec passed");
        }
    }
}

