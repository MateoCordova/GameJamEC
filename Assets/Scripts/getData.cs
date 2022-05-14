using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;

public class getData : MonoBehaviour
{
    private static string connectionString =
             "Server=127.0.0.1;" +
             "Database=NetLegends;" +
             "User ID=sa;" +
             "Password=Game123;" +
             "Integrated Security=True";
    private static List<Question> questions = new List<Question>();
    // Start is called before the first frame update
    void Start()
    {
        getQuestions();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public List<Question> getQuestionsFull(){
        return questions;
    }
    public Question getQuestion(int index)
    {
        Question ans = questions[index];
        questions.RemoveAt(index);
        return ans;
    }
    public void getQuestions()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string consulta = "SELECT * FROM Questions";
            SqlCommand command = new SqlCommand(consulta, conn);
            SqlDataReader reader = command.ExecuteReader();
            // Call Read before accessing data.
            while (reader.Read())
            {
                questions.Add(new Question((reader.GetInt32(0)), reader.GetString(1), reader.GetString(2)));
            }
            reader.Close();
            conn.Close();
        }
        questions.ForEach(x =>
        {
            x.options = getAnswers(x.id);
        });
    }
    public List<Answer> getAnswers(int questionId)
    {
        List<Answer> answers = new List<Answer>();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string consulta = "SELECT * FROM Answers WHERE Id_Question = " + questionId;
            SqlCommand command = new SqlCommand(consulta, conn);
            SqlDataReader reader = command.ExecuteReader();
            // Call Read before accessing data.
            while (reader.Read())
            {
                answers.Add(new Answer((reader.GetInt32(0)), reader.GetString(1), reader.GetBoolean(2)));
            }
            reader.Close();
            conn.Close();
        }
        return answers;
    }
}
