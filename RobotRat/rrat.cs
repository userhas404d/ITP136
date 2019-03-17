/* 

Write a C# application that controls the movements of a robot car around a floor.

The robot car will move about a "floor" represented by a two-dimensional array. 
The robot car has a paint sprayer attached to its rear fender. As the car moves about the floor it will leave a mark if the sprayer is on but not if the sprayer is off.

- [x] The floor array may be of type bool (boolean) or any other type you deem appropriate. 

Control the robot car with a simple text-based menu. 
Your menu should also allow a user to 
- [x] make the car turn right, turn left and move forward a number of spaces. 
- [x] turn the paint sprayer (Pen) on or off, 
- [x] print the floor pattern, 
- [x] and exit the application.
- [x] Each time you move the car forward print the floor to show the car's progress.

*/

using System;

public class RobotRat
{

    private enum Directions {NORTH, SOUTH, EAST, WEST}
    private enum PenPositions {UP, DOWN}

    //Constants
    /* usually these are public */
    private const char PEN_UP      = '1';
    private const char PEN_DOWN    = '2';
    private const char TURN_LEFT   = '3';
    private const char TURN_RIGHT  = '4';
    private const char MOVE        = '5';
    private const char PRINT_FLOOR = '6';
    private const char EXIT        = '7';
    private const int ROWS = 0;
    private const int COLS = 1;

    private const int WINDOW_WIDTH = 150;
    private const int WINDOW_HEIGHT = 51;
    private const int MENU_WIDTH = 55;
    private const int SPACER = MENU_WIDTH + 5;
    protected static int origRow;
    protected static int origCol;

    //Fields
    /* variables that can have a value 
     includes leading _ to determine at a glance if the var is a field or constant
         */
    private bool _keep_going = true;
    private char[,] _floor;
    private int _current_row;
    private int _current_col;

    private int _previous_row;
    private int _previous_col;
    private Directions _its_direction;
    private PenPositions _its_pen_position;

    private int _inputCol = 0;
    private int _inputRow = 0;


    //Constructors
    //default constructor
    public RobotRat():this(15,15){}

    public RobotRat(int rows, int cols) {
        Console.Clear();
        _floor = new char[rows, cols];
        _current_row = 10;
        _current_col = 10;
        _previous_row = _current_row;
        _previous_col = _current_col;
        _its_direction = Directions.NORTH;
        _its_pen_position = PenPositions.UP;
        InitializeFloor();
    }

    //Methods

