using MySqlConnector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    [SerializeField] TMP_InputField usernameInput;
    [SerializeField] TMP_InputField messageInput;
    [SerializeField] TextMeshProUGUI chatText;

    string connStr = "server=172.16.2.26; user id=KANG; password=ae21215926; database=KANG";
    int id = 0;

    void Start()
    {
        InvokeRepeating(nameof(LoadMessages), 0f, 2f);
    }

    public void SendMessage()
    {
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            conn.Open();
            string sql = "INSERT INTO Chat (id, user, message) VALUES (@i, @u, @m)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@u", usernameInput.text);
            cmd.Parameters.AddWithValue("@m", messageInput.text);
            cmd.Parameters.AddWithValue("@i", id);
            cmd.ExecuteNonQuery();
        }

        messageInput.text = "";
        id++;
    }

    public void LoadMessages()
    {
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            conn.Open();
            string sql = "SELECT id, user, message FROM Chat ORDER BY id DESC LIMIT 20";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                chatText.text = "";

                while (reader.Read())
                {
                    chatText.text +=
                        reader.GetString("user") + ": " +
                        reader.GetString("message") + "\n";
                }
            }
        }
    }

    public void DeleteAll()
    {
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM Chat", conn);
            cmd.ExecuteNonQuery();
            Debug.Log("Deleted");
        }
    }
}