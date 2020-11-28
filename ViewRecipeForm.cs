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
    public partial class ViewRecipeForm : Form
    {

        public static int yLoc;

        /// <summary>
        /// Constructor for the ViewRecipeForm
        /// </summary>
        /// <param name="Action">The current action determined by user. 0 is 
        /// remove, 1 is edit, 2 is view.</param>
        public ViewRecipeForm(int Action)
        {
            InitializeComponent();

            //Get Enumerator for recipeList
            LinkedList<Recipe>.Enumerator em = Form1.recipeList.GetEnumerator();
            //MessageBox.Show("Enumerator made");

            //Set yLoc to 50
            yLoc = 50;

            while(em.MoveNext())
            {
                //MessageBox.Show("Inside of while loop");
                Button recButton = new Button(); //Create new button
                recButton.Text = em.Current.Name; //Button text gets name of current recipe
                recButton.Location = new Point(50, yLoc); //Place buttons beneath each other

                if (Action == 0)
                    recButton.Click += new EventHandler(Remove_Click); //Remove handler

                if (Action == 1)
                    recButton.Click += new EventHandler(Edit_Click); //Edit handler

                if(Action == 2)
                    recButton.Click += new EventHandler(View_Click); //View handler

                this.Controls.Add(recButton);

                yLoc += 100; //y location increased by 250

            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Remove_Click(object sender, EventArgs e)
        {
            Button remove = sender as Button;
            string recipeName = remove.Text;
            Recipe wantToRemove = Form1.FindRecipe(recipeName);
            Form1.recipeList.Remove(wantToRemove);
            remove.BackColor = Color.Red;
        }

        public void Edit_Click(object sender, EventArgs e)
        {
            Button edit = sender as Button;
            string recipeName = edit.Text;
            Recipe wantToEdit = Form1.FindRecipe(recipeName);

            AddRecipeForm EditForm = new AddRecipeForm();
            EditForm.ShowDialog();

            EditForm.nameBox.Text = wantToEdit.Name;
            EditForm.timeBox.Text = wantToEdit.Time;
            EditForm.stepsBox.Text = wantToEdit.Steps;
            EditForm.ingredBox.Text = wantToEdit.Ingredients;
            EditForm.categBox.Text = wantToEdit.category;

        }

        /// <summary>
        /// This click handler displays the recipe clicked by the user. 
        /// Uses the name of the button to find the recipe requested.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void View_Click(object sender, EventArgs e)
        {
            Button display = sender as Button;
            string recipeName = display.Text;

            MessageBox.Show(Form1.FindRecipe(recipeName).ToString());
        }
    }
}
