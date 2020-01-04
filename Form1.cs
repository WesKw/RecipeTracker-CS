using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Form1()
        {
            InitializeComponent();
            this.Name = "Recipe Tracker 3";
            this.Text = "Recipe Tracker";

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
        public static void AddRecipe(String newName, String newTime, String steps, String ingreds)
        {
            Recipe food = new Recipe(newName, newTime, steps, ingreds); //Creates a new recipe object with name, time, num of steps and num of ingreds.
            recipeList.AddLast(food); //Adds recipe to end of the class's linked list.
            MessageBox.Show(food.ToString()); //Quick display
        }

        /// <summary>
        /// Event handler for the "remove" button
        /// Removes a recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Remove_Click(object sender, EventArgs e)
        {
            if (recipeList.Count == 0)
            {
                MessageBox.Show("You have no recipes to remove! \nClick \"add\" to create a new recipe.");
            } else
            {
                //Display all recipes
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
                MessageBox.Show("You have no recipes to edit! \nClick \"add\" to create a new recipe.");
            } else
            {
                //Display all recipes
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
                MessageBox.Show("You have no recipes to view! \nClick \"add\" to create a new recipe.");
            } else
            {
                //Display all available recipes
                ViewRecipeForm FormView = new ViewRecipeForm();
                FormView.ShowDialog();
            }
        }

        /// <summary>
        /// Event handler for the "exit" button.
        /// Exits the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
