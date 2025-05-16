using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UseCoin : MonoBehaviour
{
    public Text text; // LegacyのUI.Text

    private RectTransform rectTransform; // RectTransformを取得
    private Vector2 startAnchoredPosition;

    private void Start()
    {
        rectTransform = text.GetComponent<RectTransform>();
        startAnchoredPosition = rectTransform.anchoredPosition; // 初期位置を保存
        SetAlpha(0f);
    }

    public void CoinAnimStart()
    {
        StopAllCoroutines();
        StartCoroutine(AnimateText());
    }

    private IEnumerator AnimateText()
    {
        // アルファ値を0から最大値にする
        float alpha = 0f;
        float duration = 0.3f; // 0.5秒でアルファ値を最大に
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            alpha = Mathf.Lerp(0, 1, t / duration);
            SetAlpha(alpha);

            // Y座標を移動 (anchoredPositionを使用)
            rectTransform.anchoredPosition = Vector2.Lerp(startAnchoredPosition, startAnchoredPosition + new Vector2(0, 20), t / duration);

            yield return null;
        }

        // アルファ値を最大に設定
        SetAlpha(1f);
        rectTransform.anchoredPosition = startAnchoredPosition + new Vector2(0, 50);
        // 0.5秒待機
        yield return new WaitForSeconds(0.5f);

        // アルファ値を最大から0にする
        duration = 0.3f; // 0.3秒でアルファ値を0に
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            alpha = Mathf.Lerp(1, 0, t / duration);
            SetAlpha(alpha);
            yield return null;
        }

        // アルファ値を0に設定
        SetAlpha(0f);

        // 元の位置に戻す
        rectTransform.anchoredPosition = startAnchoredPosition;
    }

    private void SetAlpha(float alpha)
    {
        if (text != null)
        {
            Color color = text.color;
            color.a = alpha;
            text.color = color;
        }
    }
}
