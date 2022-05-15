using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;

public class getData : MonoBehaviour
{
    private static string connectionString =
             "Server=tcp:gamejam.database.windows.net,1433;Initial Catalog=Trivia;Persist Security Info=False;User ID=gameJamAdmin;Password=OpenlabEc0;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;";
    private static List<Question> questions = new List<Question>();
    // Start is called before the first frame update
    void Start()
    {
        questions = new List<Question>();
        //StartCoroutine(getQuestions());
        questions.Add(new Question(1, "1. El diablo intenta conseguir la contraseña de Cantuña, haciendose pasar por su banco Tricolor. ¿Cómo se llama esta estafa?", "1"));
        questions.Add(new Question(2, "2.   El diablo ahora envía mensajes sms al telefono de Cantuña como si fuera su novia. ¿Cómo se llama este ataque?", "2"));
        questions.Add(new Question(3, "El diablo se hace pasar por un amigo, de un primo, del vecino de Cantuña. Este método de engaño se llama", "3"));
        questions.Add(new Question(4, "4. Al padre Almeida le llega un mensaje sospechoso sobre sus bitcoins. Este ataque es:", "1"));
        questions.Add(new Question(5, "5. La llorona ha envíado un virus a todo el pueblo para poder controlar que hacen en sus PC. Esto se llama", "2"));
        questions.Add(new Question(6, "6.  El padre Almeida necesita cambiar su clave porque la actual 'HastaLaVuelta' es insegura. Cual de las siguientes crees que es una contraseña segura", "3"));
        questions.Add(new Question(7, "7 Cantuña navega en internet en busca de información para construir iglesias. Que no debería hacer Cantuña?", "1"));
        questions.Add(new Question(8, "El padre Almeida va ordenar cervezas por Uber al convento, ya que recibio una promoción por correo. Que no debería fijarse en el correo para saber que es seguro?", "2"));
        questions.Add(new Question(9, "9. ¿Qué le pidió el Diablo a Cantuña a cambio de la ayuda que le está brindando?", "3"));
        questions.Add(new Question(10, "10.  El diablo realizo un ataque exitoso a  Cantuña que estaba siendo engañado por medio del Phishing. ¿Qué puede obtener de Cantuña mediante este método?", "1"));
        questions.Add(new Question(11, "11. ¿Qué certificado web tenía que revisar Cantuña para saber si la web que estaba accediendo es segura o no?", "2"));
        questions.Add(new Question(12, "El padre Almeida lleno un formulario para poder obtener biblias gratis del supermaxi, que le llego al celular. Que ataque acaba de sufrir?", "3"));
        questions.Add(new Question(13, "La llorona acaba de atacar al pueblo con un virus que llena la computadora de publicidad : ''Llame ahora y encuentre a sus hijos'' Como se llama este tipo de virus", "1"));
        questions[0].options.Add(new Answer(1, "Phishing", true));
        questions[0].options.Add(new Answer(1, "Pharming", false));
        questions[0].options.Add(new Answer(1, " Malware", false));
        questions[0].options.Add(new Answer(1, "Ransomware", false));
        questions[1].options.Add(new Answer(1, "      Vishing", false));
        questions[1].options.Add(new Answer(1, "Smishing", true));
        questions[1].options.Add(new Answer(1, "Pharming", false));
        questions[1].options.Add(new Answer(1, "Catfishing", false));
        questions[2].options.Add(new Answer(1, "Hacking de enlaces", false));
        questions[2].options.Add(new Answer(1, "Descarga no autorizada", false));
        questions[2].options.Add(new Answer(1, " Hacktivismo", false));
        questions[2].options.Add(new Answer(1, "Ingeniería social", true));
        questions[3].options.Add(new Answer(1, "Cryptojacking", true));
        questions[3].options.Add(new Answer(1, " Ataque de fuerza bruta", false));
        questions[3].options.Add(new Answer(1, "Catfishing", false));
        questions[3].options.Add(new Answer(1, " Secuestro de cuenta", false));
        questions[4].options.Add(new Answer(1, "Spyware", false));
        questions[4].options.Add(new Answer(1, "Rootking", false));
        questions[4].options.Add(new Answer(1, "Troyano", true));
        questions[4].options.Add(new Answer(1, "Ramsomcloud", false));
        questions[5].options.Add(new Answer(1, "Contraseña", false));
        questions[5].options.Add(new Answer(1, "123456", false));
        questions[5].options.Add(new Answer(1, "20210114 (fecha de mi cumpleaños)", false));
        questions[5].options.Add(new Answer(1, "b4mb&s", true));
        questions[6].options.Add(new Answer(1, "www.basílicadelvotonacional.com", false));
        questions[6].options.Add(new Answer(1, "igleciasgratiz.cz", true));
        questions[6].options.Add(new Answer(1, "www.quito.gov.ec", false));
        questions[6].options.Add(new Answer(1, "www.wikipedia.org", false));
        questions[7].options.Add(new Answer(1, "En que la página se vea identica al original", false));
        questions[7].options.Add(new Answer(1, "Que el correo tiene sus datos personales", false));
        questions[7].options.Add(new Answer(1, "Que tiene una lindo diseño el correo", false));
        questions[7].options.Add(new Answer(1, "Que el emisor sea el oficial de Uber, y el enlace sea seguro", true));
        questions[8].options.Add(new Answer(1, "Su alma ", false));
        questions[8].options.Add(new Answer(1, "Dinero ", false));
        questions[8].options.Add(new Answer(1, "Su vida ", false));
        questions[8].options.Add(new Answer(1, "Sus datos personales", true));
        questions[9].options.Add(new Answer(1, "Al final de la pagina. Donde dice que es segura", false));
        questions[9].options.Add(new Answer(1, "En el candado a la izquierda de la dirección web", true));
        questions[9].options.Add(new Answer(1, "No necesitas ver el certificado, si la página parece segura", false));
        questions[9].options.Add(new Answer(1, "Suerte o muerte", false));
        questions[10].options.Add(new Answer(1, "www", false));
        questions[10].options.Add(new Answer(1, "http", false));
        questions[10].options.Add(new Answer(1, "https", true));
        questions[10].options.Add(new Answer(1, "web.segura.com", false));
        questions[11].options.Add(new Answer(1, "Ejecución remota de código", false));
        questions[11].options.Add(new Answer(1, "URL que re direcciona a una web maliciosa", false));
        questions[11].options.Add(new Answer(1, "Ataque de inyección SQL", false));
        questions[11].options.Add(new Answer(1, "Secuestro de clics", true));
        questions[12].options.Add(new Answer(1, "Virus informático", false));
        questions[12].options.Add(new Answer(1, "Gusano Informático", false));
        questions[12].options.Add(new Answer(1, "Adware", true));
        questions[12].options.Add(new Answer(1, "Troyano", false));

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
    IEnumerator getQuestions()
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
        yield return null;
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
