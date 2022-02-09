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
                        ShowNotes();
                        break;
                    case "2":
                        AddNewNote();
                        break;
                    case "3":
                        break;
                    case "4":
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

        private static void ShowNotes()
        {
            Console.Clear();
            if (_notesList.Count == 0)
            {
                Console.WriteLine("There are no notes yet!");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                Console.Clear();
                UI.ShowNotesList(_notesList);
                Console.WriteLine("Enter the number of note to read (x - return to main menu)");
                string selectedAnswer = Console.ReadLine();
                if (selectedAnswer.ToLower() == "x")
                    return;

                int noteNumber = 0;
                int.TryParse(selectedAnswer, out noteNumber);
                if (noteNumber != 0 && noteNumber - 1 < _notesList.Count)
                {
                    UI.ShowNote(_notesList[noteNumber - 1]);
                    Console.ReadKey();
                }
                else
                    UI.ShowWrongCommandMessage();
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
