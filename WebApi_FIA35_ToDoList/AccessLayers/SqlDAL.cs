using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using WebApi_FIA35_ToDoList.Interfaces;
using WebApi_FIA35_ToDoList.Models;

namespace WebApi_FIA35_ToDoList.AccessLayers
{
    public class SqlDAL : IData
    {
        public bool DeleteToDo(ToDo todo)
        {
            // 1. DB-Verbindung konfigurieren
            // "./" ist das Wurzelverzeichnis der Anwendung
            SqliteConnection conn = new SqliteConnection("Data Source=./Data/ToDoListe.db;");

            // 2. SQL-Kommando festlegen
            SqliteCommand DeleteCmd = new SqliteCommand($"DELETE FROM ToDoListe WHERE TDId = @TDId;", conn);
            DeleteCmd.Parameters.AddWithValue("@TDId", todo.TDId);


            // 3. Datenbankverbindung öffnen
            conn.Open();

            // 4. SQL-Statement gegen die Datenbank ausführen
            // Execute.NonQuery -> bei Insert, Update, Delete (gibt die Anzahl der betroffenen Zeilen zurück)
            // Execute.Scalar -> bei Select mit Aggregatsfunktion (liefert 1. Zeile, 1. Spalte)
            // Execute.Reader -> bei Select mit mehreren Zeilen und/oder mehreren Spalten

            int Anz = DeleteCmd.ExecuteNonQuery();

            // 5. Datenbank schließem
            conn.Close();

            if (Anz > 0)
                return true;

            return false;
        }

        public bool InsertToDo(ToDo todo)
        {
            // 1. DB-Verbindung konfigurieren
            // "./" ist das Wurzelverzeichnis der Anwendung
            SqliteConnection conn = new SqliteConnection("Data Source=./Data/ToDoListe.db;");

            // 2. SQL-Kommando festlegen
            SqliteCommand InsertCmd = new SqliteCommand($"Insert INTO ToDoListe ('Enddatum', 'Taetigkeit', 'Prioritaet', 'IstFertig')" +
                $" VALUES (@Enddatum,@Taetigkeit,@Prioritaet,@IstFertig);", conn);
            InsertCmd.Parameters.AddWithValue("@Enddatum", todo.Enddatum);
            InsertCmd.Parameters.AddWithValue("@Taetigkeit", todo.Taetigkeit);
            InsertCmd.Parameters.AddWithValue("@Prioritaet", todo.Prioritaet);
            InsertCmd.Parameters.AddWithValue("@IstFertig", todo.IstFertig);

            // 3. Datenbankverbindung öffnen
            conn.Open();

            // 4. Datensatz einfügen
            int Anz = InsertCmd.ExecuteNonQuery();

            // 5. Datenverbindung schließen
            conn.Close();

            if (Anz > 0)
                return true;

            return false;
        }

        public List<ToDo> SelectAllToDo()
        {
            // 1. DB-Verbindung konfigurieren
            // "./" ist das Wurzelverzeichnis der Anwendung
            SqliteConnection conn = new SqliteConnection("Data Source=./Data/ToDoListe.db;");

            // 2. SQL-Kommando festlegen
            SqliteCommand SelectCmd = new SqliteCommand("Select * FROM ToDoListe;", conn);

            // 3. Datenbankverbindung öffnen
            conn.Open();

            // 4. SQL-Statement gegen die Datenbank ausführen
            // Execute.NonQuery -> bei Insert, Update, Delete (gibt die Anzahl der betroffenen Zeilen zurück)
            // Execute.Scalar -> bei Select mit Aggregatsfunktion (liefert 1. Zeile, 1. Spalte)
            // Execute.Reader -> bei Select mit mehreren Zeilen und/oder mehreren Spalten

            SqliteDataReader dr = SelectCmd.ExecuteReader();

            List<ToDo> ToDoListe = new List<ToDo>();
            while (dr.Read() == true)
            {
                ToDo toDo = new ToDo
                {
                    TDId = (int)(long)dr[0],
                    Enddatum = DateTime.Parse(dr["Enddatum"].ToString()),
                    Taetigkeit = dr["Taetigkeit"].ToString(),
                    Prioritaet = (int)(long)dr[3],
                    IstFertig = (int)(long)dr[4] == 0 ? false : true
                };
                ToDoListe.Add(toDo);
            }

            // 5. Datenbank schließem
            conn.Close();

            return ToDoListe;

        }

