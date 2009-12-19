using System;

namespace Askme.Domain
{
    public class Question
    {
        public Question(string text)
        {
            Text = text;
        }

        public string Text
        {
            get; private set;
        }
    }
}