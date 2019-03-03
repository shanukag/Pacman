using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanIEDigital
{

    public partial class Form1 : Form
    {
        //Declaring global variables
        TextBox xCoordinateTextBox;
        TextBox yCoordinateTextBox;
        ComboBox directionsCombobox;
        Form placeForm;
        Dictionary<int, int> gridXMap = new Dictionary<int, int>();
        Dictionary<int, int> gridYMap = new Dictionary<int, int>();
        int pointerX;
        int pointerY;
        Directions directionValue = Directions.EAST;
        Directions result = Directions.EMPTY;
        const int X_MAX_VALUE = 4;
        const int X_MIN_VALUE = 0;
        const int Y_MAX_VALUE = 4;
        const int Y_MIN_VALUE = 0;
        const int GRID_CELL_SIZE = 55;
        bool pacmanPlaced = false;
        int gridStartingLocationX = 72;
        int gridStartingLocationY = 325;

        public Form1()
        {
            InitializeComponent();
            //Mapping grid index to x,y location 
            gridXMap.Add(0,gridStartingLocationX);
            gridXMap.Add(1, gridStartingLocationX + GRID_CELL_SIZE);
            gridXMap.Add(2, gridStartingLocationX + (GRID_CELL_SIZE * 2));
            gridXMap.Add(3, gridStartingLocationX + (GRID_CELL_SIZE * 3));
            gridXMap.Add(4, gridStartingLocationX + (GRID_CELL_SIZE * 4));
            gridYMap.Add(0, gridStartingLocationY);
            gridYMap.Add(1, gridStartingLocationY - GRID_CELL_SIZE);
            gridYMap.Add(2, gridStartingLocationY - (GRID_CELL_SIZE * 2));
            gridYMap.Add(3, gridStartingLocationY - (GRID_CELL_SIZE * 3));
            gridYMap.Add(4, gridStartingLocationY - (GRID_CELL_SIZE * 4));

        }

        //Checking whether Pacman falls off the grid
        public bool CheckGrid(int x, int y)
        {            
            bool errorStatus = false;
            if (x > X_MAX_VALUE || x < X_MIN_VALUE || y > Y_MAX_VALUE || y < Y_MIN_VALUE)
            {
                if (!pacmanPlaced)
                    DisplayError(String.Format("X & Y Values should be between {0}, {1}",X_MIN_VALUE,X_MAX_VALUE));
                else
                    DisplayError("Reached grid end");

                errorStatus = true;                
            }
            return errorStatus;
        }

        //Creating the place form and retrieving user input
        private void placeButton_Click(object sender, EventArgs e)
        {
            pacmanPlaced = false;
            placeForm = new Form() {Width = 400, Height = 220};
            xCoordinateTextBox = new TextBox() { Left = 300, Top = 48, Width = 65 };
            yCoordinateTextBox = new TextBox() { Left = 300, Top = 78, Width = 65 };
            Label xLabel = new Label() { Text = "Please enter X Coordinate between (0 - 4) ", Left = 10, Top = 50, Width = 250 };
            Label yLabel = new Label() { Text = "Please enter Y Coordinate  between (0 - 4)", Left = 10, Top = 80, Width = 250 };
            Label directionLabel = new Label() { Text = "Please select direction'", Left = 10, Top = 110, Width = 250 };
            directionsCombobox = new ComboBox() { Left = 300, Top = 108, Width = 65, DropDownStyle = ComboBoxStyle.DropDownList };
            directionsCombobox.Items.Add(Directions.NORTH.ToString());
            directionsCombobox.Items.Add(Directions.EAST.ToString());
            directionsCombobox.Items.Add(Directions.WEST.ToString());
            directionsCombobox.Items.Add(Directions.SOUTH.ToString());
            Button confirmation = new Button() { Text = "OK", Left = 300, Top = 138, Width = 65 };
            confirmation.Click += Confirmation_Click;
            placeForm.Controls.Add(xLabel);
            placeForm.Controls.Add(yLabel);
            placeForm.Controls.Add(xCoordinateTextBox);
            placeForm.Controls.Add(yCoordinateTextBox);
            placeForm.Controls.Add(directionsCombobox);
            placeForm.Controls.Add(directionLabel);
            placeForm.Controls.Add(confirmation);
            placeForm.AcceptButton = confirmation;
            placeForm.Text = "Place Pacman";
            placeForm.ShowDialog();
        }

        //Checking user input validity and placing Pacman on the grid
        private void Confirmation_Click(object sender, EventArgs e)
        {   if(String.IsNullOrEmpty(xCoordinateTextBox.Text) || String.IsNullOrEmpty(yCoordinateTextBox.Text))
                DisplayError("Coordinates cannot be empty");
            else if (String.IsNullOrEmpty(directionsCombobox.Text))
                DisplayError("Direction cannot be empty");
            else
            {
                bool parseResult = int.TryParse(xCoordinateTextBox.Text, out pointerX);
                parseResult = int.TryParse(yCoordinateTextBox.Text, out pointerY);
                if (!parseResult)
                    DisplayError("X and Y coordinates can only be numbers");
                else
                {
                    if (!CheckGrid(pointerX, pointerY))
                    {
                        int tempX;
                        int tempY;
                        gridXMap.TryGetValue(pointerX, out tempX);
                        gridYMap.TryGetValue(pointerY, out tempY);
                        placeForm.Close();
                        Man.Location = new Point(tempX, tempY);
                        Enum.TryParse(directionsCombobox.Text.ToUpper(), out result);
                        //Load an image in from a file
                        if (Man.Image != null)
                            Man.Image.Dispose();
                        Image image = new Bitmap(Properties.Resources.pacman_resized);
                        //Set our picture box to that image
                        Man.Image = (Bitmap)image.Clone();
                        pacmanPlaced = true;
                        switch (result)
                        {
                            case Directions.EAST:

                                Man.Image = RotateImage(Man.Image, 0f);
                                directionValue = Directions.EAST;

                                break;
                            case Directions.WEST:

                                Man.Image = RotateImage(Man.Image, 180f);
                                directionValue = Directions.WEST;

                                break;
                            case Directions.NORTH:

                                Man.Image = RotateImage(Man.Image, -90f);
                                directionValue = Directions.NORTH;

                                break;
                            case Directions.SOUTH:

                                Man.Image = RotateImage(Man.Image, 90f);
                                directionValue = Directions.SOUTH;

                                break;
                            default:
                                break;
                        }
                    }
                }
            }            

        }

        //Moving Pacman by one cell in the direction Pacman is facing
        private void moveButton_Click(object sender, EventArgs e)
        {
            if (!pacmanPlaced)
                DisplayError("Please place Pacman on the grid first!");
            else
            {
                int tempX = pointerX;
                int tempY = pointerY;
                switch (directionValue)
                {
                    case Directions.EAST:
                        tempX++;
                        if (!CheckGrid(tempX, tempY))
                        {
                            pointerX++;
                            Man.Location = new Point(Man.Location.X + GRID_CELL_SIZE, Man.Location.Y);
                        }
                        break;
                    case Directions.WEST:
                        tempX--;
                        if (!CheckGrid(tempX, tempY))
                        {
                            pointerX--;
                            Man.Location = new Point(Man.Location.X - GRID_CELL_SIZE, Man.Location.Y);
                        }
                        break;
                    case Directions.NORTH:
                        tempY++;
                        if (!CheckGrid(tempX, tempY))
                        {
                            pointerY++;
                            Man.Location = new Point(Man.Location.X, Man.Location.Y - GRID_CELL_SIZE);
                        }
                        break;
                    case Directions.SOUTH:
                        tempY--;
                        if (!CheckGrid(tempX, tempY))
                        {
                            pointerY--;
                            Man.Location = new Point(Man.Location.X, Man.Location.Y + GRID_CELL_SIZE);
                        }
                        break;
                    default:
                        break;
                }
            }
        }


        //Rotating Pacman counter clockwise
        private void leftButton_Click(object sender, EventArgs e)
        {
            if (!pacmanPlaced)
                DisplayError("Please place Pacman on the grid first!");
            else
            {
                switch (directionValue)
                {
                    case Directions.EAST:
                        Man.Image = RotateImage(Man.Image, -90f);
                        directionValue = Directions.NORTH;
                        break;
                    case Directions.WEST:
                        Man.Image = RotateImage(Man.Image, -90f);
                        directionValue = Directions.SOUTH;
                        break;
                    case Directions.NORTH:
                        Man.Image = RotateImage(Man.Image, -90f);
                        directionValue = Directions.WEST;
                        break;
                    case Directions.SOUTH:
                        Man.Image = RotateImage(Man.Image, -90f);
                        directionValue = Directions.EAST;
                        break;
                    default:
                        break;
                }
            }
        }

        //Rotating Pacman clockwise
        private void rightButton_Click(object sender, EventArgs e)
        {
            if (!pacmanPlaced)
                DisplayError("Please place Pacman on the grid first!");
            else
            {
                switch (directionValue)
                {
                    case Directions.EAST:
                        Man.Image = RotateImage(Man.Image, 90f);
                        directionValue = Directions.SOUTH;
                        break;
                    case Directions.WEST:
                        Man.Image = RotateImage(Man.Image, 90f);
                        directionValue = Directions.NORTH;
                        break;
                    case Directions.NORTH:
                        Man.Image = RotateImage(Man.Image, 90f);
                        directionValue = Directions.EAST;
                        break;
                    case Directions.SOUTH:
                        Man.Image = RotateImage(Man.Image, 90f);
                        directionValue = Directions.WEST;
                        break;
                    default:
                        break;
                }
            }
        }

        //Writing the Pacman location and direction to the form textbox in the format X,Y NORTH
        private void reportButton_Click(object sender, EventArgs e)
        {
            if (!pacmanPlaced)
                DisplayError("Please place Pacman on the grid first!");
            else
            {
                displayBox.Text = String.Format("{0},{1} {2}", pointerX, pointerY, directionValue);
            }
        }


        //Method to draw the grid
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int numOfCells = 5;
            Pen p = new Pen(Color.Black);

            for (int y = 0; y < numOfCells + 1; ++y)
            {
                g.DrawLine(p, 0, y * GRID_CELL_SIZE, numOfCells * GRID_CELL_SIZE, y * GRID_CELL_SIZE);

            }

            for (int x = 0; x < numOfCells + 1; ++x)
            {
                g.DrawLine(p, x * GRID_CELL_SIZE, 0, x * GRID_CELL_SIZE, numOfCells * GRID_CELL_SIZE);
            }
                        
        }

        //Method to display error messages
        private void DisplayError(string error)
        {
            Label message = new Label() { Text = error, Width = 250, AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Top, Top = 40 };
            Form gridForm = new Form() { Width = 370, Height = 130, Text = "Error"};
            Button dlgOkButton = new Button() { Text = "Try Again", Left = 120, Width = 100, Top = 50 };
            dlgOkButton.Click += (s, ev) => { gridForm.Close(); };
            gridForm.Controls.Add(message);
            gridForm.Controls.Add(dlgOkButton);
            gridForm.ShowDialog();
        }

        //Method to rotate Pacman
        private Image RotateImage(Image img, float rotationAngle)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);            
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            gfx.RotateTransform(rotationAngle);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.DrawImage(img, new Point(0, 0));
            gfx.Dispose();

            //return the image
            return bmp;
        }
    }
}
