using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppAnimateTest.ViewModels
{
    public class TodoData
    {
        public string From { get; set; }
        public string Portrait { get; set; }
        public string Title { get; set; }
        public string FlowName { get; set; }
        public string DateTime { get; set; }
        public string CurrentNode { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }
        public string Uid { get; set; }
        public string DBPath { get; set; }
        public string Discarded { get; set; }
    }

    public class AboutViewModel : BaseViewModel
    {
        public Command<TodoData> DeleteItem { get; }
        public Command<TodoData> ItemTapped { get; }
        public Command Refresh { get; }
        public ObservableCollection<TodoData> TodoList { get; }
        private int todoCount;
        public int TodoCount
        {
            get => todoCount;
            set => SetProperty(ref todoCount, value);
        }

        public AboutViewModel()
        {
            Title = "About";
            Console.WriteLine("--------------TodoModel initialized.....");

            DeleteItem = new Command<TodoData>(async (data) =>
            {
                TodoList.Remove(data);
            });

            Refresh = new Command(async () =>
            {
                await LoadTodo();
            });

            ItemTapped = new Command<TodoData>(async (data) =>
            {

            });
            TodoList = new ObservableCollection<TodoData>();
            Console.WriteLine(TodoList.Count);
        }

        public async Task LoadTodo()
        {
            IsBusy = true;

            //Simulate network request
            var t = Task.Run(() =>
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString());
                Thread.Sleep(1000);
                Console.WriteLine(DateTime.Now.ToLongTimeString());
                Thread.Sleep(1000);
                Console.WriteLine(DateTime.Now.ToLongTimeString());
                Thread.Sleep(1000);
                Console.WriteLine(DateTime.Now.ToLongTimeString());
                Thread.Sleep(1000);
                Console.WriteLine(DateTime.Now.ToLongTimeString());
                Thread.Sleep(1000);
                Console.WriteLine(DateTime.Now.ToLongTimeString());
            });
            await t;
            TodoData item;
            for (int i = 0; i < 200; i++)
            {
                item = new TodoData();
                item.Title = "Test title " + i.ToString();
                item.FlowName = "TestFlow";
                item.CurrentNode = "TestNode";
                if (i % 2 == 0)
                    item.Portrait = "https://images.pexels.com/photos/10554368/pexels-photo-10554368.jpeg?auto=compress&cs=tinysrgb&dpr=3&h=750&w=1260";
                else if (i % 3 == 0)
                    item.Portrait = "https://images.pexels.com/photos/6204570/pexels-photo-6204570.jpeg?auto=compress&cs=tinysrgb&dpr=3&h=750&w=1260";
                else if (i % 4 == 0)
                    item.Portrait = "https://images.pexels.com/photos/7201114/pexels-photo-7201114.jpeg?auto=compress&cs=tinysrgb&dpr=3&h=750&w=1260";
                else
                    item.Portrait = "portrait.png";
                TodoList.Add(item);
            }
            IsBusy = false;
        }

        public ICommand OpenWebCommand { get; }
    }
}