using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeTracker3
{
    public partial class AddRecipeForm : Form
    {
        //Enter button
        public Button create;
        //Name
        public TextBox nameBox;
        public Label nameLabel;
        //Time
        public TextBox timeBox;
        public Label timeLabel;
        //Steps
        public RichTextBox stepsBox;
        public Label stepsLabel;
        //Ingredients
        public RichTextBox ingredBox;
        public Label ingredLabel;
        //Category
        public TextBox categBox;
        public Label categLabel;
        public AddRecipeForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.create = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.stepsBox = new System.Windows.Forms.RichTextBox();
            this.stepsLabel = new System.Windows.Forms.Label();
            this.ingredBox = new System.Windows.Forms.RichTextBox();
            this.ingredLabel = new System.Windows.Forms.Label();
            this.categBox = new System.Windows.Forms.TextBox();
            this.categLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(571, 502);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(177, 30);
            this.create.TabIndex = 0;
            this.create.Text = "Create";
            this.create.Click += new System.EventHandler(this.Create_Click);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(91, 27);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(350, 22);
            this.nameBox.TabIndex = 0;
            // 
            // nameLabel
            // 
            this.nameLabel.Location = new System.Drawing.Point(12, 30);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(100, 30);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(571, 24);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(177, 22);
            this.timeBox.TabIndex = 1;
            // 
            // timeLabel
            // 
            this.timeLabel.Location = new System.Drawing.Point(465, 27);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(100, 30);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "Time:";
            // 
            // stepsBox
            // 
            this.stepsBox.Location = new System.Drawing.Point(91, 113);
            this.stepsBox.Name = "stepsBox";
            this.stepsBox.Size = new System.Drawing.Size(350, 368);
            this.stepsBox.TabIndex = 3;
            this.stepsBox.Text = "";
            // 
            // stepsLabel
            // 
            this.stepsLabel.Location = new System.Drawing.Point(12, 113);
            this.stepsLabel.Name = "stepsLabel";
            this.stepsLabel.Size = new System.Drawing.Size(100, 30);
            this.stepsLabel.TabIndex = 0;
            this.stepsLabel.Text = "Steps:";
            // 
            // ingredBox
            // 
            this.ingredBox.Location = new System.Drawing.Point(571, 110);
            this.ingredBox.Name = "ingredBox";
            this.ingredBox.Size = new System.Drawing.Size(177, 371);
            this.ingredBox.TabIndex = 4;
            this.ingredBox.Text = "";
            // 
            // ingredLabel
            // 
            this.ingredLabel.Location = new System.Drawing.Point(465, 110);
            this.ingredLabel.Name = "ingredLabel";
            this.ingredLabel.Size = new System.Drawing.Size(100, 30);
            this.ingredLabel.TabIndex = 0;
            this.ingredLabel.Text = "Ingredients:";
            // 
            // categBox
            // 
            this.categBox.Location = new System.Drawing.Point(91, 60);
            this.categBox.Name = "categBox";
            this.categBox.Size = new System.Drawing.Size(350, 22);
            this.categBox.TabIndex = 2;
            // 
            // categLabel
            // 
            this.categLabel.Location = new System.Drawing.Point(12, 60);
            this.categLabel.Name = "categLabel";
            this.categLabel.Size = new System.Drawing.Size(100, 30);
            this.categLabel.TabIndex = 0;
            this.categLabel.Text = "Category:";
            // 
            // AddRecipeForm
            // 
            this.ClientSize = new System.Drawing.Size(795, 554);
            this.Controls.Add(this.create);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.stepsBox);
            this.Controls.Add(this.stepsLabel);
            this.Controls.Add(this.ingredBox);
            this.Controls.Add(this.ingredLabel);
            this.Controls.Add(this.categBox);
            this.Controls.Add(this.categLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddRecipeForm";
            this.Text = "Recipe Tracker";
            this.Load += new System.EventHandler(this.AddRecipeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public AddRecipeForm(int Action)
        {
            InitializeComponent();

        }

        private void AddRecipeForm_Load(object sender, System.EventArgs e)
        {
            MessageBox.Show("Please enter information into the boxes.");
        }

        public void Create_Click(object sender, System.EventArgs e)
        {
            //Check if any values in are missing
            if (nameBox.Text == "" || timeBox.Text == "" || stepsBox.Text == "" || ingredBox.Text == "" || categBox.Text == "")
            {
                MessageBox.Show("Error: Missing information!");
            }
            else
            {
                string[] recipeInfo = new string[5];
                recipeInfo[0] = nameBox.Text;
                recipeInfo[1] = timeBox.Text;
                recipeInfo[2] = stepsBox.Text;
                recipeInfo[3] = ingredBox.Text;
                recipeInfo[4] = categBox.Text;

                Form1.AddRecipe(recipeInfo[0], recipeInfo[1], recipeInfo[2], recipeInfo[3], recipeInfo[4]);

                this.Close();
            }
        }
    }
}
