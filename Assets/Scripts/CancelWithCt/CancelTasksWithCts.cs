using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace PracticeUniTaskCancel.CancelWithCt
{
    public class CancelTasksWithCts : MonoBehaviour
    {
        
        private CancellationTokenSource _cts =  new CancellationTokenSource();
        private void Awake()
        {
            DelayLog3sec(_cts.Token).Forget();
            DelayLog4sec(_cts.Token).Forget();
            DelayLog5sec(_cts.Token).Forget();
        }
    
        async UniTaskVoid DelayLog3sec(CancellationToken ct)
        {
            var delayTime = 3;
            await UniTask.Delay(delayTime * 1000, cancellationToken: ct);
            Debug.Log(delayTime + " sec passed");
        }
        
        async UniTaskVoid DelayLog4sec(CancellationToken ct)
        {
            var delayTime = 4;
            await UniTask.Delay(delayTime * 1000, cancellationToken: ct);
            Debug.Log(delayTime + " sec passed");
        }
        
        async UniTaskVoid DelayLog5sec(CancellationToken ct)
        {
            var delayTime = 5;
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