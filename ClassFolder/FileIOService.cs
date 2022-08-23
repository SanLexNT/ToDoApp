using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.ClassFolder
{
    internal class FileIOService
    {
        private readonly string PATH;
        public FileIOService(string path)
        {
            PATH = path;
        }

        public BindingList<ToDoModel> LoadData()
        {
            if (!File.Exists(PATH))
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<ToDoModel>();
            }
            else
            {
                using (var reader = File.OpenText(PATH))
                {
                    var fileText = reader.ReadToEnd();
                    if(fileText.Length > 0)
                        return JsonConvert.DeserializeObject<BindingList<ToDoModel>>(fileText);
                    else
                        return new BindingList<ToDoModel>();
                }
            }
        }
        public void SaveData(object toDoList)
        {
            using (var writter = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(toDoList);
                writter.Write(output);
            }
        }
    }
}
