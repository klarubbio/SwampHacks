using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;
using System.Globalization;

public class StatisticsWriting : MonoBehaviour
{
    private static string all = "all.csv";
    private static string calc = "calc.csv";

    // Start is called before the first frame update
    void Start()
    {
        End(0); // change to only death
        Stats(); // change to only stats menu
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void End(int newScore)
    {
        //int newScore = 3455; // change to input score

        if (!File.Exists(all))
        {
            string head1 = "Date";
            string head2 = "Score";

            var header = string.Format("{0},{1}\n", head1, head2);

            File.WriteAllText(all, header.ToString());
        }

        var allScores = new StringBuilder();
        string scoreString = newScore.ToString();

        DateTime local = DateTime.Now;

        var newLine = string.Format("{0},{1}", local.ToString(), scoreString);
        allScores.AppendLine(newLine);

        File.AppendAllText(all, allScores.ToString());
    }

    void Stats()
    {
        int total = 0;
        int average;
        int high = 0;
        int count = -1;

        string[] lines = System.IO.File.ReadAllLines(all);

        foreach (string line in lines)
        {
            string[] columns = line.Split(',');
            foreach (string column in columns)
            {
                if (count > -1)
                {
                    int num;
                    int.TryParse(column, out num);

                    total += num;

                    if (num > high)
                    {
                        high = num;
                    }
                }
            }

            count = count + 1;
        }
        average = total / count;

        if (!File.Exists(calc))
        {
            string head1 = "High Score";
            string head2 = "Average Score";

            var header = string.Format("{0},{1},{2}\n", "Date", head1, head2);

            File.WriteAllText(calc, header.ToString());
        }

        var csv = new StringBuilder();

        string highScore = high.ToString();
        string averageScore = average.ToString();

        DateTime local = DateTime.Now;

        var newLine = string.Format("{0},{1},{2}", local.ToString(), highScore, averageScore);
        csv.AppendLine(newLine);

        File.AppendAllText(calc, csv.ToString());
    }
}
