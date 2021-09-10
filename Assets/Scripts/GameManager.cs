using NewSnake;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Управление игрой
/// </summary>
public class GameManager : MonoBehaviour
{
    [Tooltip("Время в ярости")]
    [SerializeField] float durationOfRage;
    [Tooltip("Текстовое поле для отображения количества GEM")]
    [SerializeField] Text textGemCount;
    [Tooltip("Текстовое поле для отображения количества очков")]
    [SerializeField] Text textEatPointCount;
    [Tooltip("Спрайт при ярости")]
    [SerializeField] Image rageImage;


    MoveBack move;

    /// <summary>
    /// Количество гемов для ярости
    /// </summary>
    int gemCountToRage = 0;
    /// <summary>
    /// всего гемов
    /// </summary>
    int allGemCount = 0;
    /// <summary>
    /// всего очков
    /// </summary>
    int eatPointCount = 0;

    RotationCompensationSpeed speedRotation;
    MoveHead snake;
    /// <summary>
    /// таймер Ярости
    /// </summary>
    float timerRage; 

    private void Start()
    {
        textGemCount.text = allGemCount.ToString();
        textEatPointCount.text = eatPointCount.ToString();
        snake = FindObjectOfType<MoveHead>();
        move = FindObjectOfType<MoveBack>();
        speedRotation = FindObjectOfType<RotationCompensationSpeed>();
        rageImage.enabled = false;
    }


    private void Update()
    {

        if (gemCountToRage == 3)
        {
            Rage();
            gemCountToRage = 0;
        }
        if (timerRage > 0)
        {
            timerRage -= Time.deltaTime;
        }
        else if (timerRage <= 0) CalmState();
    }

    /// <summary>
    /// включение режима ярости
    /// </summary>
    public void Rage()
    {
        timerRage = durationOfRage;
        snake.Rage(durationOfRage);
        move.SpeedRage(durationOfRage);
        rageImage.enabled = true;
    }
    /// <summary>
    /// вернуть начальные значения
    /// </summary>
    void CalmState()
    {
        move.SetStartSpeed();
        rageImage.enabled = false;
    }

    /// <summary>
    /// Лобавить кол-во Гемов
    /// </summary>
    internal void AddGem()
    {
        if(gemCountToRage<3&&!snake.GetIsRage) gemCountToRage++;

        allGemCount++;
        textGemCount.text = allGemCount.ToString();
    }


    /// <summary>
    /// Длобавить количество очков
    /// </summary>
    internal void AppPoints()
    {
        eatPointCount++;
        textEatPointCount.text = eatPointCount.ToString();
    }

    /// <summary>
    /// Колец игры
    /// </summary>
    internal void GameOver()
    {        
        move.Stop();
        snake.Destroy();
        speedRotation.Stop();
        StartCoroutine(RestartLevel());
    }

    /// <summary>
    /// победа
    /// </summary>
    internal void Win()
    {
        move.Stop();
        speedRotation.Stop();
        StartCoroutine(RestartLevel());
    }

    /// <summary>
    /// Перезапуск уровня
    /// </summary>
    /// <returns></returns>
    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
