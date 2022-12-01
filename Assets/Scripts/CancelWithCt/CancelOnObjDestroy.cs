using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;


namespace PracticeUniTaskCancel.CancelWithCt
{
    public class CancelOnObjDestroy : MonoBehaviour
    {
        private void Awake()
        {
            var ct = this.GetCancellationTokenOnDestroy();
            DelayLog(ct).Forget();
        }

        async UniTaskVoid DelayLog(CancellationToken ct)
        {
            var delayTime = 3600;
            await UniTask.Delay(delayTime * 1000, cancellationToken: ct);
            Debug.Log(delayTime + " sec passed");
        }
    }
}