    public void ConfigureConsole(){
        Console.Clear();
        Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);
    }
    public void PrintMenu()
    {
        string border = "";
        for(int x = 0; x < MENU_WIDTH; x ++){
            border += "*";
        }
        Console.WriteLine(border);
        string banner = @" 
  _____       _           _     _____       _   
 |  __ \     | |         | |   |  __ \     | |  
 | |__) |___ | |__   ___ | |_  | |__) |__ _| |_ 
 |  _  // _ \| '_ \ / _ \| __| |  _  // _` | __|
 | | \ \ (_) | |_) | (_) | |_  | | \ \ (_| | |_ 
 |_|  \_\___/|_.__/ \___/ \__| |_|  \_\__,_|\__|
                                                ";
        Console.WriteLine(banner);
        Console.WriteLine("\n"+border);
        Console.WriteLine("\t\t1. Pen Up");
        Console.WriteLine("\t\t2. Pen Down");
        Console.WriteLine("\t\t3. Turn Left");
        Console.WriteLine("\t\t4. Turn Right");
        Console.WriteLine("\t\t5. Move");
        Console.WriteLine("\t\t6. Print Floor");
        Console.WriteLine("\t\t7. Exit");
        Console.WriteLine("\n"+border);
        Console.Write("Please Enter A Menu Choice: ");
    }

    public void ProcessMenuChoice() {
        string input = Console.ReadLine();
        if (input.Length == 0) {
            input = "8";
        }
        // Console.WriteLine("user entered " + input);
        switch (input[0])
        {
            case PEN_UP:
                SetPenUp();
                PrintCarStatus();
                break;
            case PEN_DOWN:
                SetPenDown();
                PrintCarStatus();
                break;
            case TURN_LEFT:
                TurnLeft();
                PrintCarStatus();
                break;
            case TURN_RIGHT:
                TurnRight();
                PrintCarStatus();
                break;
            case MOVE:
                Move();
                PrintFloor();
                PrintCarStatus();
                break;
            case PRINT_FLOOR:
                //set cursor to right of current menu
                PrintFloor();
                PrintCarStatus();
                break;
            case EXIT:
                Console.Clear();
                _keep_going = false;
                break;
            default:
                Console.WriteLine("Please Enter a valid menu choice");
                break;
        }
    }

    public void SetPenUp()
    {
        _its_pen_position = PenPositions.UP;
        //Console.WriteLine("Pen is "+ _its_pen_position);
    }

    public void SetPenDown()
    {
        _its_pen_position = PenPositions.DOWN;
        //Console.WriteLine("Pen is "+ _its_pen_position);
    }

    public void TurnLeft()
    {
        switch(_its_direction){
            case Directions.NORTH: _its_direction = Directions.WEST;
                break;
            case Directions.SOUTH: _its_direction = Directions.EAST;
                break;
            case Directions.EAST: _its_direction = Directions.NORTH;
                break;
            case Directions.WEST: _its_direction = Directions.SOUTH;
                break;
            }

        //Console.WriteLine("TurnLeft() method called.");
    }

    public void TurnRight()
    {
        switch(_its_direction){
            case Directions.WEST: _its_direction = Directions.NORTH;
                break;
            case Directions.EAST: _its_direction = Directions.SOUTH;
                break;
            case Directions.NORTH: _its_direction = Directions.EAST;
                break;
            case Directions.SOUTH: _its_direction = Directions.WEST;
                break;
            }
        //Console.WriteLine("TurnRight() method called.");
    }

    public void Move()
    {

        _previous_col = _current_col;
        _previous_row = _current_row; 
        Console.SetCursorPosition(0, _inputRow);
        Console.Write("                                      ");
        Console.SetCursorPosition(0, _inputRow);
        Console.Write("Spaces to move: ");
        int spaces_to_move = 0;
        // can't move more rows than there are rows 
        try{
            spaces_to_move = Int32.Parse(Console.ReadLine());
        } catch(Exception){
            spaces_to_move = 1;
        }

        switch(_its_pen_position){

            case PenPositions.UP:
                switch(_its_direction){
                    case Directions.NORTH: {
                        _current_row = _current_row - spaces_to_move;
                        if(_current_row < 0){
                            _current_row = 0;
                        }
                    }
                    break;
                    case Directions.SOUTH: {
                        _current_row = _current_row + spaces_to_move;
                        if(_current_row > _floor.GetLength(ROWS)-1){
                            _current_row = _floor.GetLength(ROWS)-1;
                        }
                    }
                    break;
                    case Directions.EAST: {
                        _current_col = _current_col + spaces_to_move;
                        if(_current_row > _floor.GetLength(COLS)-1){
                            _current_row = _floor.GetLength(COLS)-1;
                        }
                    }
                    break;
                    case Directions.WEST:  {
                        _current_col = _current_col - spaces_to_move;
                        if(_current_row > _floor.GetLength(COLS)-1){
                            _current_row = _floor.GetLength(COLS)-1;
                        }
                    }
                    break;
                // Console.WriteLine("Move() method called.");
                } break; // end switch

            case PenPositions.DOWN:
                switch(_its_direction){
                    case Directions.NORTH:
                        while((_current_row > 0) && (spaces_to_move-- > 0)){
                            _floor[_current_row--, _current_col] = '^';
                        }
                        break;
                    case Directions.SOUTH:
                        while((_current_row > 0) && (spaces_to_move-- > 0)){
                            _floor[_current_row++, _current_col] = 'v';
                        }
                        break;
                    case Directions.EAST:
                        while((_current_col > 0) && (spaces_to_move-- > 0)){
                            _floor[_current_row, _current_col++] = '>';
                        }
                        break;
                    case Directions.WEST:
                        while((_current_col > 0) && (spaces_to_move-- > 0)){
                            _floor[_current_row, _current_col--] = '<';
                        }
                        break;
                } break;
        }
    }


    public void PrintFloor()
    {
        
        // if (_its_pen_position == PenPositions.DOWN){
        //     _floor[_previous_col, _previous_col] = 'P';
        //     _floor[_current_col, _current_col] = 'C';
            
        // }

        string floor_border = "";
        for (int x=0; x < _floor.GetLength(1); x++){
            floor_border += "===";
        }

        Console.SetCursorPosition(origCol+SPACER, origRow);
        int currentRow = Console.CursorTop;
        int currentCol = Console.CursorLeft;

        // idiomatic way of processing multidimensional array within c#
        // if you use other characters there are many other possibilities
        // ie show the direction the car is facing, etc.
        
        // floor border top
        Console.Write(floor_border);
        //Console.SetCursorPosition(currentCol, currentRow+1);
        
        Console.SetCursorPosition(SPACER+currentCol, Console.CursorTop);
        // actual floor
        for (int i = 0; i < _floor.GetLength(0); i++) {

            if(i == 0){
                Console.SetCursorPosition(Console.CursorLeft++-SPACER, Console.CursorTop+1);
            }else{
                Console.SetCursorPosition(SPACER+Console.CursorLeft++, Console.CursorTop);
            }
           

            for (int j = 0; j < _floor.GetLength(1); j++) {
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop++);


                if( _floor[i,j] != '0'){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" " + _floor[i,j] + " ");
                    Console.ResetColor();
                } else{
                    Console.Write(" " + _floor[i,j] + " ");
                }           
            } // inner for loop
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.Write("\n");
        } // outer for loop

        // floor border bottom
        Console.SetCursorPosition(Console.CursorLeft+SPACER, Console.CursorTop);
        Console.Write(floor_border);
        Console.SetCursorPosition(origCol, origRow);

    } // end PrintFloor

    public void PrintCarStatus()
    {
        //clear the console
        //Console.Clear();
        Console.SetCursorPosition(Console.CursorLeft, Console.CursorLeft+22);

        // these borders should probably be tied to floor size
        string border = "";
        for (int x=0; x < MENU_WIDTH-1; x++){
            border += "=";
        }

        string border_sub = "";
        for (int x=0; x < MENU_WIDTH-1; x++){
            border_sub += "-";
        }

        Console.SetCursorPosition(SPACER+Console.CursorLeft, Console.CursorTop);
        int currentCol = Console.CursorLeft;
        Console.Write(border);
        Console.SetCursorPosition(currentCol, Console.CursorTop+1);
        Console.Write("Positions");
        Console.SetCursorPosition(currentCol, Console.CursorTop+1);
        Console.Write(border_sub);
        Console.SetCursorPosition(currentCol, Console.CursorTop+1);
        Console.Write("Previous: (" + _previous_col + "," + _previous_row + ")" + "\tCurrent: (" +_current_col + "," + _current_row + ")");
        Console.SetCursorPosition(currentCol, Console.CursorTop+1);
        string direction_status = "";
        direction_status += "Direction: " + _its_direction;
        // avoid 'straggling' chars
        Console.Write("Direction:      ");
        Console.SetCursorPosition(currentCol, Console.CursorTop);
        Console.Write(direction_status);
        Console.SetCursorPosition(currentCol+direction_status.Length+1, Console.CursorTop);

        string pen_status = "\tPen: ";
    
        Console.Write(pen_status);
        // avoid 'straggling' chars
        Console.SetCursorPosition(currentCol+direction_status.Length+10, Console.CursorTop);
        Console.Write("    ");
        if(_its_pen_position == PenPositions.DOWN){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(currentCol+direction_status.Length+9, Console.CursorTop);
            Console.Write(_its_pen_position);
            Console.ResetColor();
        }else{
            Console.SetCursorPosition(currentCol+direction_status.Length+9, Console.CursorTop);
            Console.Write(_its_pen_position);
        }
        
        Console.SetCursorPosition(currentCol, Console.CursorTop+1);
        Console.WriteLine(border);
    }

    public void InitializeFloor()
    {
       // Console.ForegroundColor = ConsoleColor.DarkGreen;

        for (int row = 0; row < _floor.GetLength(0); row++)
        {
            for (int col = 0; col < _floor.GetLength(1); col++)
            {
                _floor[row, col] = '0';
            } // inner for loop
            Console.WriteLine();
        } // outer for loop

        // _floor[0, 0] = '|';
        // _floor[1, 0] = '|';
        // _floor[2, 0] = '|';
        // _floor[3, 0] = '_';
        // _floor[3, 1] = '_';
        // _floor[3, 2] = '_';
        // _floor[3, 3] = 'x';
    }

    public void Go() {
        ConfigureConsole();
        PrintMenu();
        _inputRow = Console.CursorTop;
        _inputCol = Console.CursorLeft;
        while (_keep_going) {
            Console.SetCursorPosition(0, _inputRow);
            Console.Write("                                        ");
            Console.SetCursorPosition(0, _inputRow);
            Console.Write("Please Enter A Menu Choice: ");
            ProcessMenuChoice();
        }
    }

    public static void Main(string[] args)
    {
        // Clear the screen, then save the top and left coordinates.
        Console.Clear();
        origRow = Console.CursorTop;
        origCol = Console.CursorLeft;
        
        // set the default floor size
        int rows = 20;
        int cols = 18;
        //create a default constructor b/c there are no args being passed in
        if (args.Length > 1) {
            try
            {
                rows = Int32.Parse(args[0]);
                cols = Int32.Parse(args[1]);
            }
            catch (Exception) {
                Console.Beep();
                Console.WriteLine("Useage example: RobotRat 20 20");
                Console.WriteLine("Creating Robot Rat with default floor dimensions.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }
            
        }
        RobotRat rat = new RobotRat(rows, cols);
        rat.Go();
    } //end main

} //end RobotRat class 

