using System;
using System.Collections.Generic;
using System.Text;

namespace Notes
{
    static class UI
    {
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
            Console.WriteLine("4 - Delete note (not available!)");
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

        public static void ShowNotesList(List<Note> notesList)
        {
            for (int i = 0; i < notesList.Count; i++)
                Console.WriteLine($"{i + 1}. {notesList[i].Title}");
            Console.WriteLine();
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
    }
}
