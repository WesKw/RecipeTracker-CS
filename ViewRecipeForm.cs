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

        public static int yLoc = 50;

        public ViewRecipeForm()
        {
            InitializeComponent();

            //Get Enumerator for recipeList
            LinkedList<Recipe>.Enumerator em = Form1.recipeList.GetEnumerator();
            MessageBox.Show("Enumerator made");

            while(em.MoveNext())
            {
                MessageBox.Show("Inside of while loop");
                Button recButton = new Button(); //Create new button
                recButton.Text = em.Current.GetName(); //Button text gets name of current recipe
                recButton.Location = new Point(50, yLoc); //Place buttons beneath each other
                recButton.Click += new EventHandler(Recipe_Click); //Click handler
                this.Controls.Add(recButton);

                yLoc += 100; //y location increased by 250

            }
        }

        //TODO
        /// <summary>
        /// This click handler displays the recipe clicked by the user
        /// Uses the name of the button to find the recipe requested.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Recipe_Click(Object sender, EventArgs e)
        {
            MessageBox.Show("true");
        }
    }
}
