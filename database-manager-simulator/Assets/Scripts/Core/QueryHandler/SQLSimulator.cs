using System.Data; 
using Mono.Data.Sqlite;
using System.Collections.Generic;
using UnityEngine;

public class SQLSimulator : MonoBehaviour
{
    private IDbConnection dbConnection;

    private void Start()
    {
        
        string connectionString = "URI=file:" + Application.persistentDataPath + "/game_database.db"; 
        dbConnection = new SqliteConnection(connectionString);
        dbConnection.Open();
        
        Debug.Log("Database connection established.");
    }

    public string ProcessQuery(string query)
    {
        string result;

        try
        {
            using (IDbCommand command = dbConnection.CreateCommand())
            {
                command.CommandText = query;

                if (query.TrimStart().ToUpper().StartsWith("SELECT"))
                {
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        // Process SELECT results
                        List<string> rows = new List<string>();
                        while (reader.Read())
                        {
                            string row = "";
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row += reader.GetName(i) + ": " + reader.GetValue(i).ToString() + " | ";
                            }
                            rows.Add(row);
                        }
                        result = rows.Count > 0 ? string.Join("\n", rows) : "No data found.";
                    }
                }
                else
                {
                   
                    int affectedRows = command.ExecuteNonQuery();
                    result = affectedRows > 0 ? $"{affectedRows} rows affected." : "Command executed successfully.";
                }
            }
        }
        catch (System.Exception ex)
        {
            
            result = $"Error: {ex.Message}";
        }

        Debug.Log(result); 
        return result;
    }

    private void OnDestroy()
    {
        
        if (dbConnection != null)
        {
            dbConnection.Close();
            dbConnection = null;
            Debug.Log("Database connection closed.");
        }
    }
}
