namespace LoadImages.Features.LoadSceneManager
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;
    /// <summary>
    /// Отображение прогресса загрузки сцены.
    /// </summary>
    [RequireComponent(typeof(Image))]
    public sealed class LoadViewProgress : MonoBehaviour
    {
        private Image _fillImage = default;
        private Coroutine _progressCoroutine = null;

        private void Start()
        {
            _fillImage = GetComponent<Image>();

            if (_progressCoroutine != null)
            {
                StopCoroutine(_progressCoroutine);
                _progressCoroutine = null;
            }

            _progressCoroutine = StartCoroutine(Progress(1f, LoadSceneManager.Instance.LoadTime));
        }

        private IEnumerator Progress(float targetValue, float duration)
        {
            float startValue = 0;
            float time = 0;
            while (time < duration)
            {
                _fillImage.fillAmount = Mathf.Lerp(startValue, targetValue, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            _fillImage.fillAmount = targetValue;

            _progressCoroutine = null;
        }
    }
}
