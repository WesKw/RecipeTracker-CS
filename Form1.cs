using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace RecipeTracker3
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Declare each button:
        /// Add
        /// Remove
        /// Edit
        /// View
        /// Exit
        /// </summary>
        public Button add;
        public Button remove;
        public Button edit;
        public Button view;
        public Button exit;

        //Create recipe LinkedList
        public static LinkedList<Recipe> recipeList = new LinkedList<Recipe>();
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public Form1()
        {
            InitializeComponent();
            this.Name = "Recipe Tracker 3";
            this.Text = "Recipe Tracker";

            TextBox title = new TextBox();
            title.Text = "Recipe Tracker";
            title.Location = new Point(10, 10);

            //Initialize each button
            add = new Button();
            remove = new Button();
            edit = new Button();
            view = new Button();
            exit = new Button();

            //Create button attributes
            //Add
            add.Text = "Add";
            add.Size = new Size(100, 30);
            add.Location = new Point(25, 300);
            this.Controls.Add(add);
            //Create add click handler
            add.Click += new EventHandler(Add_Click);

            //Remove
            remove.Text = "Remove";
            remove.Size = new Size(100, 30);
            remove.Location = new Point(150, 300);
            this.Controls.Add(remove);
            //Create remove click handler
            remove.Click += new EventHandler(Remove_Click);

            //Edit
            edit.Text = "Edit";
            edit.Size = new Size(100, 30);
            edit.Location = new Point(275, 300);
            this.Controls.Add(edit);
            //Create edit click handler
            edit.Click += new EventHandler(Edit_Click);

            //View
            view.Text = "View";
            view.Size = new Size(100, 30);
            view.Location = new Point(400, 300);
            this.Controls.Add(view);
            //Create view click handler
            view.Click += new EventHandler(View_Click);

            //Exit
            exit.Text = "Exit";
            exit.Size = new Size(100, 30);
            exit.Location = new Point(525, 300);
            this.Controls.Add(exit);
            //Create exit click handler
            exit.Click += new EventHandler(Exit_Click);

            path += "\\recipe_tracker" + "\\recipes";
            Console.WriteLine(path);
            //If an already existing recipe list exists
            if(File.Exists(path))
            {
                Console.WriteLine("Cool");
                //Load it
                LoadRecipes(path);
            } else
            {
                //Create the directory
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// Event handler for the "add" button.
        /// Begins adding a new recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Add_Click(object sender, EventArgs e)
        {
            AddRecipeForm FormAdd = new AddRecipeForm();
            FormAdd.ShowDialog();
        }

        /// <summary>
        /// Add recipe. Takes input from Add_Click and addRecipe form and creates a new object
        /// </summary>
        /// <param name="newName">Recipe name</param>
        /// <param name="newTime">Total time to cook</param>
        /// <param name="steps">Each step</param>
        /// <param name="ingreds">Ingredients needed</param>
        public static void AddRecipe(String newName, String newTime, String steps, String ingreds, string category)
        {
            Recipe food = new Recipe(newName, newTime, steps, ingreds, category); //Creates a new recipe object with name, time, num of steps and num of ingreds.
            recipeList.AddLast(food); //Adds recipe to end of the class's linked list.
            MessageBox.Show(food.ToString()); //Quick display
        }

        public static void DisplayError()
        {
            MessageBox.Show("You have no recipes! \nClick \"add\" to create a new recipe.", "ERROR");
        }

        /// <summary>
        /// Event handler for the "remove" button
        /// Removes a recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Remove_Click(object sender, EventArgs e)
        {
            if (recipeList.Count == 0 || recipeList is null)
            {
                DisplayError();
            } else
            {
                MessageBox.Show("Choose a recipe to delete.");
                ViewRecipeForm FormView = new ViewRecipeForm(0);
                FormView.ShowDialog();
            }
        }

        /// <summary>
        /// Event handler for the "edit" button
        /// Edits a recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Edit_Click(object sender, EventArgs e)
        {
            if(recipeList.Count == 0)
            {
                DisplayError();
            } else
            {
                //Display all recipes
                MessageBox.Show("Choose a recipe to edit.");
                ViewRecipeForm FormView = new ViewRecipeForm(1);
                FormView.ShowDialog();
            }
        }

        /// <summary>
        /// Event handler for the "view" button
        /// Displays a recipe in a nice format.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void View_Click(object sender, EventArgs e)
        {
            if (recipeList.Count == 0)
            {
                DisplayError();
            } else
            {
                MessageBox.Show("Choose a recipe to view.");
                //Display all available recipes
                ViewRecipeForm FormView = new ViewRecipeForm(2);
                FormView.ShowDialog();
            }
        }

        /// <summary>
        /// Locates the recipe with the same name as the parameter.
        /// </summary>
        /// <param name="name">Name of the recipe wanted.</param>
        /// <returns>The recipe with the name of the parameter.</returns>
        public static Recipe FindRecipe(string name)
        {
            //Run through the enumerator and find the recipe with the same name
            LinkedList<Recipe>.Enumerator em = recipeList.GetEnumerator();
            while(em.MoveNext())
            {
                if (name.Equals(em.Current.Name))
                {
                    return em.Current;
                }
            }

            return null;
        }

        public LinkedList<Recipe> LoadRecipes(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string name = sr.ReadLine();
                    string time = sr.ReadLine();
                    string steps = sr.ReadLine();
                    string ingredients = sr.ReadLine();
                    Recipe new_rp = new Recipe(name, time, steps, ingredients);
                    recipeList.AddLast(new_rp);
                }
            }
                return null;
        }

        public void SaveRecipes(string path)
        {
            if (File.Exists(path))
            {
                IEnumerator<Recipe> ienum = recipeList.GetEnumerator();
                //Save the recipe list
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach(Recipe x in recipeList)
                    {
                        sw.WriteLine(x.Name);
                        sw.WriteLine(x.Time);
                        sw.WriteLine(x.Steps);
                        sw.WriteLine(x.Ingredients);
                    }
                }
            }
        }

        /// <summary>
        /// Event handler for the "exit" button.
        /// Exits program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Exit_Click(object sender, EventArgs e)
        {
            SaveRecipes(path);
            System.Windows.Forms.Application.Exit();
        }

    }
}
