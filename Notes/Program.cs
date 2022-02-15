using System;
using System.Collections.Generic;

namespace Notes
{
    class Program
    {
        private static List<Note> _notesList = new List<Note>();

        static void Main(string[] args)
        {
            bool isProgramRunning = true;

            while (isProgramRunning)
            {
                UI.ShowMainMenu();
                string selectedAction = Console.ReadLine();
                switch (selectedAction.ToLower())
                {
                    case "1":
                        PerformAction(Actions.ShowNotes);
                        break;
                    case "2":
                        AddNewNote();
                        break;
                    case "3":
                        break;
                    case "4":
                        PerformAction(Actions.DeleteNote);
                        break;
                    case "x":
                        isProgramRunning = false;
                        break;
                    default:
                        UI.ShowWrongCommandMessage();
                        break;
                }
            }
        }

        private static void PerformAction(Actions action)
        {
            while (true)
            {
                bool isReturnedToMainMenu = UI.ShowNotesList(_notesList, action);
                if (isReturnedToMainMenu)
                    return;

                string selectedAnswer = Console.ReadLine();
                if (selectedAnswer.ToLower() == "x")
                    return;

                int noteNumber = 0;
                int.TryParse(selectedAnswer, out noteNumber);
                if (noteNumber != 0 && noteNumber - 1 < _notesList.Count)
                {
                    UI.ShowNote(_notesList[noteNumber - 1]);
                    switch (action)
                    {
                        case Actions.ShowNotes:
                            Console.ReadKey();
                            break;
                        case Actions.DeleteNote:
                            DeleteNote(noteNumber - 1);
                            break;
                    }
                }
                else
                    UI.ShowWrongCommandMessage();
            }
        }

        private static void DeleteNote(int noteIndex)
        {
            bool isQuestionShown = true;
            while (isQuestionShown)
            {
                UI.ShowNote(_notesList[noteIndex]);
                UI.ShowDeleteNoteDialog(); // "Do you want to delete this note?"
                string selectedAnswer = Console.ReadLine();
                switch (selectedAnswer)
                {
                    // 1 - yes
                    case "1":
                        isQuestionShown = false;
                        _notesList.Remove(_notesList[noteIndex]);
                        UI.ShowNoteDeletedMesage();
                        break;
                    // 2 - no
                    case "2":
                        isQuestionShown = false;
                        break;
                    default:
                        UI.ShowWrongCommandMessage();
                        break;
                }
            }
        }

        private static void AddNewNote()
        {
            Console.Clear();
            Console.WriteLine("Enter a title:");
            string newTitle = Console.ReadLine();
            Console.WriteLine("\r\nEnter a text:");
            string newText = Console.ReadLine();
            var newNote = new Note(newTitle, newText);

            bool isQuestionShown = true;
            while (isQuestionShown)
            {
                UI.ShowNote(newNote);
                UI.ShowSaveNoteDialog(); // "Do you want to save this note?"
                string selectedAnswer = Console.ReadLine();
                switch (selectedAnswer)
                {
                    // 1 - yes
                    case "1": 
                        isQuestionShown = false;
                        _notesList.Add(newNote);
                        UI.ShowNoteSavedMesage();
                        break;
                    // 2 - no
                    case "2": 
                        isQuestionShown = false;
                        break;
                    default:
                        UI.ShowWrongCommandMessage();
                        break;
                }
            }
            
        }
    }
}
