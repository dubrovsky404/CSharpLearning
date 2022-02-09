using System;
using System.Collections.Generic;
using System.Text;

namespace Notes
{
    class Note
    {
        public string Title { get; private set; }
        public string Text { get; private set; }

        public Note(string title, string text)
        {
            Title = title;
            Text = text;
        }
    }
}
