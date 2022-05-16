using Lab3.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TeachersList teachersList = new teachersList();
        public MainWindow()
        {
            InitializeComponent();
            ChooseTeacher.Items.Add(new Biologist());
            ChooseTeacher.Items.Add(new Mathematician());
            ChooseTeacher.Items.Add(new Chemist());
            ChooseTeacher.Items.Add(new Philologist());
            ChooseTeacher.Items.Add(new Physicist());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Type type = ChooseTeacher.SelectedItem.GetType();
            Teachers t = (Teachers)Activator.CreateInstance(type);
            if (t != null)
            {
                t.Teachername = AddTeachername.Text;
                t.Sex = Convert.ToInt32(AddSex.Text);
                t.Age = Convert.ToInt32(AddAge.Text);
                t.Subject = AddSubject.Text;
            }
            teachersList.Add(t);
            ShowTeachers.Items.Clear();
            foreach (Teachers teach in teachersList)
                ShowTeachers.Items.Add(tr.ShowInfo());
        }

        private void Serialize_Click(object sender, RoutedEventArgs e)
        {
            JsonSerializator s = new JsonSerializator();
            File.WriteAllText(FileToSerialize.Text, s.Serialize(teacherstList));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            =teachersList.Remove(teachersList.Get(ShowTeachers.SelectedIndex));
            ShowTeachers.Items.Clear();
            foreach (Teachers teach in teachersList)
                 ShowTeachers.Items.Add(tr.ShowInfo());
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Teachers t = teachersList.Get(ShowTeachers.SelectedIndex);
            t.Teachername = EditTeachername.Text;
            t.Sex = Convert.ToInt32(EditSex.Text);
            t.Age = Convert.ToInt32(EditAge.Text);
            t.Subject = EditSubject.Text;
            ShowTeachers.Items.Clear();
            foreach (Teachers teach in teachersList)
                ShowTeachers.Items.Add(tr.ShowInfo());
        }

        private void Deserialize_Click(object sender, RoutedEventArgs e)
        {
            JsonSerializator s = new JsonSerializator();
            TeachersList tmp = s.Deserialize(File.ReadAllText(FileToDeserialize.Text));
            foreach (Teachers teach in tmp)
                =teachersList.Add(tr);
            ShowTeachers.Items.Clear();
            foreach (Teachers teach in teachersList)
                ShowTeachers.Items.Add(tr.ShowInfo());
        }
    }
}
