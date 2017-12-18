using System;
using Xamarin.Forms;

using System.Collections.Generic;

using System.Linq;
using SQLite.Net;

namespace Xamarin007
{
    public partial class MainPage : ContentPage
    {
        private Entry entry;

        public MainPage()
        {
            InitializeComponent();

            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };

            //-------------------------------エントリー-------------------------------
            //文字入力
            entry = new Entry
            {
                WidthRequest = 180
            };
            layout.Children.Add(entry);
            //-------------------------------------追加ボタン---------------
            var buttonAdd = new Button
            {
                WidthRequest = 60,
                TextColor = Color.Black,
                Text = "Add"
            };
            layout.Children.Add(buttonAdd);
            buttonAdd.Clicked += AddClicked;
            //-----------------------------selectがnullじゃなかったら----------------------
            if (UserModel.selectUser() != null)
            {
                var query = UserModel.selectUser(); //中身はSELECT * FROM [User]

                foreach (var user in query)
                {
                    //Userテーブルの名前列をLabelに書き出す
                    layout.Children.Add(new Label { Text = user.Name });
                }
            }
            Content = layout;
        }

        //---------------------------Addボタン押したとき-----------------------------------
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
        }
    }
}

