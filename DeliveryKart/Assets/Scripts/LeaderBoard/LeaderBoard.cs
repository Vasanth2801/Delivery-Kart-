using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Dan.Main;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;

    private string publicLeaderBoardKey = "4bece87c9a513728b9b6c75e2af9ebde71158eb30765ab82ea306bb0b6160492\r\n";

    public void GetLeaderBoard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderBoardKey, ((msg) =>
        {
            for(int i = 0; i < names.Count;i++)
            {
                names[i].text = msg[i].Username;
                scores [i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderboardEntry(string userName, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderBoardKey, userName, score,((msg) => {   
       
            userName.Substring(0, 4);
            GetLeaderBoard();
        }));
    }
}
