using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public enum QueueingStatue
{
    InQueue = 1,
    Success,
    Cancel,
}

public class PvpQueueingManager : MonoBehaviour
{
    public Button btnCancel;
    public Text ticker;

    private PvpQueue queueing;
    private long queueingTs;
    private long lastQueueResultTs = 0;

    public GameObject self;
    public GameObject enemy;


    private void Start()
    {
        btnCancel.onClick.AddListener(OnClickBtnCancel);
        // 展示自己
        showHero(self, PlayerModel.Instance.curtHero);
        // 开始排队
        inQueue();
        // 匹配计时
        queueingTs = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }

    private void Update()
    {
        var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - queueingTs;
        if (now - queueingTs >= 60)
        {
            dequeue();
            ticker.text = "未能匹配到对手";
            SceneSwitcher.LoadSceneByIndex(ESceneType.GAMESKILLPREPARESCENE);
        }
        else
        {
            ticker.text = $"{60 - now}s";
            refreshQueueing(now);
        }
    }

    private async void OnClickBtnCancel()
    {
        await dequeue();
        SceneSwitcher.LoadSceneByIndex(ESceneType.GAMEROLEPREPARESCENE);
    }

    private async Task inQueue()
    {
        var result = await GameService.PvpMatch(new Game_PvpMatch { heroId = PlayerModel.Instance.curtHero.id });
        if (result.GetData() != null)
        {
            queueing = result.GetData().data;
            processQueueing();
        }
        else
        {
            Debug.Log($"可能服务器觉得你太强了，不给你匹配对手{result.code} {result.error}");
        }
    }

    private async Task refreshQueueing(long now)
    {
        if (queueing == null)
        {
            return;
        }

        if (queueing.status == (int)QueueingStatue.Success)
        {
            return;
        }

        if (lastQueueResultTs != 0 && now - lastQueueResultTs < 3)
        {
            return;
        }

        lastQueueResultTs = now;
        var result = await GameService.PvpMatchResult(new Game_PvpMatchResult { queueId = queueing.id });
        if (result.GetData() != null)
        {
            queueing = result.GetData().data;
            processQueueing();
        }
        else
        {
            Debug.Log($"可能服务器觉得你太强了，不给你匹配对手{result.code} {result.error}");
        }
    }

    private async Task dequeue()
    {
        if (queueing == null)
        {
            return;
        }

        var result = await GameService.PvpCancel(new Game_PvpCancel { queueId = queueing.id });
        if (result.GetData() != null)
        {
            return;
        }

        Debug.Log(result.error);
    }

    private void processQueueing()
    {
        if (queueing == null)
        {
            return;
        }

        if (queueing.status == (int)QueueingStatue.Success)
        {
            showEnemy();
            finishBattle();
        }
    }

    private void showEnemy()
    {
        Debug.Log("showEnemy");
        if (queueing.selfHero == queueing.player1.id)
        {
            showHero(enemy, queueing.player2);
        }
        else
        {
            showHero(enemy, queueing.player1);
        }
    }

    private async void finishBattle()
    {
        Debug.Log(queueing.battleId);
        // throw new NotImplementedException();
        var respFinishBattle = await GameService.FinishBattle(new Game_FinishBattle { battleId = queueing.battleId });
        Game_FinishBattleR finishBattleR = respFinishBattle.GetData();
        if (finishBattleR == null)
        {
            Debug.Log("so 遗憾...战斗发生了错误");
            return;
        }

        BattleManager.Instance.SetBattleManager(finishBattleR.data);
        SceneSwitcher.LoadSceneByIndex(ESceneType.GAMESCENE);
    }

    private void showHero(GameObject go, Hero hero)
    {
        Debug.Log($"showHero: {hero.name}");
        go.GetComponent<RoleRender>().OnData(hero);
        go.SetActive(true);
    }
}