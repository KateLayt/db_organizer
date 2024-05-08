using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task = organizer.Models.Task;

namespace organizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_AddTask_Click(object sender, RoutedEventArgs e)
        {
            // ОБЕРНУТЬ ВСЕ В TRY CATCH
            // ПРОВЕРКИ ВНУТРИ БДШКИ
            // Проверка Lbl_Name.Text 
            if (!string.IsNullOrEmpty(Lbl_Name.Text))
            {
                using (var dbContext = new OrganizerDbContext())
                {
                    Task newTask = new Task { Name = Lbl_Name.Text, Status = "мда" };
                    CONSOLE.Text = newTask.Name;
                    dbContext.Tasks.Add(newTask);
                    dbContext.SaveChanges();
                }
            }
            else
            {

            }
        }
    }
}