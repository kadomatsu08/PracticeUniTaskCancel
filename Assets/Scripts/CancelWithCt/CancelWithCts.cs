using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace PracticeUniTaskCancel.CancelWithCt
{
    public class CancelWithCts : MonoBehaviour
    {
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private void Awake()
        {
            DelayLog(_cts.Token).Forget();
            // Destroy(this.gameObject);
        }
    
        async UniTaskVoid DelayLog(CancellationToken ct)
        {
            var delayTime = 3;
            await UniTask.Delay(delayTime * 1000, cancellationToken: ct);
            Debug.Log(delayTime + " sec passed");
        }

        private void OnDestroy()
        {
            _cts.Cancel();
            _cts.Dispose();
            Debug.Log("OnDestroy");
        }
    }
}

