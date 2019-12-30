using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeTracker3
{

    public class Recipe
    {

        //Create recipe components
        private String name;
        private String time;

        //Arrays public for now
        public String steps;
        public String ingredients;

        public Recipe()
        {
            this.name = "Placeholder";
            this.time = "99:99 hrs";
            this.steps = "";
            this.ingredients = "";
        }

        public Recipe(String newName, String newTime, String steps, String ingredients)
        {
            this.name = newName;
            this.time = newTime;
            this.steps = steps;
            this.ingredients = ingredients;
        }

        //Getter methods
        public String GetName()
        {
            return this.name;
        }

        public String GetTime()
        {
            return this.time;
        }

        public String GetSteps()
        {
            return this.steps;
        }

        public String GetIngred()
        {
            return this.ingredients;
        }
        //End getter methods

        //Mutator Methods
        public void SetName(String newName)
        {
            this.name = newName;
        }

        public void SetTime(String newTime)
        {
            this.time = newTime;
        }

        public void SetSteps(String newSteps)
        {
            this.steps = newSteps;
        }

        public void SetIngreds(String newIngreds)
        {
            this.ingredients = newIngreds;
        }

        /*
        public void AddRecipe(String newName, String newTime, String steps, String ingreds)
        {
            Recipe food = new Recipe(newName, newTime, steps, ingreds); //Creates a new recipe object with name, time, num of steps and num of ingreds.
            //recipeList.AddLast(recipe); //Adds recipe to end of the class's linked list.

        }
        */

        //ToString
        public override String ToString()
        {
            return this.name + "\n\n" + this.time + "\n\n" + this.ingredients + "\n\n" + this.steps;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
