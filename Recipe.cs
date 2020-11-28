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
        private String steps;
        private String ingredients;

        //Category (TO DO)
        public string category;

        //Default constructor
        public Recipe()
        {
            this.name = "Placeholder";
            this.time = "99:99 hrs";
            this.steps = "";
            this.ingredients = "";
        }

        //Overloaded constructor without category
        public Recipe(String newName, String newTime, String steps, String ingredients)
        {
            this.name = newName;
            this.time = newTime;
            this.steps = steps;
            this.ingredients = ingredients;
        }

        //Overloaded constructor that takes args for each member in recipe
        public Recipe(String newName, String newTime, String steps, String ingredients, string category)
        {
            this.name = newName;
            this.time = newTime;
            this.steps = steps;
            this.ingredients = ingredients;
            this.category = category;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        public string Steps
        {
            get { return steps; }
            set { steps = value; }
        }

        public string Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }

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
            Form MainForm = new Form1();
            Application.Run(MainForm);
        }
    }
}
