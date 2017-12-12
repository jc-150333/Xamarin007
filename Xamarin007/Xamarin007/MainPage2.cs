using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Xamarin007
{
    public partial class MainPage2 : ContentPage
    {

        private Entry entry;

        public MainPage2()
        {
            UserModel.insertUser("鈴木");
            UserModel.insertUser("田中");
            UserModel.insertUser("斎藤");

            var ar = new ObservableCollection<UserModel>();

            var listView = new ListView
            {
                //ItemsSource = UserModel.selectUser(),
                //ItemTemplate = new DataTemplate(typeof(TextCell))
                ItemsSource = ar
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
                    UserModel.insertUser(entry.Text);
                    //実験
                    //Userテーブルの行データを取得
                    var query = UserModel.selectUser(); //中身はSELECT * FROM [User]

                    //foreach (var user in query)
                    //{
                        //Userテーブルの名前列をLabelに書き出す
                        //layout.Children.Add(new Label { Text = user.Name });
                        ar.Add(new UserModel { Name = entry.Text });
                   // }
                }
            };

            Content = new StackLayout
            {
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
                Children =
                    {
                        new StackLayout
                        {
                            BackgroundColor = Color.Navy,
                            Padding = 5,
                            Orientation = StackOrientation.Horizontal,
                            Children = {entry,buttonAdd}//Entryコントロールとボタンコントロールを配置
                        },
                        listView//その下にリストボックス
                    }

            };
            /*-----------------------------selectがnullじゃなかったら----------------------
            if (UserModel.selectUser() != null)
            {
                var query = UserModel.selectUser(); //中身はSELECT * FROM [User]

                foreach (var user in query)
                {
                    //Userテーブルの名前列をLabelに書き出す
                    layout.Children.Add(new Label { Text = user.Name });
                }
            }
            Content = layout;*/
        }

        /*---------------------------Addボタン押したとき-----------------------------------
        public void AddClicked(object sender, EventArgs e)
        {
            UserModel.insertUser(entry.Text);

            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };

            entry = new Entry
            {
                WidthRequest = 180
            };
            layout.Children.Add(entry);
            //追加
            var buttonAdd = new Button
            {
                WidthRequest = 60,
                TextColor = Color.Black,
                Text = "Add"
            };
            layout.Children.Add(buttonAdd);
            buttonAdd.Clicked += AddClicked;

            //実験
            //Userテーブルの行データを取得
            var query = UserModel.selectUser(); //中身はSELECT * FROM [User]

            foreach (var user in query)
            {
                //Userテーブルの名前列をLabelに書き出す
                layout.Children.Add(new Label { Text = user.Name });
            }
            Content = layout;
        }*/
    }
}