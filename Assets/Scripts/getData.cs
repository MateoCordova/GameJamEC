using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;

public class getData : MonoBehaviour
{
    private static string connectionString =
             "Server=tcp:gamejam.database.windows.net,1433;Initial Catalog=Trivia;Persist Security Info=False;User ID=gameJamAdmin;Password=OpenlabEc0;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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
    public List<Question> getQuestionsFull()
    {
        return questions;
    }
    public Question getQuestion()
    {
        int idPop = Random.Range(0, questions.Count);
        Question ans = questions[idPop];
        questions.RemoveAt(idPop);
        //List<Answer> answers = new List<Answer> { new Answer(1, "Tupu", false), new Answer(2, "Sapo", true),new Answer(2, "MMVRG", false),new Answer(4, ":v", false) };
        //Question ans = new Question(1,"Quien pregunta Esto saludos?","1");
        //ans.options = answers;
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
