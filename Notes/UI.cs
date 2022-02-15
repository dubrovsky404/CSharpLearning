using System;
using System.Collections.Generic;
using System.Text;

namespace Notes
{
    static class UI
    {
        private static Dictionary<Actions, string> ActionsTexts = new Dictionary<Actions, string>()
        {
            { Actions.ShowNotes, "Enter the number of note to read (x - return to main menu)" },
            { Actions.DeleteNote, "Enter the number of note to delete (x - return to main menu)" },
            { Actions.EditNote, "Enter the number of note to edit (x - return to main menu)" }
        };

        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== NOTES ===");
            Console.ResetColor();
            Console.WriteLine("Select an action:");
            Console.WriteLine("1 - Show notes");
            Console.WriteLine("2 - Create note");
            Console.WriteLine("3 - Edit note (not available!)");
            Console.WriteLine("4 - Delete note");
            Console.WriteLine("x - Exit\r\n");
        }

        public static void ShowWrongCommandMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This command is not available!");
            Console.ResetColor();
            Console.ReadKey();
        }

        public static bool ShowNotesList(List<Note> notesList, Actions action)
        {
            Console.Clear();
            if (notesList.Count == 0)
            {
                Console.WriteLine("There are no notes yet!");
                Console.ReadKey();
                return true;
            }

            for (int i = 0; i < notesList.Count; i++)
                Console.WriteLine($"{i + 1}. {notesList[i].Title}");
            Console.WriteLine();

            Console.WriteLine(ActionsTexts[action]);
            return false;
        }

        public static void ShowNote(Note note)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== " + note.Title + " ===");
            Console.ResetColor();
            Console.WriteLine(note.Text);
        }

        public static void ShowSaveNoteDialog()
        {
            Console.WriteLine();
            Console.WriteLine("+----------------------------------+");
            Console.WriteLine("|  Do you want to save this note?  |");
            Console.WriteLine("|  1 - yes                         |");
            Console.WriteLine("|  2 - no                          |");
            Console.WriteLine("+----------------------------------+\r\n");
        }

        public static void ShowNoteSavedMesage()
        {
            Console.Clear();
            Console.WriteLine("The note was saved!");
            Console.ReadKey();
        }

        public static void ShowDeleteNoteDialog()
        {
            Console.WriteLine();
            Console.WriteLine("+------------------------------------+");
            Console.WriteLine("|  Do you want to delete this note?  |");
            Console.WriteLine("|  1 - yes                           |");
            Console.WriteLine("|  2 - no                            |");
            Console.WriteLine("+------------------------------------+\r\n");
        }

        public static void ShowNoteDeletedMesage()
        {
            Console.Clear();
            Console.WriteLine("The note was deleted!");
            Console.ReadKey();
        }
    }
}
