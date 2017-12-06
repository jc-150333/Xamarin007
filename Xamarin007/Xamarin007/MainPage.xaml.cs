﻿using System;
using Xamarin.Forms;

using System.Collections.Generic;

using System.Linq;
using SQLite.Net;

//参考url http://dev-suesan.hatenablog.com/entry/2017/03/06/005206

/*
namespace Xamarin005
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };

            //-------------------------------インサートボタン--------------------------------
            var Insert = new Button
            {
                WidthRequest = 60,
                Text = "INSERT",
                TextColor = Color.Blue,
            };
            layout.Children.Add(Insert);
            Insert.Clicked += InsertClicked;

            /*--------------------------------デリートボタン--------------------------------
            var Delete = new Button
            {
                WidthRequest = 60,
                Text = "DELETE",
                TextColor = Color.Blue,
            };
            layout.Children.Add(Delete);
            Delete.Clicked += DeleteClicked;

            //--------------------------------セレクトボタン------------------------------
            var Select = new Button
            {
                WidthRequest = 60,
                Text = "SELECT",
                TextColor = Color.Blue,
            };
            layout.Children.Add(Select);
            Select.Clicked += SelectClicked;

            Content = layout;
        }

        public void SelectClicked(object sender, EventArgs e)
        {
            //Userテーブルの行データを取得
            var query = UserModel.selectUser(); //中身はSELECT * FROM [User]
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };
            foreach (var user in query)
            {
                //Userテーブルの名前列をLabelに書き出す
                layout.Children.Add(new Label { Text = user.Name });
            }
            Content = layout;
        }

        public void InsertClicked(object sender, EventArgs e)
        {
            //Userテーブルに適当なデータを追加する
            UserModel.insertUser("鈴木");
            UserModel.insertUser("田中");
            UserModel.insertUser("斎藤");

        }

        
        public void DeleteClicked(object sender, EventArgs e)
        {
            //UserModel008.deleteUser("鈴木");

        }
    }


}*/

//ここからsample


namespace Xamarin007
{
    public partial class MainPage : ContentPage
    {

        private Entry entry;

        public MainPage()
        {
            InitializeComponent();

            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };
            //var layout = new ListView { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };

            //-------------------------------エントリー-------------------------------
            //文字入力
            entry = new Entry
            {
                WidthRequest = 60
            };
            //追加
            var buttonAdd = new Button
            {
                WidthRequest = 60,
                TextColor = Color.Black,
                Text = "Add"
            };
            layout.Children.Add(buttonAdd);
            buttonAdd.Clicked += AddClicked;

            /*buttonAdd.Clicked += (s, a) =>
            {//追加ボタンの処理
                if (!String.IsNullOrEmpty(entry.Text))
                {
                    UserModel.insertUser(entry.Text);
                    entry.Text = "";
                    var query = UserModel.selectUser(); //中身はSELECT * FROM [User]
                    layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };
                    foreach (var user in query)
                    {
                        //Userテーブルの名前列をLabelに書き出す
                        layout.Children.Add(new Label { Text = user.Name });
                    }
                }
            };*/


            /*-------------------------------インサートボタン-------------------------------
            var Insert = new Button
            {
                WidthRequest = 60,
                Text = "INSERT",
                TextColor = Color.Blue,
            };
            layout.Children.Add(Insert);
            Insert.Clicked += InsertClicked;

             /*--------------------------------デリートボタン------------------------------
             var Delete = new Button
             {
                 WidthRequest = 60,
                 Text = "DELETE",
                 TextColor = Color.Blue,
             };
             layout.Children.Add(Delete);
             Delete.Clicked += DeleteClicked;*/

            /*--------------------------------セレクトボタン------------------------------
            var Select = new Button
            {
                WidthRequest = 60,
                Text = "SELECT",
                TextColor = Color.Blue,
            };
            layout.Children.Add(Select);
            Select.Clicked += SelectClicked;*/

            /*--------------------------------検索ボタン------------------------------
            var Serch = new Button
            {
                WidthRequest = 60,
                Text = "Serch",
                TextColor = Color.Blue,
            };
            layout.Children.Add(Serch);
            Serch.Clicked += SerchClicked;*/

            /*--------------------------------オーダーボタン------------------------------
            var Order = new Button
            {
                WidthRequest = 60,
                Text = "Oredr",
                TextColor = Color.Black,
            };
            layout.Children.Add(Order);
            Order.Clicked += OrderClicked;*/


            Content = layout;
        }

        public void AddClicked(object sender, EventArgs e)
        {
            UserModel.insertUser(entry.Text);

            //実験
            //Userテーブルの行データを取得
            var query = UserModel.selectUser(); //中身はSELECT * FROM [User]
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };
            foreach (var user in query)
            {
                //Userテーブルの名前列をLabelに書き出す
                layout.Children.Add(new Label { Text = user.Name });
            }
            Content = layout;

            /*
            var Insert = new Button
            {
                WidthRequest = 60,
                Text = "INSERT",
                TextColor = Color.Blue,
            };
            layout.Children.Add(Insert);
            Insert.Clicked += InsertClicked;*/
        }

        public void SelectClicked(object sender, EventArgs e)
        {
            //Userテーブルの行データを取得
            var query = UserModel.selectUser(); //中身はSELECT * FROM [User]
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };
            foreach (var user in query)
            {
                //Userテーブルの名前列をLabelに書き出す
                layout.Children.Add(new Label { Text = user.Name });
            }
            Content = layout;
        }

        public void InsertClicked(object sender, EventArgs e)
        {
            /*Userテーブルに適当なデータを追加する
            UserModel.insertUser(1, "鈴木");
            UserModel.insertUser(2, "田中");
            UserModel.insertUser(3, "斎藤");*/

            //UserModel.insertUser(entry.Text);

            //実験
            //Userテーブルの行データを取得
            var query = UserModel.selectUser(); //中身はSELECT * FROM [User]
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };
            foreach (var user in query)
            {
                //Userテーブルの名前列をLabelに書き出す
                layout.Children.Add(new Label { Text = user.Name });
            }
            Content = layout;

            var Insert = new Button
            {
                WidthRequest = 60,
                Text = "INSERT",
                TextColor = Color.Blue,
            };
            layout.Children.Add(Insert);
            Insert.Clicked += InsertClicked;

        }

        public void OrderClicked(object sender, EventArgs e)
        {
            //Userテーブルの行データを取得
            var query = UserModel.orderUser(); //中身はSELECT * FROM [User]
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };
            foreach (var user in query)
            {
                //Userテーブルの名前列をLabelに書き出す
                layout.Children.Add(new Label { Text = user.Name });
            }
            Content = layout;

        }

        /*
        public void SerchClicked(object sender, EventArgs e)
        {
            var query = UserModel.serchUser(); 
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };
            foreach (var user in query)
            {
                //Userテーブルの名前列をLabelに書き出す
                layout.Children.Add(new Label { Text = user.Name });
            }
            Content = layout;

        }

        
        public void DeleteClicked(object sender, EventArgs e)
        {
            //UserModel008.deleteUser("鈴木");

        }*/
    }


}