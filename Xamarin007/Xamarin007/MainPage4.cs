using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Xamarin007
{
    public class MainPage4 : ContentPage
    {
        private Entry entry;

        //private ObservableCollection<UserModel> ar;

        private ObservableCollection<UserModel> ar = new ObservableCollection<UserModel>(UserModel.selectUser());

        int id = 1;

        public MainPage4()
        {
            //var ar = new ObservableCollection<UserModel>();

            

            var listView = new ListView
            {
                //ItemsSource = UserModel.selectUser(),
                //ItemTemplate = new DataTemplate(typeof(TextCell))
                ItemsSource = ar,
                ItemTemplate = new DataTemplate(() => new MyCell(this)),
            };

            //文字入力
            var entry = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            //追加
            var buttonAdd = new Button
            {
                WidthRequest = 60,
                TextColor = Color.Black,
                Text = "Add"
            };
            buttonAdd.Clicked += (s, a) =>
            {//追加ボタンの処理
                if (!String.IsNullOrEmpty(entry.Text))
                {
                    UserModel.insertUser(id,entry.Text);

                    //Userテーブルの名前列をLabelに書き出す
                    ar.Add(new UserModel { Name = entry.Text });

                    id++;

                    entry.Text = "";
                }
            };

            Content = new StackLayout
            {
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
                Children =
                    {
                        new StackLayout
                        {
                            BackgroundColor = Color.HotPink,
                            Padding = 5,
                            Orientation = StackOrientation.Horizontal,
                            Children = {entry,buttonAdd}//Entryコントロールとボタンコントロールを配置
                        },
                        listView//その下にリストボックス
                    }

            };
        }

        public async void Action(MenuItem item)
        {
            var text = item.CommandParameter;
            if (item.Text == "Delete")
            {
                ar.RemoveAt(ar.IndexOf(text));
                UserModel.deleteUser(id);
            }
        }
    }

    class MyCell : ViewCell
    {
        public MyCell(MainPage4 myPage)
        {
            var label = new Label
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            label.SetBinding(Label.TextProperty, new Binding("."));

            var actionDelete = new MenuItem
            {
                Text = "Delete",
                Command = new Command(p => myPage.DisplayAlert("Delete", p.ToString(), "OK")),
                IsDestructive = true,
            };

            actionDelete.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            actionDelete.Clicked += (s, a) => myPage.Action((MenuItem)s);
            ContextActions.Add(actionDelete);

            View = new StackLayout
            {
                Padding = 10,
                Children = { label }
            };
        }
    }
}