using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace MusicDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        MusicContext context;
        List<Autor> autors;
        List<Song> songs;
        public MainWindow()
        {
            InitializeComponent();
            context = new MusicContext();
            autors = context.Autors.ToList();
            songs = context.Songs.ToList();
            UpdateAutorList();
            UpdateSongsList();
        }

        void UpdateAutorList()
        {
            listBox1.Items.Clear();
            foreach (Autor autor in autors)
            {
                listBox1.Items.Add(autor.Name);
            }
        }
        void UpdateSongsList()
        {
            listBox2.Items.Clear();
            foreach (Song song in songs)
            {
                listBox2.Items.Add(song.Title);
            }
        }
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(textBox1.Text !="")
            {
                autors = (from autor in context.Autors
                          where autor.Name.ToLower().Contains(textBox1.Text.ToLower())
                          select autor).ToList();
            }
            else
            {
                autors = context.Autors.ToList();
            }
            UpdateAutorList();
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox2.Text != "")
            {
                songs = (from song in context.Songs
                          where song.Title.ToLower().Contains(textBox2.Text.ToLower())
                          select song).ToList();
            }
            else
            {
                songs = context.Songs.ToList();
            }
            UpdateSongsList();
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (listBox1.SelectedIndex!=-1)
            {
                image.Source = new BitmapImage(new Uri(autors[listBox1.SelectedIndex].Photo));
                songs = new List<Song>();
                foreach (Autor autor in context.Autors.Include(A=>A.Songs))
                {
                    if (autor.Id==autors[listBox1.SelectedIndex].Id)
                    {
                        songs = autor.Songs;
                        break;
                    }
                }
                UpdateSongsList();
            }
        }

        private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                autors = new List<Autor>();
                foreach (Song song in context.Songs.Include(S => S.Autors))
                {
                    if (song.Id == songs[listBox2.SelectedIndex].Id)
                    {
                        autors = song.Autors;
                        break;
                    }
                }
                UpdateAutorList();
            }
        }
    }
}
