using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  個々のキャンディーとチェーン、フィーバー、コンボ時のスクリプト
/// </summary>

public class ScoreManager : MonoBehaviour
{

    static int blockScore = 50; // キャンディー1個のスコア値

    /// <summary>
    ///  キャンディーをChainして消去した時に発生するスコア値を配列で格納
    /// </summary>

    static int[] chainScoreMap = {
    0, 0, 0, 300, 700, 1300, 2100, 3100, 4600, 6100, // chain 3 ~ 9
    7600, 9600, 11600, 13600, 15600, 18100, 20600, 23100, 25600, 28100 // chain 10 ~ 19
    };

    Text scoreText;
    static int score = 0; // 記録されるスコアの値

    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            Transform scoreGUI = canvas.transform.Find("ScoreGUI");
            if (scoreGUI != null)
            {
                scoreText = scoreGUI.GetComponent<Text>();
                SyncScoreGUI();
            }
        }
    }

    /// <summary>
    ///  スコア加算のクラス
    /// </summary>
    /// <param name="point"></param>

    public void AddScore(int point)
    {
        score = score + point;
        SyncScoreGUI();
    }

    public static int GetScore()
    {
        return score;
    }

    void SyncScoreGUI()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    /// <summary>
    ///  キャンディーを消去した時のスコア計算式を記述
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="combo"></param>
    /// <param name="fever"></param>
    /// <returns></returns>



    public static int CalculateScore(int chain, int combo, bool fever)
    {
        int chainScore = CalculateChainScore(chain);
        if (fever)
        {
            return (int)((blockScore * chain + chainScore) * 3);
        }
        else
        {
            float comboBonus = CalculateComboBonus(combo);
            return (int)((blockScore * chain + chainScore) * (1 + comboBonus));
        }
    }

    static int CalculateChainScore(int chain)
    {
        if (chain <= 19)
        {
            return chainScoreMap[chain];
        }
        else if (chain <= 29)
        {
            return chainScoreMap[19] + 3000 * (chain - 19);
        }
        else
        {
            return chainScoreMap[19] + 3000 * 10 + 3500 * (chain - 29);
        }
    }

    static float CalculateComboBonus(int combo)
    {
        if (combo == 1)
        {
            return 0;
        }
        else
        {
            combo = Mathf.Min(combo, 49);
            return (combo + 9) * 0.01f;
        }
    }
}