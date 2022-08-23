using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDoApp.WindowFolder;

namespace ToDoApp.ClassFolder
{
    public static class MessageBoxClass
    {
        public static void ErrorMessageBox(Exception ex)
        {
            new MessageWindow(ex.Message, MessageWindow.MessageType.Error).ShowDialog();
        }
        public static bool QuestionMessageBox(string question)
        {
            new MessageWindow(question, MessageWindow.MessageType.Question).ShowDialog();
            return VariableClass.IsAccepted;
        }
        public static void ExitMessageBox()
        {
            Application.Current.Shutdown();
        }
    }
}
