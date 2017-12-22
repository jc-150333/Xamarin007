using System;
using System.Collections.Generic;
using SQLite;
using System.Linq;
using SQLiteNetExtensions.Attributes;

namespace Xamarin007
{
    //テーブル名を指定
    [Table("User2")]
    public class UserModel2
    {

        //主キーー　自動採番される*/
        [PrimaryKey, AutoIncrement, Column("_id")]
        //id列
        public int Id { get; set; }
        //名前列
        public string Name { get; set; }

        /****************************インサートメソッド********************/
        public static void insertUser(string name)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにUserテーブルを作成する
                    db.CreateTable<UserModel>();

                    db.Insert(new UserModel() { Name = name });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        /********************インサートメソッド（オーバーロード）*********************/
        public static void insertUser(int id, string name)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにUserテーブルを作成する
                    db.CreateTable<UserModel>();

                    db.Insert(new UserModel() { Name = name, Id = id });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        /*******************セレクトメソッド**************************************/
        public static List<UserModel> selectUser()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    return db.Query<UserModel>("SELECT * FROM [User] ");

                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

        /*******************アップデートメソッド**************************************/
        public static List<UserModel> UpdateUser(int id, string name)
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    return db.Query<UserModel>("UPDATE [User] SET [NAME]=[name] WHERE [Id]=[id]");

                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }


        /*******************オーダーメソッド**************************************/
        public static List<UserModel> orderUser()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    return db.Query<UserModel>("SELECT * FROM [User] ORDER BY User.Id DESC ");

                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

        public static List<UserModel> JOINSELECT()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //db.Table<UserModel2>.Join(db.)

                    return db.Query<UserModel>("SELECT * FROM [UserModel] inner join [UserModel2] on [UserModel.Id] = [UserModel2.Id] where");

                    //データベースに指定したSQLを発行します
                    //return db.Query<UserModel>("SELECT * FROM [User] ORDER BY User.Id DESC ");

                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public static void deleteUser(int id)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにUserテーブルを作成する
                    db.CreateTable<UserModel>();

                    db.Delete<UserModel>(id);//デリートで渡す値は主キーじゃないといけない説
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }
    }
}