        public ToDo SelectToDoById(int Id)
        {
            // 1. DB-Verbindung konfigurieren
            // "./" ist das Wurzelverzeichnis der Anwendung
            SqliteConnection conn = new SqliteConnection("Data Source=./Data/ToDoListe.db;");

            // 2. SQL-Kommando festlegen
            SqliteCommand SelectCmd = new SqliteCommand("Select * FROM ToDoListe WHERE TDId = @TDId;", conn);
            SelectCmd.Parameters.AddWithValue("@TDId", Id);

            // 3. Datenbankverbindung öffnen
            conn.Open();

            // 4. SQL-Statement gegen die Datenbank ausführen
            // Execute.NonQuery -> bei Insert, Update, Delete (gibt die Anzahl der betroffenen Zeilen zurück)
            // Execute.Scalar -> bei Select mit Aggregatsfunktion (liefert 1. Zeile, 1. Spalte)
            // Execute.Reader -> bei Select mit mehreren Zeilen und/oder mehreren Spalten

            SqliteDataReader dr = SelectCmd.ExecuteReader();

            ToDo toDo = new ToDo();
            while (dr.Read() == true)
            {
                toDo = new ToDo
                {
                    TDId = (int)(long)dr[0],
                    Enddatum = DateTime.Parse(dr["Enddatum"].ToString()),
                    Taetigkeit = dr["Taetigkeit"].ToString(),
                    Prioritaet = (int)(long)dr[3],
                    IstFertig = (int)(long)dr[4] == 0 ? false : true
                };
            }

            // 5. Datenbank schließem
            conn.Close();

            return toDo;
        }

        public bool UpdateToDo(ToDo todo)
        {

            // 1. DB-Verbindung konfigurieren
            // "./" ist das Wurzelverzeichnis der Anwendung
            SqliteConnection conn = new SqliteConnection("Data Source=./Data/ToDoListe.db;");

            // 2. SQL-Kommando festlegen
            SqliteCommand UpdateCmd = new SqliteCommand($"UPDATE ToDoListe SET Enddatum=@Enddatum, Taetigkeit=@Taetigkeit, Prioritaet=@Prioritaet, IstFertig=@IstFertig" +
                $" WHERE TDId = @TDId;", conn);
            UpdateCmd.Parameters.AddWithValue("@TDId", todo.TDId);
            UpdateCmd.Parameters.AddWithValue("@Enddatum", todo.Enddatum);
            UpdateCmd.Parameters.AddWithValue("@Taetigkeit", todo.Taetigkeit);
            UpdateCmd.Parameters.AddWithValue("@Prioritaet", todo.Prioritaet);
            UpdateCmd.Parameters.AddWithValue("@IstFertig", todo.IstFertig);


            // 3. Datenbankverbindung öffnen
            conn.Open();

            // 4. SQL-Statement gegen die Datenbank ausführen
            // Execute.NonQuery -> bei Insert, Update, Delete (gibt die Anzahl der betroffenen Zeilen zurück)
            // Execute.Scalar -> bei Select mit Aggregatsfunktion (liefert 1. Zeile, 1. Spalte)
            // Execute.Reader -> bei Select mit mehreren Zeilen und/oder mehreren Spalten

            int Anz = UpdateCmd.ExecuteNonQuery();

            // 5. Datenbank schließem
            conn.Close();

            if (Anz > 0)
                return true;

            return false;
        }
    }
}
